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
  public class ListInfo
  {

    public ListInfo()
    {
      ListOptions = new List<string>();
    }

    /// <summary>
    /// 
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Class { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> ListOptions { get; set; }
  }
}
