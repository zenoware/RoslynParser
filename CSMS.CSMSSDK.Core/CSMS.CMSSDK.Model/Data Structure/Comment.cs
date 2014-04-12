/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Description: The following code is a representation of Comments 	*/
/* in the Data Structure.																						*/
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
	/// Class representing Comments
	/// </summary>
	public class Comment : Base
	{

		/// <summary>
		/// Content of the comment
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Used for debugging - Writes out all the types contained in the class
		/// </summary>
		/// <param name="indent"></param>
		/// <returns></returns>
		public override string Print(int indent)
		{
			return "Not Implemented";
		}
	}
}
