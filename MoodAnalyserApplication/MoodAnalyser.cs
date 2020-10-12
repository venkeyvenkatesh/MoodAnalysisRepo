using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserApplication
{
    public class MoodAnalyser
    {
        //
        private string message;
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserApplication.MoodAnalysisException">
        /// string should not be empty
        /// or
        /// string should not be null
        /// </exception>
        public string AnalyseMood()

        {
            if (this.message.Contains("happy"))
            {
                return "happy";
            }
            else
            {
                return "sad";
            }

        }




    }
}

