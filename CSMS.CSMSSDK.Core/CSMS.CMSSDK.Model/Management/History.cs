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

namespace CSMS.CSMSSDK.Model.Management
{
    public class History
    {
        private int mRevision;
        public History()
        {
            mRevision = 0;
        }
        public DateTime DateModified { get; set; }
        public string Editor { get; set; }
        public int Revision { get; set; }
        public DateTime ReveredAt { get; set; }
        public object ItemsChanged { get; set; }

        
    }
}
