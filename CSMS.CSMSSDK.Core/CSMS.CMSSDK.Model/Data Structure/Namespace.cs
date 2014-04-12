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
    /// Class that holds the Namespaces/Packages of the Data Structure
    /// </summary>
    public class Namespace : Base
    {
        /// <summary>
        /// Constructor that sets all the Types so no lingering null types exist
        /// </summary>
        public Namespace()
        {
            Preprocessors = new List<Preprocessor>();
            Qualifiers = new List<Model.Qualifiers>();
            UsingList = new List<UsingList>();
            Namespaces = new List<Namespace>();
            Interfaces = new List<Model.Interface>();
            Modules = new List<Module>();
            Classes = new List<Class>();
            Structs = new List<Struct>();
            Unions = new List<Union>();
            Enums = new List<Enum>();
            Attributes = new List<Variables>();
            Methods = new List<Method>();
            Delegates = new List<Delegate>();
            FunctionDefs = new List<Method>();
            StructPrototypes = new List<Struct>();
            ClassPrototypes = new List<Class>();
            Destructors = new List<Destructor>();
            Constructors = new List<Constructor>();
        }
        /// <summary>
        /// The name of the Namespace
        /// </summary>
        public string Name { get; set; }

        public List<Qualifiers> Qualifiers { get; set; }

        /// <summary>
        /// List of Preprocessors
        /// </summary>
        public List<Preprocessor> Preprocessors { get; set; }

        /// <summary>
        /// List of Using Lists
        /// </summary>
        public List<UsingList> UsingList { get; set; }

        /// <summary>
        /// List of Namespaces
        /// </summary>
        public List<Namespace> Namespaces { get; set; }

        /// <summary>
        /// list of interfaces
        /// </summary>
        public List<Interface> Interfaces { get; set; }


        public List<Module> Modules { get; set; }

        /// <summary>
        /// List of Classes
        /// </summary>
        public List<Class> Classes { get; set; }

        /// <summary>
        /// List of Structs
        /// </summary>
        public List<Struct> Structs { get; set; }

        /// <summary>
        /// List of Unions
        /// </summary>
        public List<Union> Unions { get; set; }

        /// <summary>
        /// List of Enums
        /// </summary>
        public List<Enum> Enums { get; set; }

        /// <summary>
        /// List of Attributes
        /// </summary>
        public List<Variables> Attributes { get; set; }

        /// <summary>
        /// List of Methods
        /// </summary>
        public List<Method> Methods { get; set; }

        /// <summary>
        /// List of Destructors
        /// </summary>
        public List<Destructor> Destructors { get; set; }

        /// <summary>
        /// List of Constructors
        /// </summary>
        public List<Constructor> Constructors { get; set; }

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
        /// Gets the Class Count
        /// </summary>
        /// <returns>Class Count</returns>
        public int Get_Class_Count()
        {
            return Classes.Count;
        }
        /// <summary>
        /// Used for debugging - Writes out all the types contained in the class
        /// </summary>
        /// <param name="indent"
        public override string Print(int indent)
        {
            string space = buildIndentation(indent);
            string rv = "";

            rv += space + "Namespace: " + Environment.NewLine;
            rv += space + "  Name: " + Name + Environment.NewLine;
            if (UsingList != null)
            {
                rv += "  Using Lists:" + Environment.NewLine;
                foreach (UsingList ul in UsingList)
                {
                    rv += ul.Print(indent + 2) + Environment.NewLine;
                }
            }
            if (Enums != null)
            {
                rv += space + "  Enums:" + Environment.NewLine;
                foreach (Enum e in Enums)
                {
                    rv += e.Print(indent + 2) + Environment.NewLine;
                }
            }
            if (Structs != null)
            {
                rv += space + "  Structs:" + Environment.NewLine;
                foreach (Struct s in Structs)
                {
                    rv += s.Print(indent + 2) + Environment.NewLine;
                }
            }
            if (Classes != null)
            {
                rv += space + "  Classes:" + Environment.NewLine;
                foreach (Class c in Classes)
                {
                    rv += c.Print(indent + 2) + Environment.NewLine;
                }
            }
            return rv;
        }
    }
}
