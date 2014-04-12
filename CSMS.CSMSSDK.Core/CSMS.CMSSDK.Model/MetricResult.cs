/********************************************************************/
/* Author: Jason Pugh												*/
/* Date: © 05/18/2011  												*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.			    */
/********************************************************************/


using System;
namespace CSMS.CSMSSDK.Model
{
    /// <summary>
    /// Data Context for Metric Results List View
    /// </summary>
    public class MetricResults
    {
        private string mMetricsName;
        private string mCalculatedOn;
        private float mValue;
        private bool mHighlighted;
        private string mSource;
        private DateTime mLastModified;

        public MetricResults()
        {
            mMetricsName = "";
            mCalculatedOn = "";
            mValue = 0;
            mHighlighted = false;
            mSource = "";
            mLastModified = DateTime.Now;
        }
        /// <summary>
        /// The Metrics Name
        /// </summary>
        public string MetricsName
        {
            get
            {
                return mMetricsName;
            }
            set
            {
                if (value != mMetricsName)
                {
                    UpdateLastModified();
                    mMetricsName = value;
                }
            }
        }

        /// <summary>
        /// What the Metrics was Calculated on (Class, Interface, etc)
        /// </summary>
        public string CalculatedOn
        {
            get
            {
                return mCalculatedOn;
            }
            set
            {
                if (value != mCalculatedOn)
                {
                    UpdateLastModified();
                    mCalculatedOn = value;
                }
            }
        }

        /// <summary>
        /// The Metrics numerical value
        /// </summary>
        public float Value
        {
            get
            {
                return mValue;
            }
            set
            {
                if (value != mValue)
                {
                    UpdateLastModified();
                    mValue = value;
                }
            }
        }

        /// <summary>
        /// Highlights where the Metrics occurs
        /// </summary>
        public bool Highlighted
        {
            get
            {
                return mHighlighted;
            }
            set
            {
                if (value != mHighlighted)
                {
                    UpdateLastModified();
                    mHighlighted = value;
                }
            }
        }

        /// <summary>
        /// The Source which is being calculated
        /// </summary>
        public string Source
        {
            get
            {
                return mSource;
            }
            set
            {
                if (value != mSource)
                {
                    UpdateLastModified();
                    mSource = value;
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
