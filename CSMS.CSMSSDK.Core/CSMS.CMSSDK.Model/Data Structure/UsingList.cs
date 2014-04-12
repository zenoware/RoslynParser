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
	/// Class that holds the Using Lists in the Data Structure
	/// </summary>
    public class UsingList : Base
    {
        /// <summary>
        /// The name of the library
        /// </summary>
        public string LibName { get; set; }

        /// <summary>
        /// Identifier (if applicable)
        /// </summary>
        public string Identifier { get; set; }

				/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="indent"
        public override string Print(int indent)
        {
          string space = buildIndentation(indent);
          string rv = "";

          rv += space + "Using List: " + Environment.NewLine;
          rv += space + "  LibName: " + LibName + Environment.NewLine;
          rv += space + "  Identifier: " + Identifier + Environment.NewLine;
          return rv;
        }
    }
}
