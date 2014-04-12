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
    /// Holds information on Delegates
    /// </summary>
    public class Delegate : Base
    {
        /// <summary>
        /// Delegate public constructor
        /// </summary>
        public Delegate()
        {
            Encapsulation = new List<Encapsulation>();
            ReferencedMethods = new List<Method>();
            IsEvent = false;
        }

        /// <summary>
        /// Delegates Encapsulation
        /// </summary>
        public List<Encapsulation> Encapsulation { get; set; }

        /// <summary>
        /// Referenced Method (or atleast its information)
        /// </summary>
        public List<Method> ReferencedMethods { get; set; }

        /// <summary>
        /// If its an event or not
        /// </summary>
        public bool IsEvent { get; set; }

        /// <summary>
        /// public override - Implemented for Testing
        /// </summary>
        /// <param name="indent"></param>
        /// <returns></returns>
        public override string Print(int indent)
        {
            return "";
        }
    }
}
