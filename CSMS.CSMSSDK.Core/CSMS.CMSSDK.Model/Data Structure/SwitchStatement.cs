/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.								*/
/********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSMS.CSMSSDK.Model
{
    /// <summary>
    /// !Not Used! - Class that holds the Switch Statement Decisions of the Data Structure
    /// </summary>
    public class SwitchStatement : BaseDecisions
    {
        public SwitchStatement()
        {
            ConditionCount = 0;
            CaseStatements = new List<CaseStatement>();
        }

        /// <summary>
        /// Holds Case Statement information
        /// </summary>
        public List<CaseStatement> CaseStatements { get; set; }

        /// <summary>
        /// A count of conditions
        /// </summary>
        public int ConditionCount { get; set; }

        /// <summary>
        /// Used for debugging - Writes out all the types contained in the class
        /// </summary>
        /// <param name="indent"
        public override string Print(int indent)
        {
            string space = buildIndentation(indent);

            throw new NotImplementedException();
        }
    }

    public class CaseStatement : BaseDecisions
    {
        public bool IsDefault { get; set; }
    }
}
