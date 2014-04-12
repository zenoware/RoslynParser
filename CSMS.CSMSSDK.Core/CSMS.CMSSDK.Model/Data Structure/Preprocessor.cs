/********************************************************************/
/* Author: Jason Pugh											    */
/* Date: © 3/13/2013  												*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.			    */
/********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSMS.CSMSSDK.Model
{
    /// <summary>
    /// Holds the Pre Processor information for a given source
    /// </summary>
    public class Preprocessor : Base
    {
        public Preprocessor()
        {
            Includes = new List<UsingList>();
            Macros = new List<Method>();
            VarDefines = new List<Variables>();
            ClassDefines = new List<Class>();
            EnumDefines = new List<Enum>();
            StructDefines = new List<Struct>();
        }

        public List<UsingList> Includes { get; set; }
        public List<Model.Method> Macros { get; set; }
        public List<Model.Variables> VarDefines { get; set; }
        public List<Model.Class> ClassDefines { get; set; }
        public List<Model.Struct> StructDefines { get; set; }
        public List<Model.Enum> EnumDefines { get; set; }

        public override string Print(int indent)
        {
            //throw new NotImplementedException();
            return "PreProcessor";
        }
    }
}
