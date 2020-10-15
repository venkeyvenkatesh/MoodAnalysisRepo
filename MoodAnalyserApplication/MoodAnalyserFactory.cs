using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace MoodAnalyserApplication
{
    public class MoodAnalyserFactory
    {

        public static object CreateMoodAnalysisUsingParamsCtor(string className, string constructorName, string message)
        {

            Type type = typeof(MoodAnalyser);

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {

                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;

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

        public static string InvokeAnalyseMoodMethod(string message, string methodName)
        {
            try
            {

                Type type = Type.GetType("MoodAnalyserApplication.MoodAnalyser");

                object MoodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalysisUsingParamsCtor(type.FullName, type.Name, message);

                MethodInfo method = type.GetMethod(methodName);
                object instance = method.Invoke(MoodAnalyserObject, null);
                return instance.ToString();

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Method not found");
            }
        }


        public static string SetField(string message, string fieldName)
        {
            try
            {
                if(message==null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ENTERED_NULL, "string should not be null");
                }
                MoodAnalyser obj = new MoodAnalyser();

                Type type = Type.GetType("MoodAnalyserApplication.MoodAnalyser");

                FieldInfo field = type.GetField(fieldName);

                field.SetValue(obj, message);
                return obj.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }

        }
    }
}
