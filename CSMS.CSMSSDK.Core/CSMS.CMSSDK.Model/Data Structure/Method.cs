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
    /// A Constructor - Inherits <see cref="Method"/>
    /// </summary>
    public class Constructor : Method
    {
        public Constructor()
            : base()
        {
            Root = "";
        }
        /// <summary>
        /// Most likely only for C/C++ but this holds the parent of the constructor
        /// </summary>
        public string Root { get; set; }
    }

    /// <summary>
    /// A Destructor - Inherits <see cref="Method"/>
    /// </summary>
    public class Destructor : Method
    {
        public Destructor()
            : base()
        {
            Root = "";
        }

        /// <summary>
        /// Most likely only for C/C++ but this holds the parent of the descructor
        /// </summary>
        public string Root { get; set; }
    }

    /// <summary>
    /// Class that holds the Methods of the Data Structure
    /// </summary>
    public class Method : Base
    {
        private List<Variables> mAccessedVariables;
        /// <summary>
        /// Constructor that sets all the Types so no lingering null types exist
        /// </summary>
        public Method()
        {
            Preprocessors = new List<Preprocessor>();
            Encapsulation = new List<Encapsulation>();
            Base = new List<InvokedMethod>();
            ReturnType = new Type();
            Qualifiers = new List<Qualifiers>();
            Parameters = new List<Variables>();
            Decisions = new Decisions();
            AccessedVariables = new List<Variables>();
            LabelStatements = new List<LabelStatement>();
            GoToStatements = new List<GoTo>();
            InvokedMethods = new List<InvokedMethod>();
        }
        /// <summary>
        /// The accessability of the Class
        /// </summary>
        public List<Encapsulation> Encapsulation { get; set; }

        /// <summary>
        /// Name of the Method
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Method Return Type
        /// </summary>
        public Type ReturnType { get; set; }

        /// <summary>
        /// List of Preprocessors
        /// </summary>
        public List<Preprocessor> Preprocessors { get; set; }

        /// <summary>
        /// Qualifiers
        /// </summary>
        public List<Qualifiers> Qualifiers { get; set; }

        /// <summary>
        /// Parameters
        /// </summary>
        public List<Variables> Parameters { get; set; }

        /// <summary>
        /// Decisions in a method
        /// </summary>
        public Decisions Decisions { get; set; }

        /// <summary>
        /// Number of Decisions in the method
        /// </summary>
        public int DecisionsCount
        {
            get
            {
                return Decisions.Count();
            }
        }

        /// <summary>
        /// Holds a list of base methods (for constructors only and C/C++)
        /// </summary>
        public List<InvokedMethod> Base { get; set; }

        bool mProcessOnce = false;
        /// <summary>
        /// List of Attributes accessed in the Method
        /// </summary>
        public List<Variables> AccessedVariables {
            get
            {
                return mAccessedVariables;
            }
            set
            {
                mAccessedVariables = value;
            }
        }

        public void GrabAllAccessedVars()
        {
            List<Variables> allVars = new List<Variables>();
            foreach (BaseDecisions bd in Decisions.IfStatements)
            {
                allVars.AddRange(bd.AccessedVars);
            }
            foreach (BaseDecisions bd in Decisions.ElseStatements)
            {
                allVars.AddRange(bd.AccessedVars);
            }
            foreach (BaseDecisions bd in Decisions.ForStatements)
            {
                allVars.AddRange(bd.AccessedVars);
            }
            foreach (BaseDecisions bd in Decisions.ForEachStatements)
            {
                allVars.AddRange(bd.AccessedVars);
            }
            foreach (BaseDecisions bd in Decisions.WhileLoops)
            {
                allVars.AddRange(bd.AccessedVars);
            }
            foreach (BaseDecisions bd in Decisions.DoWhileLoops)
            {
                allVars.AddRange(bd.AccessedVars);
            }
            foreach (InvokedMethod im in InvokedMethods)
            {
                allVars.AddRange(im.Parameters);
            }
            foreach (BaseDecisions bd in Decisions.SwitchStatements)
            {
                SwitchStatement switchStm = bd as SwitchStatement;
                foreach (CaseStatement cs in switchStm.CaseStatements)
                {
                    allVars.AddRange(cs.AccessedVars);
                }
            }
            mAccessedVariables.AddRange(allVars);
        }

        /// <summary>
        /// List of Labeled Statements
        /// </summary>
        public List<LabelStatement> LabelStatements { get; set; }

        /// <summary>
        /// Go To Statements
        /// </summary>
        public List<GoTo> GoToStatements { get; set; }

        /// <summary>
        /// List of invoked methods
        /// </summary>
        public List<InvokedMethod> InvokedMethods { get; set; }

        /// <summary>
        /// Number of exit points (returns)
        /// </summary>
        public int ExitPoints { get; set; }

        /// <summary>
        /// Indicates whether or not the method is static.
        /// </summary>
        /// <returns>True if static, false otherwise</returns>
        public bool IsStatic
        {
            get
            {
                bool rv = false;
                if (Qualifiers != null)
                {
                    rv = Qualifiers.Contains(Model.Qualifiers.Static);
                }
                return rv;
            }
        }

        /// <summary>
        /// Indicates whether or not the method is public.
        /// </summary>
        /// <returns>True if public, false otherwise</returns>
        public bool IsPublic
        {
            get
            {
                bool rv = false;
                if (Encapsulation != null)
                {
                    rv = Encapsulation.Contains(Model.Encapsulation.Public);
                }
                return rv;
            }
        }

        /// <summary>
        /// Indicates whether or not this method is a "friend".  Only valid for 
        /// C++; returns false in all cases currently.
        /// </summary>
        public bool IsFriend
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Indicates whether or not the method is static.
        /// </summary>
        /// <returns>True if static, false otherwise</returns>
        public bool IsPolymophic
        {
            get
            {
                bool rv = false;
                if (Qualifiers != null)
                {
                    rv = Qualifiers.Contains(Model.Qualifiers.Virtual) || Qualifiers.Contains(Model.Qualifiers.Abstract);
                }
                return rv;
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


            step = space + "Method: " + Environment.NewLine;
            rv += step;
            step = space + "-------" + Environment.NewLine;
            rv += step;
            step = space + "  Accessibility: " + getEncapsulation(Encapsulation) + Environment.NewLine;
            rv += step;
            step = space + "  Qualifiers: " + getQualifer(Qualifiers) + Environment.NewLine;
            rv += step;
            step = space + "  Return Type: " + ReturnType.Name + Environment.NewLine;
            rv += step;
            step = space + "  Name: " + Name + Environment.NewLine;
            rv += step;
            step = space + "  Number of Decisions: " + DecisionsCount + Environment.NewLine;
            rv += step;
            step = space + "  Number of Exits: " + ExitPoints + Environment.NewLine;
            rv += step;
            step = space + "  Parameters:" + Environment.NewLine;
            rv += step;
            step = getVariableList(this.Parameters, indent + 2);
            rv += step;
            step = space + "  Accessed Attributes:" + Environment.NewLine;
            rv += step;
            step = getVariableList(this.AccessedVariables, indent + 2);
            rv += step;
            step = space + "  Invoked Methods:" + Environment.NewLine;
            rv += step;
            step = getInovkedMethodInfo(InvokedMethods, indent + 2);
            rv += step;

            return rv;
        }
    }
}
