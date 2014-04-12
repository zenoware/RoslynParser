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
using System.Windows.Media;

namespace CSMS.CSMSSDK.Model
{
	/// <summary>
	/// Class that holds the Output information for the Output List View in MetricScripts.cs
	/// </summary>
	public class Output
	{
		/// <summary>
		/// The Type Enumeration Value
		/// </summary>
		public OutputType TypeEnum { get; set; }

        /// <summary>
        /// The string representation of the Type
        /// </summary>
        public string Type
        {
            get
            {
                return TypeEnum.ToString();
            }
        }

        /// <summary>
        /// The File Name
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Path of the File associated with the Error
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Image Source
        /// </summary>
        public ImageSource Image { get; set; }

		/// <summary>
		/// Message of the Output
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Line Number
		/// </summary>
		public int LineNumber { get; set; }

		/// <summary>
		/// Column Number
		/// </summary>
		public int ColumnNumber { get; set; }

		/// <summary>
		/// Position
		/// </summary>
		public int Position { get; set; }
	}

    public enum OutputType
    {
        Information,
        Error,
        Warning
    }
}
