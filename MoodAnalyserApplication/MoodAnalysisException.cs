using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserApplication
{
  public class MoodAnalysisException:ApplicationException
    {
        public enum ExceptionType
        {
            ENTERED_NULL, ENTERED_EMPTY
        }

        public ExceptionType type;

        public MoodAnalysisException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
