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
	/// Class that holds the Do While Decisions in the Data Structure
	/// </summary>
    public class DoWhileLoop : BaseDecisions
    {

        public DoWhileLoop()
        {
            ConditionCount = 0;
        }
			/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="indent"
      public override string Print(int indent)
      {
        string space = buildIndentation(indent);

        //TODO: Print something meaningful
        return "DoWhileLoop";
      }

      /// <summary>
      /// A count of conditions
      /// </summary>
      public int ConditionCount { get; set; }

    }
}
