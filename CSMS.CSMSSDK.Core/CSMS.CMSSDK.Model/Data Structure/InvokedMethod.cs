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
	/// Class that holds the Invoked Methods of the Data Structure
	/// </summary>
	public class InvokedMethod : Base
	{
		/// <summary>
		/// Constructor that sets all the Types so no lingering null types exist
		/// </summary>
		public InvokedMethod()
		{
			Attribute = new Variables();
			Parameters = new List<Variables>();
            Qualifiers = new List<Qualifiers>();
		}
		/// <summary>
		/// This is the variable that called the method (can be static or not)
		/// </summary>
		public Model.Variables Attribute { get; set; }

		/// <summary>
		/// The name of the invoked method
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Parameters
		/// </summary>
		public List<Variables> Parameters { get; set; }

        /// <summary>
        /// Qualifiers
        /// </summary>
        public List<Qualifiers> Qualifiers { get; set; }

		/// <summary>
		/// Returns if the method call is static
		/// </summary>
		public bool IsStatic
		{
			get
			{
				return Attribute.Qualifiers.Contains(CSMSSDK.Model.Qualifiers.Static);
			}
		}

		/// <summary>
		/// Used for debugging - Writes out all the types contained in the class
		/// </summary>
		/// <param name="indent"
		public override string Print(int indent)
		{
			string space = buildIndentation(indent);
			string rv = "";


			string step = "";


			step = space + "Invoked Method: " + Environment.NewLine;
			rv += step;
			step = space + "-------" + Environment.NewLine;
			rv += step;
			step = space + "  Qualifiers: " + getQualifer(Attribute.Qualifiers) + Environment.NewLine;
			rv += step;
			step = space + "  Type: " + Attribute.Type.Name + Environment.NewLine;
			rv += step;
			step = space + "  Name: " + Name + Environment.NewLine;
			rv += step;
			step = space + "  Parameters:" + Environment.NewLine;
			rv += step;
			step = getVariableList(this.Parameters, indent + 2);
			rv += step;
			return rv;
		}

	}
}
