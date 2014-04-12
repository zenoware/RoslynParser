/********************************************************************/
/* Author: Jason Pugh											    */
/* Date: © 3/13/2013  												*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.			    */
/********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CSMS.CSMSSDK.Model.Management
{
    /// <summary>
    /// Holds the state of the task
    /// </summary>
    public enum TaskState
    {
        TODO,
        Working,
        Unassigned,
        Complete
    }

    /// <summary>
    /// The class which holds associated source for the Task
    /// </summary>
    public class AssociatedSource
    {
        public AssociatedSource()
        {
            Path = "";
        }
        
        /// <summary>
        /// The Source Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Has calculated Metrics
        /// </summary>
        public bool HasMetrics { get; set; }
    }

    public class ModifiedTask
    {

        private DateTime mDate;
        private double mValue;
        private TypeChange mTypeChanged;

        public DateTime Date { get { return mDate; } set { mDate = value; } }
        public double Value { get { return mValue; } set { mValue = value; } }
        public enum TypeChange
        {
            Completed,
            Hours,
            CurrentEffort
        }
        public TypeChange TypeChanged { get { return mTypeChanged; } set { mTypeChanged = value; } }

        public ModifiedTask()
        {
            mDate = DateTime.Now.Date;
            mValue = 0;
            mTypeChanged = TypeChange.CurrentEffort;
        }
    }

    /// <summary>
    /// The class which holds Task information
    /// </summary>
    public class Task : INotifyPropertyChanged
    {
        private List<SourceControlData> mSourceControlLinkage;
        private double mCurrentEffort;
        private DateTime mECD;
        private DateTime mStartDate;
        private TaskState mTaskState;
        private DateTime mACD;
        private DateTime mParentStartDate;
        private DateTime mParentEndDate;
        private ObservableCollection<Guid> mAssignedPersonnel;
        private List<ModifiedTask> mModifiedTasks;
        private bool mLoading;
        private string mName;
        private string mDescription;
        public Task()
        {
            mSourceControlLinkage = new List<SourceControlData>();
            mName = "";
            Hours = 0.0;
            mDescription = "";
            TasksState = Management.TaskState.TODO;
            AssociatedMetrics = new ObservableCollection<MetricResults>();
            SourceAssociated = new ObservableCollection<AssociatedSource>();
            mAssignedPersonnel = new ObservableCollection<Guid>();
            StartDate = DateTime.Now.Date;
            ParentStartDate = DateTime.Now.Date;
            ParentEndDate = DateTime.Now.Date.AddDays(1);
            ExpectedCompletionDate = DateTime.Now.Date;
            ActualCompletionDate = DateTime.Now.Date.AddDays(1);
            DependentTasks = new ObservableCollection<Task>();
            mCurrentEffort = 0.0;
            ReferencePoint = new Point(0, 0);
            try
            {
                TaskStackPanel = new StackPanel();
            }
            catch
            {
                //Ignore
            }
            mModifiedTasks = new List<ModifiedTask>();
        }

        public bool Loading
        {
            get
            {
                return mLoading;
            }
            set
            {
                if (value != mLoading)
                {
                    mLoading = value;
                }
            }
        }

        public bool UpdatingFromSourceControl { get; set; }

        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                if (value != mName)
                {
                    mName = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private double mHours;
        public double Hours
        {
            get
            {
                return mHours;
            }
            set
            {
                mHours = value;
                if (!mLoading && mModifiedTasks != null)
                {
                    foreach (ModifiedTask mt in mModifiedTasks)
                    {
                        if (mt.TypeChanged == ModifiedTask.TypeChange.Hours && mt.Date.Date == DateTime.Now.Date)
                        {
                            mModifiedTasks.Remove(mt);
                            break;
                        }
                    }

                    ModifiedTask modTask = new Management.ModifiedTask();
                    modTask.Date = DateTime.Now.Date;
                    modTask.Value = mHours;
                    modTask.TypeChanged = Management.ModifiedTask.TypeChange.Hours;
                    mModifiedTasks.Add(modTask);
                }
                OnPropertyChanged("Hours");
            }
        }
        /// <summary>
        /// Textual Description of the Task
        /// </summary>
        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                if (value != mDescription)
                {
                    mDescription = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        /// Associated Metrics
        /// </summary>
        public ObservableCollection<MetricResults> AssociatedMetrics { get; set; }

        public ObservableCollection<Guid> AssignedPersonnel
        {
            get
            {
                return mAssignedPersonnel;
            }
            set
            {
                if (value != mAssignedPersonnel)
                {
                    if (value.Count > mAssignedPersonnel.Count)
                    {
                        AddToSCData(value);
                    }
                    else if (value.Count < mAssignedPersonnel.Count)
                    {
                        SetRemoveToSCData(value, mAssignedPersonnel);
                    }
                    else
                    {
                        OnPropertyChanged("AssignedPersonnel");
                    }
                    mAssignedPersonnel = value;

                    
                }
            }
        }

        private void AddToSCData(ObservableCollection<Guid> newValues)
        {
            bool foundOld = false;
            foreach (Guid guid in newValues)
            {
                foreach (SourceControlData scd in mSourceControlLinkage)
                {
                    if (scd.AssignedPerson == guid)
                    {
                        scd.Block = false;
                        foundOld = true;
                        break;
                    }
                }
                if (foundOld) break;
                else
                {
                    mSourceControlLinkage.Add(new SourceControlData() { AddAsNew = true, AssignedPerson = guid });
                }
            }
        }

        private void SetRemoveToSCData(ObservableCollection<Guid> newValues, ObservableCollection<Guid> oldValues)
        {
            foreach (Guid guid in oldValues)
            {
                if (!newValues.Contains(guid))
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        if (scd.AssignedPerson == guid)
                        {
                            scd.Block = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Associated Source - This is set to tell the Metrics App what to add to the source list
        /// </summary>
        public ObservableCollection<AssociatedSource> SourceAssociated { get; set; }
        
        /// <summary>
        /// Start Date of the Task
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return mStartDate;
            }
            set
            {
                mStartDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        /// <summary>
        /// Expected (User-input) Completion Date
        /// </summary>
        public DateTime ExpectedCompletionDate
        {
            get
            {
                return mECD;
            }
            set
            {
                mECD = value;
                OnPropertyChanged("ExpectedCompletionDate");
            }
        }

        /// <summary>
        /// The text of the expected completion date
        /// </summary>
        public string ExpectedCompletionDateText
        {
            get
            {
                return ExpectedCompletionDate.ToShortDateString();
            }
        }

        /// <summary>
        /// This is the task's actual completion date
        /// </summary>
        public DateTime ActualCompletionDate
        {
            get
            {
                return mACD;
            }
            set
            {
                if (this.mTaskState != TaskState.Complete)
                {
                    mACD = DateTime.Now.Date;
                    OnPropertyChanged("ActualCompletionDate");
                }
                else if (value != mACD)
                {
                    mACD = value;
                    OnPropertyChanged("ActualCompletionDate");
                }
            }
        }

        /// <summary>
        /// The current effort on the task
        /// </summary>
        public double CurrentEffort
        {
            get
            {
                return mCurrentEffort;
            }
            set
            {
                if (mCurrentEffort != value)
                {
                    OnPropertyChanged("CurrentEffort");
                    mCurrentEffort = value;
                    if (!mLoading)
                    {
                        foreach (ModifiedTask mt in mModifiedTasks)
                        {
                            if (mt.TypeChanged == ModifiedTask.TypeChange.CurrentEffort && mt.Date.Date == DateTime.Now.Date)
                            {
                                mModifiedTasks.Remove(mt);
                                break;
                            }
                        }

                        ModifiedTask modTask = new Management.ModifiedTask();
                        modTask.Date = DateTime.Now.Date;
                        modTask.Value = mCurrentEffort;
                        modTask.TypeChanged = Management.ModifiedTask.TypeChange.CurrentEffort;
                        mModifiedTasks.Add(modTask);
                    }
                }
            }
        }

        /// <summary>
        /// Any dependent tasks for this given task
        /// </summary>
        public ObservableCollection<Task> DependentTasks { get; set; }
        
        /// <summary>
        /// Used to determine if this is a dependent task or not
        /// </summary>
        public bool IsDependent { get; set; }

        /// <summary>
        /// Used to determine if this task should be drawn or not
        /// </summary>
        public bool IsDrawn { get; set; }

        /// <summary>
        /// Holds the task's state
        /// </summary>
        public TaskState TasksState
        {
            get
            {
                return mTaskState;
            }
            set
            {
                if (value != mTaskState)
                {
                    OnPropertyChanged("State");
                    mTaskState = value;
                    if (mTaskState == Management.TaskState.Complete)
                    {
                        if (!mLoading)
                        {
                            foreach (ModifiedTask mt in mModifiedTasks)
                            {
                                if (mt.TypeChanged == ModifiedTask.TypeChange.Completed && mt.Date == DateTime.Now.Date)
                                {
                                    mModifiedTasks.Remove(mt);
                                    break;
                                }
                            }

                            ModifiedTask modTask = new Management.ModifiedTask();
                            modTask.TypeChanged = Management.ModifiedTask.TypeChange.Completed;
                            modTask.Date = DateTime.Now.Date;
                            mModifiedTasks.Add(modTask);
                            mACD = DateTime.Now.Date;
                        }
                    }
                    else
                    {
                        foreach (ModifiedTask modTask in mModifiedTasks)
                        {
                            if (modTask.TypeChanged == ModifiedTask.TypeChange.Completed)
                            {
                                mModifiedTasks.Remove(modTask);
                                break;
                            }
                        }
                    }
                }
            }
        }
        

        #region Agile Process 

        private bool mIsAgileTask = false;

        /// <summary>
        /// If this task is an agile process task or not
        /// </summary>
        /// 
        public bool IsAgileTask
        {
            get
            {
                return mIsAgileTask;
            }
            set
            {
                if (value != mIsAgileTask)
                {
                    mIsAgileTask = value;
                }
            }
        }

        /// <summary>
        /// The x location to draw the agile process task
        /// </summary>
        public double XLoc { get; set; }

        /// <summary>
        /// The y location to draw the agile process task
        /// </summary>
        public double yLoc { get; set; }

        /// <summary>
        /// Reference point that defines where the agile task is in reference to its state
        /// </summary>
        public Point ReferencePoint { get; set; }

        /// <summary>
        /// The Reference Grid for the Agile Task
        /// </summary>
        public StackPanel TaskStackPanel { get; set; }

        public List<ModifiedTask> ModifiedTasks
        {
            get
            {
                return mModifiedTasks;
            }
        }

        #endregion


        #region Source Control Stuff
        
        public List<SourceControlData> SourceControlLinkage
        {
            get
            {
                return mSourceControlLinkage;
            }
            set
            {
                if (value != mSourceControlLinkage)
                {
                    mSourceControlLinkage = value;
                }
            }
        }
        #endregion

        /// <summary>
        /// the event for when a property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (!mLoading)
            {
                if (propertyName == "Name")
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        scd.UpdateTaskName = true;
                    }
                }
                else if (propertyName == "Description")
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        scd.UpdateDescription = true;
                    }
                }
                else if (propertyName == "AssignedPersonnel")
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        scd.UpdateAssignedPersonnel = true;
                    }
                }
                else if (propertyName == "Hours")
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        scd.UpdateHours = true;
                    }
                }
                else if (propertyName == "ActualCompletionDate")
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        scd.UpdateExpectedCompletionDate = true;
                    }
                }
                else if (propertyName == "State")
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        scd.UpdateState = true;
                    }
                }
                else if (propertyName == "StartDate")
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        scd.UpdateStartDate = true;
                    }
                }
                else if (propertyName == "CurrentEffort")
                {
                    foreach (SourceControlData scd in mSourceControlLinkage)
                    {
                        scd.UpdateCurrentEffort = true;
                    }
                }
            }
        }

        #region Dependant Task Stuff
       

        public DateTime ParentStartDate
        {
            get
            {
                return mParentStartDate;
            }
            set
            {
                if (value != mParentStartDate)
                {
                    mParentStartDate = value;
                }
            }
        }

        public DateTime ParentEndDate
        {
            get
            {
                return mParentEndDate;
            }
            set
            {
                if (value != mParentEndDate)
                {
                    mParentEndDate = value;
                }
            }
        }
        #endregion
    }

    public class SourceControlData
    {
        public bool IsInSourceControl { get; set; }
        public int SourceControlID { get; set; }
        public bool UpdateTaskName { get; set; }
        public bool UpdateDescription { get; set; }
        public bool UpdateAssignedPersonnel { get; set; }
        public Guid AssignedPerson { get; set; }
        public bool UpdateHours { get; set; }
        public bool UpdateCurrentEffort { get; set; }
        public bool UpdateExpectedCompletionDate { get; set; }
        public bool UpdateState { get; set; }
        public bool UpdateStartDate { get; set; }
        public bool AddAsNew { get; set; }
        public bool Block { get; set; }
    }
}
