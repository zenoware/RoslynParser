/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Description: The following code is a representation of Decisions	*/
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
	/// Class that holds the Conditions in the Data Structure
	/// </summary>
	public class Decisions
	{
		/// <summary>
		/// Constructor that sets all the Types so no lingering null types exist
		/// </summary>
		public Decisions()
		{
			IfStatements = new List<IfStatement>();
			ForStatements = new List<ForStatement>();
			ForEachStatements = new List<ForEachStatement>();
			WhileLoops = new List<WhileLoop>();
			DoWhileLoops = new List<DoWhileLoop>();
			Catches = new List<CatchStatements>();
			SwitchStatements = new List<SwitchStatement>();
            ElseStatements = new List<ElseStatement>();
		}
		/// <summary>
		/// List of If Statements
		/// </summary>
		public List<IfStatement> IfStatements { get; set; }

        public List<ElseStatement> ElseStatements { get; set; }
		/// <summary>
		/// List of For Statements
		/// </summary>
		public List<ForStatement> ForStatements { get; set; }
		/// <summary>
		/// List of Foreach Statments
		/// </summary>
		public List<ForEachStatement> ForEachStatements { get; set; }
		/// <summary>
		/// List of While Loops
		/// </summary>
		public List<WhileLoop> WhileLoops { get; set; }
		/// <summary>
		/// List of Do While Loops
		/// </summary>
		public List<DoWhileLoop> DoWhileLoops { get; set; }

		/// <summary>
		/// List of Catch Statements
		/// </summary>
		public List<CatchStatements> Catches { get; set; }

		/// <summary>
		/// List of switch statments - Do we need this?
		/// </summary>
		public List<SwitchStatement> SwitchStatements { get; set; }

		/// <summary>
		/// The Count of Decisions
		/// </summary>
		/// <returns>Decision Count</returns>
		public int Count()
		{
			return IfStatements.Count + ForStatements.Count + ForEachStatements.Count + WhileLoops.Count + DoWhileLoops.Count + Catches.Count + SwitchStatements.Count;
		}

        public void Add(BaseDecisions bd)
        {
            if (bd is IfStatement)
            {
                IfStatements.Add(bd as IfStatement);
            }
            else if (bd is ForStatement)
            {
                ForStatements.Add(bd as ForStatement);
            }
            else if (bd is ForEachStatement)
            {
                ForEachStatements.Add(bd as ForEachStatement);
            }
            else if (bd is WhileLoop)
            {
                WhileLoops.Add(bd as WhileLoop);
            }
            else if (bd is DoWhileLoop)
            {
                DoWhileLoops.Add(bd as DoWhileLoop);
            }
            else if (bd is CatchStatements)
            {
                Catches.Add(bd as CatchStatements);
            }
            else if (bd is SwitchStatement)
            {
                SwitchStatements.Add(bd as SwitchStatement);
            }
            else if (bd is ElseStatement)
            {
                ElseStatements.Add(bd as ElseStatement);
            }
        }
	}
}
