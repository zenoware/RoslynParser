/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Description: The following code is a representation of a class 	*/
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
    /// A class that represents the Class Object in the Data Structure
    /// </summary>
    public class Class : Base
    {
        /// <summary>
        /// Constructor that sets all the Types so no lingering null types exist
        /// </summary>
        public Class()
        {
            Preprocessors = new List<Preprocessor>();
            Encapsulation = new List<Encapsulation>();
            Qualifiers = new List<Qualifiers>();
            Classes = new List<Class>();
            Modules = new List<Module>();
            Enums = new List<Enum>();
            Structs = new List<Struct>();
            Unions = new List<Union>();
            Fields = new List<Variables>();
            Properties = new List<Property>();
            Delegates = new List<Delegate>();
            Methods = new List<Method>();
            Constructors = new List<Constructor>();
            Destructors = new List<Destructor>();
            Inheritance = new Inheritance();
            FunctionDefs = new List<Method>();
            StructPrototypes = new List<Struct>();
            ClassPrototypes = new List<Class>();
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
        /// inner classes
        /// </summary>
        public List<Class> Classes { get; set; }

        public List<Module> Modules { get; set; }

        /// <summary>
        /// List of enums
        /// </summary>
        public List<Enum> Enums { get; set; }

        /// <summary>
        /// List of Structs
        /// </summary>
        public List<Struct> Structs { get; set; }

        /// <summary>
        /// List of Unions
        /// </summary>
        public List<Union> Unions { get; set; }

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
        /// List of Delegates
        /// </summary>
        public List<Delegate> Delegates { get; set; }

        /// <summary>
        /// List of Function Definitions in a class
        /// </summary>
        public List<Method> FunctionDefs { get; set; }

        /// <summary>
        /// List of Struct Prototypes
        /// </summary>
        public List<Struct> StructPrototypes { get; set; }

        /// <summary>
        /// List of Class Prototypes
        /// </summary>
        public List<Class> ClassPrototypes { get; set; }

        /// <summary>
        /// List of Preprocessors
        /// </summary>
        public List<Preprocessor> Preprocessors { get; set; }

        /// <summary>
        /// List of Constructors
        /// </summary>
        public List<Constructor> Constructors { get; set; }

        /// <summary>
        /// List of Destructors
        /// </summary>
        public List<Destructor> Destructors { get; set; }

        /// <summary>
        /// List of inheritance stored during parsing
        /// </summary>
        public Inheritance Inheritance { get; set; }

        /// <summary>
        /// Returns an indication whether or not a given variable is an 
        /// instance variable of this class.
        /// </summary>
        /// <param name="v">A variable</param>
        /// <returns>True if it is an instance variable of this class, False otherwise</returns>
        public bool IsInstanceVariable(Model.Variables v)
        {
            bool rv = false;

            if (this.Fields.Contains(v))
            {
                rv = true;
            }

            return rv;
        }

        /// <summary>
        /// Used for debugging - Writes out all the types contained in the class
        /// </summary>
        /// <param name="indent"></param>
        /// <returns></returns>
        public override string Print(int indent)
        {
            string space = buildIndentation(indent);
            string rv = "";

            rv += space + "Class: " + Environment.NewLine;
            rv += space + "------ " + Environment.NewLine;
            rv += space + "  Type: " + getQualifer(Qualifiers) + Environment.NewLine;
            rv += space + "  Accessibility: " + getEncapsulation(Encapsulation) + Environment.NewLine;
            rv += space + "  Name: " + Name + Environment.NewLine;
            if (Enums != null)
            {
                rv += space + "  Enums: " + Environment.NewLine;
                foreach (Enum e in Enums)
                {
                    rv += e.Print(indent + 2) + Environment.NewLine;
                }
            }
            if (Structs != null)
            {
                rv += space + "  Structs: " + Environment.NewLine;
                foreach (Struct s in Structs)
                {
                    rv += s.Print(indent + 2) + Environment.NewLine;
                }
            }
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

            if (Constructors != null)
            {
                rv += space + "  Constructors: " + Environment.NewLine;
                foreach (Method c in Constructors)
                {
                    rv += c.Print(indent + 4) + Environment.NewLine;
                }
            }

            if (Destructors != null)
            {
                rv += space + "  Destructors: " + Environment.NewLine;
                foreach (Method d in Destructors)
                {
                    rv += d.Print(indent + 4) + Environment.NewLine;
                }
            }


            if (Inheritance.Count() != 0)
            {
                rv += space + "  Inherits: " + getStringList(Inheritance.UnkownInheritance) + Environment.NewLine;
            }

            if (Classes != null)
            {
                rv += space + "  Inner Classes:" + Environment.NewLine;
                foreach (Class c in Classes)
                {
                    rv += space + c.Print(indent + 2) + Environment.NewLine;
                }
            }

            return rv;
        }
    }
}
