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
    /// Holder for Sources - Data Context for List View Sources
    /// </summary>
    public class Sources
    {
        private string mName;
        private string mType;
        private bool mParsed;
        private string mPath;
        private bool mAttachedToTrend;
        private DateTime mLastModified;

        public Sources()
        {
            mName = "";
            mType = "";
            mParsed = false;
            mPath = "";
            mAttachedToTrend = false;
            mLastModified = DateTime.Now;
        }
        /// <summary>
        /// Source Name
        /// </summary>
        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                if (value != mName)
                {
                    UpdateLastModified();
                    mName = value;
                }
            }
        }
        /// <summary>
        /// Source Type (C++, C#, Java)
        /// </summary>
        public string Type
        {
            get
            {
                return mType;
            }
            set
            {
                if (value != mType)
                {
                    UpdateLastModified();
                    mType = value;
                }
            }
        }
        /// <summary>
        /// Is the Source Parsed
        /// </summary>
        public bool Parsed
        {
            get
            {
                return mParsed;
            }
            set
            {
                if (value != mParsed)
                {
                    UpdateLastModified();
                    mParsed = value;
                }
            }
        }
        /// <summary>
        /// The full path of the source
        /// </summary>
        public string Path
        {
            get
            {
                return mPath;
            }
            set
            {
                if (value != mPath)
                {
                    UpdateLastModified();
                    mPath = value;
                }
            }
        }
        /// <summary>
        /// Boolean to hold if this source is attached to a trend.
        /// </summary>
        public bool AttachedToTrend
        {
            get
            {
                return mAttachedToTrend;
            }
            set
            {
                if (value != mAttachedToTrend)
                {
                    UpdateLastModified();
                    mAttachedToTrend = value;
                }
            }
        }

        public DateTime LastModified { get { return mLastModified; } }

        private void UpdateLastModified()
        {
            mLastModified = DateTime.Now;
        }
    }
}
