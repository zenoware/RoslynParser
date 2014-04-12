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
    public class Property
    {
        public Property()
        {
            Encapsulation = new List<Model.Encapsulation>();
            Qualifers = new List<Qualifiers>();
            Type = new Model.Type();

            Getter = new Method();
            Setter = new Method();
            
        }

        public string Name { get; set; }
        public List<Encapsulation> Encapsulation { get; set; }
        public List<Qualifiers> Qualifers { get; set; }
        public Type Type { get; set; }

        public Method Getter { get; set; }
        public Method Setter { get; set; }
    }
}
