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
  /// Class that holds the Variables of the Data Structure
  /// </summary>
  public class Variables : Base
  {
		/// <summary>
		/// Constructor that sets all the Types so no lingering null types exist
		/// </summary>
    public Variables()
    {
			Type = new Type();
			Accessibility = new List<Encapsulation>();
			Qualifiers = new List<Qualifiers>();
    }

    /// <summary>
    /// The Accessability of the Variable
    /// </summary>
    public List<Encapsulation> Accessibility { get; set; }


    /// <summary>
    /// List of types (static, etc)
    /// </summary>
    public List<Qualifiers> Qualifiers { get; set; }

    /// <summary>
    /// The Variable Type
    /// </summary>
    public Type Type { get; set; }

    /// <summary>
    /// The Variable's Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// If the variable is referenced <value>true</value> or declared <value>false</value>
    /// </summary>
    public bool IsReferenced { get; set; }

    public bool IsPrivate
    {
      get
      {
        //TODO: Variable Accessibility attribute should NOT be a list - only a single item.
        return Accessibility.Contains(Encapsulation.Private);
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
      string qualifiers = "";
      if (Qualifiers != null)
      {
        foreach (Qualifiers q in this.Qualifiers)
        {
          qualifiers += q.ToString() + " ";
        }
      }
      string encapsulation = "";
      if (Accessibility != null)
      {
        foreach (Encapsulation e in Accessibility)
        {
          encapsulation += e.ToString() + " ";
        }
      }

      rv += space + "Variable: " + Environment.NewLine;
      rv += space + "---------" + Environment.NewLine;
      rv += space + "  Name: " + Name + Environment.NewLine;
      rv += space + "  Type: " + Type.Name + Environment.NewLine;
      rv += space + "  IsReferenced: " + IsReferenced + Environment.NewLine;
      rv += space + "  Qualifiers: " + qualifiers + Environment.NewLine;
      rv += space + "  Accessibility: " + encapsulation + Environment.NewLine;

      return rv;
    }
  }

}
