using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
namespace MoodAnalyserApplication
{
    public class MoodAnalyserFactory
    {

        public static object CreateMoodAnalysis(string className,string constructorName)
        {
            string pattern=@"."+constructorName+"$";
            Match result = Regex.Match(className, pattern);

            if(result.Success)
            {
                try
                {
                    //  Type type = Type.GetType(className);
                    //  return type;

                    Assembly executing =Assembly.GetExecutingAssembly();
                    Type moodAnalysisType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalysisType);

                }
                catch(ArgumentNullException)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "constructor is not found");
            }
        }

    }
}
