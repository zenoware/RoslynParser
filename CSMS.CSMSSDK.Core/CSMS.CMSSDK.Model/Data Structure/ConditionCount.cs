/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Description: The following code is a representation of	Condition	*/
/* Counts for decisions in the Data Structure.											*/
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
	/// Class that holds the location of the Condition count
	/// </summary>
	public class ConditionCount
	{
		/// <summary>
		/// Starting Line Number
		/// </summary>
		public int LnStart { get; set; }

		/// <summary>
		/// Ending Line Number
		/// </summary>
		public int LnEnd { get; set; }

	}
}
