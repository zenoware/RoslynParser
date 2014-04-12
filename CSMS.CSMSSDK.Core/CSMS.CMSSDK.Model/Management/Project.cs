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
using System.Windows.Data;
using System.Collections;

namespace CSMS.CSMSSDK.Model.Management
{
    public class Project
    {
        private string mName;
        private string mDescription;
        private DateTime mLastModified = new DateTime();
        private ObservableCollection<Group> mGroups;
        private DateTime mStartDate;
        private DateTime mActualStartDate;
        private DateTime mEndDate;
        private DateTime mActualEndDate;
        private double mBudget;
        private ObservableCollection<History> mHistoryLog;
        private ObservableCollection<Task> mTasks;
        private Group mCatchAllGroup;
        private ObservableCollection<KeyValuePair<DateTime, double>> mBudgetThreshold;
        private List<KeyValuePair<DateTime, double>> mActualBudget;
        private List<KeyValuePair<DateTime, double>> mExpectedBudget;
        private ObservableCollection<KeyValuePair<int, double>> mCompletedTasks;
        private ObservableCollection<KeyValuePair<int, double>> mRemainingEffort;
        private DateTime mBurndownStart;
        private DateTime mBurndownEnd;
        private ObservableCollection<KeyValuePair<int, double>> mIdealBurndown;
        private ObservableCollection<KeyValuePair<int, double>> mRemainingTasks;
        public Project()
        {
            mName = "";
            mDescription = "";
            mGroups = new ObservableCollection<Group>();
            mGroups.CollectionChanged += mGroups_CollectionChanged;
            mStartDate = DateTime.Now;
            mActualStartDate = DateTime.Now;
            mEndDate = new DateTime();
            mActualStartDate = new DateTime();
            mBudget = 0;
            mHistoryLog = new ObservableCollection<History>();
            mHistoryLog.CollectionChanged += mHistoryLog_CollectionChanged;
            mTasks = new ObservableCollection<Task>();
            mTasks.CollectionChanged += mTasks_CollectionChanged;
            mCatchAllGroup = new Group();
            mBudgetThreshold = new ObservableCollection<KeyValuePair<DateTime, double>>();
            mActualBudget = new List<KeyValuePair<DateTime, double>>();
            mExpectedBudget = new List<KeyValuePair<DateTime, double>>();
            mCompletedTasks = new ObservableCollection<KeyValuePair<int, double>>();
            mRemainingEffort = new ObservableCollection<KeyValuePair<int, double>>();
            mBurndownStart = DateTime.Now;
            mBurndownEnd = DateTime.Now;
            mIdealBurndown = new ObservableCollection<KeyValuePair<int, double>>();
            mRemainingTasks = new ObservableCollection<KeyValuePair<int, double>>();
        }

        void mTasks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateLastModified();
        }

        void mHistoryLog_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateLastModified();
        }

        void mGroups_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateLastModified();
        }
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
                    UpdateLastModified();
                    mName = value;
                }
            }
        }
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
                    UpdateLastModified();
                    mDescription = value;
                }
            }
        }
        public ObservableCollection<Group> Groups
        {
            get
            {
                return mGroups;
            }
            set
            {
                if (value != mGroups)
                {
                    UpdateLastModified();
                    mGroups = value;
                }
            }
        }
        public DateTime StartDate
        {
            get
            {
                return mStartDate;
            }
            set
            {
                if (value != mStartDate)
                {
                    UpdateLastModified();
                    mStartDate = value;
                }
            }
        }
        public DateTime ActualStartDate
        {
            get
            {
                return mActualStartDate;
            }
            set
            {
                if (value != mActualStartDate)
                {
                    UpdateLastModified();
                    mActualStartDate = value;
                }
            }
        }
        public DateTime EndDate
        {
            get
            {
                return mEndDate;
            }
            set
            {
                if (value != mEndDate)
                {
                    UpdateLastModified();
                    mEndDate = value;
                }
            }
        }
        public DateTime ActualEndDate
        {
            get
            {
                return mActualStartDate;
            }
            set
            {
                if (value != mActualStartDate)
                {
                    UpdateLastModified();
                    mActualStartDate = value;
                }
            }
        }
        public double Budget
        {
            get
            {
                return mBudget;
            }
            set
            {
                if (value != mBudget)
                {
                    UpdateLastModified();
                    mBudget = value;
                }
            }
        }
        public ObservableCollection<History> HistoryLog
        {
            get
            {
                return mHistoryLog;
            }
            set
            {
                if (value != mHistoryLog)
                {
                    UpdateLastModified();
                    mHistoryLog = value;
                }
            }
        }
        public ObservableCollection<Task> Tasks
        {
            get
            {
                return mTasks;
            }
            set
            {
                if (value != mTasks)
                {
                    UpdateLastModified();
                    mTasks = value;
                }
            }
        }
        public Group CatchAllGroup
        {
            get
            {
                return mCatchAllGroup;
            }
            set
            {
                if (value != mCatchAllGroup)
                {
                    UpdateLastModified();
                    mCatchAllGroup = value;
                }
            }
        }

        public ObservableCollection<KeyValuePair<DateTime, double>> BudgetThreshold
        {
            get
            {
                return mBudgetThreshold;
            }
            set
            {
                if (value != mBudgetThreshold)
                {
                    UpdateLastModified();
                    mBudgetThreshold = value;
                }
            }

        }

        public List<KeyValuePair<DateTime, double>> ActualBudget
        {
            get
            {
                return mActualBudget;
            }
            set
            {
                if (value != mActualBudget)
                {
                    UpdateLastModified();
                    mActualBudget = value;
                }
            }
        }

        public List<KeyValuePair<DateTime, double>> ExpectedBudget
        {
            get
            {
                return mExpectedBudget;
            }
            set
            {
                if (value != mExpectedBudget)
                {
                    UpdateLastModified();
                    mExpectedBudget = value;
                }
            }
        }

        public ObservableCollection<KeyValuePair<int, double>> CompletedTasks
        {
            get
            {
                return mCompletedTasks;
            }
            set
            {
                if (value != mCompletedTasks)
                {
                    UpdateLastModified();
                    mCompletedTasks = value;
                }
            }
        }

        public ObservableCollection<KeyValuePair<int, double>> RemainingEffort
        {
            get
            {
                return mRemainingEffort;
            }
            set
            {
                if (value != mRemainingEffort)
                {
                    UpdateLastModified();
                    mRemainingEffort = value;
                }
            }
        }

        public DateTime BurndownStart
        {
            get
            {
                return mBurndownStart;
            }
            set
            {
                if (value != mBurndownStart)
                {
                    mBurndownStart = value;
                }
            }
        }

        public DateTime BurndownEnd
        {
            get
            {
                return mBurndownEnd;
            }
            set
            {
                if (value != mBurndownEnd)
                {
                    mBurndownEnd = value;
                }
            }
        }

        public ObservableCollection<KeyValuePair<int, double>> IdealBurndown
        {
            get
            {
                return mIdealBurndown;
            }
            set
            {
                if (value != mIdealBurndown)
                {
                    UpdateLastModified();
                    mIdealBurndown = value;
                }
            }
        }

        public ObservableCollection<KeyValuePair<int, double>> RemainingTasks
        {
            get
            {
                return mRemainingTasks;
            }
            set
            {
                if (value != mRemainingTasks)
                {
                    UpdateLastModified();
                    mRemainingTasks = value;
                }
            }
        }

        public DateTime LastModification { get { return mLastModified; } }

        private void UpdateLastModified()
        {
            mLastModified = DateTime.Now;
        }

        public IList Children
        {
            get
            {
                return new CompositeCollection(){
                    new CollectionContainer(){ Collection = Groups }
                };
            }
        }
    }
}
