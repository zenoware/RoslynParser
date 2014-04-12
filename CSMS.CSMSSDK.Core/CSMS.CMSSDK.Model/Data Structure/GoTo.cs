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

namespace CSMS.CSMSSDK.Model
{
    public class GoTo : Base
    {
        /// <summary>
        /// Label statement to go to
        /// </summary>
        public LabelStatement GoToLabel { get; set; }
        public override string Print(int indent)
        {
            return "GOTO";
        }
    }
}
