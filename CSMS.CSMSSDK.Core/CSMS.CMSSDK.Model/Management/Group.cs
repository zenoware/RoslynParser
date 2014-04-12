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
    /// <summary>
    /// Just a holder for managers, developers, Testers, and QualityPersonel
    /// </summary>
    public class Group
    {
        public Group()
        {
            Personel = new ObservableCollection<GroupItems>();
        }
        public string Name { get; set; }
        public ObservableCollection<GroupItems> Personel { get; set; }
    }

    public class GroupItems
    {
        public GroupItems()
        {
            Personel = new ObservableCollection<BasePersonel>();
        }

        public string ObjectName { get; set; }
        public ObservableCollection<BasePersonel> Personel { get; set; }
    }
}
