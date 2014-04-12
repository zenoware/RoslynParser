/********************************************************************/
/* Author: Jason Pugh											    */
/* Date: © 3/13/2013  												*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.			    */
/********************************************************************/

using System;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace CSMS.CSMSSDK.Model.Management
{

    public enum PersonnelPermission
    {
        /// <summary>
        /// Full Access - Can Add/Edit All Personnel, View Budget Information, Add/Edit Tasks, Add/Edit Groups, and Modify Project Budget Information
        /// </summary>
        Administrator,
        /// <summary>
        /// Limited Access - Can View Tasks, Can Modify Effort on Assigned Tasks, Can Link Source to Tasks, can Modify their User Information Only, View Only on Budget Graph
        /// </summary>
        Contributor,
        /// <summary>
        /// Read Only Access - Can View Only
        /// </summary>
        ReadOnly
    }

    public class BasePersonel
    {
        public BasePersonel()
        {
            FirstName = "";
            LastName = "";
            Role = "";
            Tasks = new ObservableCollection<Task>();
            Salary = 0.0;
            HoursPerYear = 0.0;
            HasPassword = false;
            Permissions = PersonnelPermission.Contributor;
            PersonGuid = Guid.Empty;
        }

        public bool HasPassword { get; set; }

        /// <summary>
        /// Password - Aes Encryption preferred (but can be another encryption)
        /// </summary>
        public string Password { get; set; }

        public PersonnelPermission Permissions { get; set; }

        public Guid PersonGuid { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Role { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }
        public double TotalHours
        {
            get
            {
                if (Tasks != null && Tasks.Count > 0)
                {
                    double retVal = 0.0;
                    foreach (Task task in Tasks)
                    {
                        retVal += task.Hours;
                    }
                    return retVal;
                }
                return 0.0;
            }
        }
        public ImageSource Image { get; set; }
        public double Salary { get; set; }
        public double HoursPerYear { get; set; }
        public double SalaryPerHour
        {
            get
            {
                if (HoursPerYear > 0)
                {
                    return Salary / HoursPerYear;
                }
                else
                {
                    return 0.0;
                }
            }
        }
        public double CurrentCost
        {
            get
            {
                return SalaryPerHour * TotalHours;
            }
        }

        public string TFSIdentity { get; set; }

        public Guid TfsIdentityGuid { get; set; }
    }
}
