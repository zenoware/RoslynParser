/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Description: The following code is a representation of the base 	*/
/* of all representations in the Data Structure.										*/
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
	/// An abstract base class that holds common information for data in the Data Structure
	/// </summary>
   public abstract class Base
    {
        /// <summary>
        ///Comments in the code
        /// </summary>
        public string InnerComment { get; set; }

        // <summary>
        /// Comments outside a class, namespace, etc.
        /// </summary>
        public string OuterComment { get; set; }

        /// <summary>
        /// The starting Line Number
        /// </summary>
        public int StartLn { get; set; }

        /// <summary>
        /// The Ending Line Number
        /// </summary>
        public int EndLn { get; set; }

       /// <summary>
       /// The Character location of the first char in the statement
       /// </summary>
        public int CharLoc { get; set; }

        /// <summary>
        /// Source File string
        /// </summary>
        public string Source { get; set; }

				/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="indent"
       public abstract string Print(int indent);

				/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="indent"
        protected string buildIndentation(int indent)
        {
          string rv = "";
          for (int i = 0; i < indent; i++)
          {
            rv += " ";
          }
          return rv;
        }

				/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="indent"
				/// <returns>String representation of the Qualifiers</returns>
        protected string getQualifer(List<Qualifiers> list)
        {
          string rv = "";
          if (list != null)
          {
            foreach (Qualifiers q in list)
            {
              rv += q.ToString() + " ";
            }
          }
          return rv;
        }


				/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="indent"
				/// <returns>String representation for the Encapsulations</returns>
        protected string getEncapsulation(List<Encapsulation> list)
        {
          string rv = "";
          if (list != null)
          {
            foreach (Encapsulation e in list)
            {
              rv += e.ToString() + " ";
            }
          }
          return rv;
        }

				/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="indent"
				/// <param name="list"
				/// <returns></returns>
				protected string getInovkedMethodInfo(List<InvokedMethod> list, int indent)
				{
					string space = buildIndentation(indent);
          string rv = "";
          if (list != null)
          {
            foreach (InvokedMethod v in list)
            {
              rv += v.Print(indent + 2) + Environment.NewLine;
            }
          }
          return rv;
        }

				/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="indent"
				/// <param name="list"
				/// <returns></returns>
        protected string getVariableList(List<Variables> list, int indent)
        {
          string space = buildIndentation(indent);
          string rv = "";
          if (list != null)
          {
            foreach (Variables v in list)
            {
              rv += v.Print(indent + 2) + Environment.NewLine;
            }
          }
          return rv;
        }
				/// <summary>
				/// Used for debugging - Writes out all the types contained in the class
				/// </summary>
				/// <param name="list"
				/// <returns></returns>
        protected string getStringList(List<string> list)
        {
          string rv = "";
          if (list != null)
          {
            for (int i = 0; i < list.Count; i++)
            {
              rv += list[i];
              if (i < list.Count - 1)
              {
                rv += ",";
              }
            }
          }
          return rv;
        }
    }
}
