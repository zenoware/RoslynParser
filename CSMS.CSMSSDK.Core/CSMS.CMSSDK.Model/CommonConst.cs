/********************************************************************/
/* Author: Jason Pugh																								*/
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
	/// Holder for the Parsing Results
	/// </summary>
    public enum ParsingResults
    {
			/// <summary>
			/// Successful Parse
			/// </summary>
        Success,
			/// <summary>
			/// Failed Parse
			/// </summary>
        Fail,
			/// <summary>
			/// Error Parsing
			/// </summary>
        Errors
    };

	/// <summary>
	/// Holder for the Source Type
	/// </summary>
    public enum SourceType
    {
        /// <summary>
        /// C#
        /// </summary>
        CSharp = 0,
        /// <summary>
        /// Java
        /// </summary>
        Java = 1,
        /// <summary>
        /// C
        /// </summary>
        C = 2,
        /// <summary>
        /// C++
        /// </summary>
        CPP = 3,
        /// <summary>
        /// Visual Basic
        /// </summary>
        VB = 4
    }

	/// <summary>
	/// Holder for the types of Encapsulation
	/// </summary>
    public enum Encapsulation
    {
        Private,
        Protected,
        Public,
        Internal,
        Friend,
    };

	/// <summary>
	/// Holder for the types of Qualifiers
	/// </summary>
    public enum Qualifiers
    {
        Abstract,
        Auto,
        Register,
        Extern,
        New,
        Native,
        Synchronized,
        Transient,
        Override,
        Partial,
        Readonly,
        Sealed,
        Final,
        Static,
        Unsafe,
        Virtual,
        Volatile,
        Const,
        Typedef,
        Inline,
        Explicit,
        Mutable,
        Thread_Local,
        __Thread,
        Byval,
        Dim
    };

	/// <summary>
	/// Determines what ribbon bar tab should be visible
	/// </summary>
		public enum RibbonTab
		{
			Navigation,
			Metrics
		}

	/// <summary>
	/// Metric Scripts Check State from Main Form
	/// </summary>
		public enum MetricScriptCheckedState
		{
			All,
			None
		}

#region Not Used
	///// <summary>
	///// class that holds the syntax for a 'mini-parser' so text can be highlighted on the RichTextBox
	///// </summary>
	//  public class Syntax
	//  {
	//      private static List<string> keywordList;
	//      private static List<char> specials;

	//      static Syntax()
	//      {
	//          //TODO: Move to another location at some point
	//      char[] chrs = {
	//              '.',
	//              ')',
	//              '(',
	//              '[',
	//              ']',
	//              '>',
	//              '<',
	//              ':',
	//              ';',
	//              '\n',
	//              '\t'
	//          };

	//      string[] keywords = { "abstract", "as", "base", "bool", "break", "by", "byte", "case", "catch", "char", "checked", "class",
	//                              "const", "continue", "decimal", "default", "delegate", "do", "double", "descending", "explicit", "event",
	//                              "extern", "else", "enum", "false", "finally", "fixed", "float", "for", "foreach", "from", "goto", "group",
	//      "if", "implicit", "in", "int", "interface", "internal", "into", "is", "lock", "long", "new", "null", "namespace", "object", "operator",
	//      "out", "override", "orderby", "params", "private", "protected", "public", "readonly", "ref", "return", "switch", "struct", "sbyte", 
	//      "sealed", "short", "sizeof", "stackalloc", "static", "string", "select", "this", "throw", "true", "try", "typeof", "uint", "ulong", 
	//      "unchecked", "unsafe", "ushort", "using", "var", "virtual", "volatile", "void", "while", "where", "yield"};

	//      keywordList = new List<string>(keywords);
	//      specials = new List<char>(chrs);
	//      }

	//      public static List<char> Specials
	//      {
	//          get { return specials; }
	//      }

	//      public static bool IsKnownTag(string tag)
	//      {
	//          return keywordList.Exists(delegate(string s){return s.Equals(tag);});
	//      }
		//  }
#endregion
	}
