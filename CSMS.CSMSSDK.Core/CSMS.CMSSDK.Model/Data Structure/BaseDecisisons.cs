/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Description: The following code is a representation of the base 	*/
/* of all decisions in the Data Structure.													*/
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
	/// A class that holds common information for Decision Types
	/// </summary>
    public class BaseDecisions : Base
    {

        public BaseDecisions()
        {
            AccessedVars = new List<Variables>();
            InvokedMethods = new List<InvokedMethod>();
            Nested = new List<BaseDecisions>();
        }

        /// <summary>
        /// A List which holds any parent decisions
        /// </summary>
        public List<BaseDecisions> Nested { get; set; }

        /// <summary>
        /// A list of accessed variables
        /// </summary>
        public List<Variables> AccessedVars { get; set; }

        /// <summary>
        /// A list of Invoked Methods within an If Statement
        /// </summary>
        public List<InvokedMethod> InvokedMethods { get; set; }

        /// <summary>
        /// Holder for the expression list starting line
        /// </summary>
        public int ExpressionListStartLn { get; set; }

        /// <summary>
        /// Holder for the expression list ending line
        /// </summary>
        public int ExpressionListEndLn { get; set; }

        /// <summary>
        /// Boolean to hold if the base decision is nested in another decision or not
        /// </summary>
        public bool IsNested { get; set; }

        public override string Print(int indent)
        {
          string space = buildIndentation(indent);

          throw new NotImplementedException();
        }
    }
}
