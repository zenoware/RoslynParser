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
	/// Class that holds the Enum Object in the Data Structure
	/// </summary>
	public class Enum : Base
	{
		/// <summary>
		/// Constructor that sets all the Types so no lingering null types exist
		/// </summary>
		public Enum()
		{
			Type = new Type();
			Encapsulation = new List<Encapsulation>();
			EnumItems = new List<string>();
		}
		/// <summary>
		/// The accessability of the Enum
		/// </summary>
		public List<Encapsulation> Encapsulation { get; set; }

		/// <summary>
		/// Name of the Enum
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Type of the Enum
		/// </summary>
		public Type Type { get; set; }

		/// <summary>
		/// List of Enum Item Names
		/// </summary>
		public List<string> EnumItems { get; set; }

		/// <summary>
		/// Used for debugging - Writes out all the types contained in the class
		/// </summary>
		/// <param name="indent"
		public override string Print(int indent)
		{
			string space = buildIndentation(indent);
			string rv = "";

			rv += space + "Enum: " + Environment.NewLine;
			rv += space + "----- " + Environment.NewLine;
			rv += space + "  Type: " + Type.Name + Environment.NewLine;
			rv += space + "  Accessibility: " + getEncapsulation(Encapsulation) + Environment.NewLine;
			rv += space + "  Name: " + Name + Environment.NewLine;
			rv += space + "  EnumItems: " + getStringList(EnumItems) + Environment.NewLine;
			return rv;
		}
	}
}
