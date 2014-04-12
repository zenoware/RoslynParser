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
	/// Class that holds the Interfaces of the Data Structure
	/// </summary>
	public class Interface : Base
	{
		/// <summary>
		/// Constructor that sets all the Types so no lingering null types exist
		/// </summary>
		public Interface()
		{
			Encapsulation = new List<Encapsulation>();
			Qualifiers = new List<Qualifiers>();
			Fields = new List<Variables>();
			Methods = new List<Method>();
			InheritsStrings = new List<string>();
			InheritsInterfaces = new List<Interface>();
		}
		/// <summary>
		/// The accessability of the Class
		/// </summary>
		public List<Encapsulation> Encapsulation { get; set; }

		/// <summary>
		/// List of Types (abstract, etc)
		/// </summary>
		public List<Qualifiers> Qualifiers { get; set; }

		/// <summary>
		/// The Class Name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// List of Attributes
		/// </summary>
		public List<Variables> Fields { get; set; }

        /// <summary>
        /// List of Properties
        /// </summary>
        public List<Property> Properties { get; set; }

		/// <summary>
		/// List of Methods
		/// </summary>
		public List<Method> Methods { get; set; }

		/// <summary>
		/// List of inheritance stored during parsing
		/// </summary>
		public List<string> InheritsStrings { get; set; }

		/// <summary>
		/// List of inheritance as interface(s)
		/// </summary>
		public List<Interface> InheritsInterfaces { get; set; }

		/// <summary>
		/// Used for debugging - Writes out all the types contained in the class
		/// </summary>
		/// <param name="indent"
		public override string Print(int indent)
		{
			string space = buildIndentation(indent);
			string rv = "";

			rv += space + "Class: " + Environment.NewLine;
			rv += space + "------ " + Environment.NewLine;
			rv += space + "  Type: " + getQualifer(Qualifiers) + Environment.NewLine;
			rv += space + "  Accessibility: " + getEncapsulation(Encapsulation) + Environment.NewLine;
			rv += space + "  Name: " + Name + Environment.NewLine;
			
			if (Fields != null)
			{
				rv += space + "  Attributes: " + Environment.NewLine;
				foreach (Variables v in Fields)
				{
					rv += v.Print(indent + 2) + Environment.NewLine;
				}
			}

			if (Methods != null)
			{
				rv += space + "  Methods: " + Environment.NewLine;
				foreach (Method m in Methods)
				{
					rv += m.Print(indent + 2) + Environment.NewLine;
				}
			}
			
			if (InheritsStrings != null)
			{
				rv += space + "  Inherits: " + getStringList(InheritsStrings) + Environment.NewLine;
			}	

			return rv;
		}

	}
}
