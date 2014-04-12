/********************************************************************/
/* Author: Jason Pugh												*/
/* Date: © 05/18/2011  												*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.				*/
/********************************************************************/


namespace CSMS.CSMSSDK.Model
{
	/// <summary>
	/// Status info pushed to main form
	/// </summary>
	public class StatusUpdate
	{
		/// <summary>
		/// The Progress amount ( 1 - 100 )
		/// </summary>
		public double Progress { get; set; }

		/// <summary>
		/// Name of what is being pushed
		/// </summary>
		public string StatusName { get; set; }
	}
}
