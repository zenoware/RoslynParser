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
	/// Class that holds Inheritance and type of Inheritance of the Data Structure
	/// </summary>
	public class Inheritance
	{
		/// <summary>
		/// Constructor that sets all the Types so no lingering null types exist
		/// </summary>
		public Inheritance()
		{
			UnkownInheritance = new List<string>();
			Class = new List<Class>();
			Interface = new List<Interface>();
		}
		/// <summary>
		/// Default Inheritance as string
		/// </summary>
		public List<string> UnkownInheritance { get; set; }

		/// <summary>
		/// Class based inheritance
		/// </summary>
		public List<Class> Class { get; set; }

		/// <summary>
		/// Interface Inheritance
		/// </summary>
		public List<Interface> Interface { get; set; }

		/// <summary>
		/// Total count of Inheritance
		/// </summary>
		/// <returns>Total Inheritance Count</returns>
		public int Count()
		{
			return UnkownInheritance.Count + Class.Count + Interface.Count;
		}

		/// <summary>
		/// Count of Class Inheritance
		/// </summary>
		/// <returns>Class Inheritance Count</returns>
		public int ClassCount()
		{
			return Class.Count;
		}

		/// <summary>
		/// Count of Interface Inheritance
		/// </summary>
		/// <returns>Interface Inheritance Count</returns>
		public int InterfaceCount()
		{
			return Interface.Count;
		}

		/// <summary>
		/// Count of Unkown Inheritances
		/// </summary>
		/// <returns>Unkown Interitance Count</returns>
		public int UnkownCount()
		{
			return UnkownInheritance.Count;
		}
	}
}
