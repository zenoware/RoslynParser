/********************************************************************/
/* Author: Jason Pugh											    */
/* Date: © 3/13/2013  												*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.			    */
/********************************************************************/

namespace CSMS.CSMSSDK.Model
{
    /// <summary>
    /// Holds abilities while parsing
    /// </summary>
    public class ControlParser
    {
        private static ControlParser mInstance;

        private ControlParser()
        {
            NumAllowed = 20;
        }

        public static ControlParser Instance()
        {
            if (mInstance == null)
            {
                mInstance = new ControlParser();
            }
            return mInstance;
        }
        
        /// <summary>
        /// Stops the Parser
        /// </summary>
        public bool Stopped { get; set; }

        /// <summary>
        /// Number of errors allowed before ditching the file
        /// </summary>
        public int NumAllowed { get; set; }
    }
}
