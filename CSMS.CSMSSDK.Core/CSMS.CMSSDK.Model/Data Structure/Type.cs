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
	/// Class that holds the Types of the Data Structure
	/// </summary>
	public class Type
	{
		/// <summary>
		/// Constructor that sets all the Types so no lingering null types exist
		/// </summary>
		public Type()
		{
			IsNotUserDefined = false;
			IsKnownType = false;
			GenericType = "";
      Name = "";
		}
		/// <summary>
		/// Is known type
		/// </summary>
		public bool IsNotUserDefined { get; set; }

		/// <summary>
		/// Property that holds if the type is User Defined or Not
		/// </summary>
    public bool IsUserDefined
    {
      get { return !IsNotUserDefined; }
    }

		/// <summary>
		/// Determines if the Type is Known or not (User Defined Type)
		/// </summary>
		public bool IsKnownType { get; set; }

		/// <summary>
		/// The string representation of a Type
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Generic Type for Lists, Arrays, etc
		/// </summary>
		public string GenericType { get; set; }
	}
}
