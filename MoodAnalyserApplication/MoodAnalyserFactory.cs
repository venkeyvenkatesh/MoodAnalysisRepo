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

        public static object CreateMoodAnalysisUsingParamsCtor(string className,string constructorName,string message)
        {

            Type type = typeof(MoodAnalyser);


            if(type.Name.Equals(className)|| type.FullName.Equals(className))
            {
                if(type.Name.Equals(constructorName))
                {


                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                    //Type type = Type.GetType(className);
                    //return type;

                  //Assembly executing =Assembly.GetExecutingAssembly();
                  //Type moodAnalysisType = executing.GetType(className);
                 //return Activator.CreateInstance(moodAnalysisType);

                }
            else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "class is not found");
            }
        }

    }
}
