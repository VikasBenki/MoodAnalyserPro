using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserPro.Reflection
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// Create MoodAnalyserreflector and specify static method to create MoodAnalyser Object
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyzerException"></exception>
        /// 
        public object CreateMoodMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (ArgumentNullException)
                {

                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD, "Constructor not found");
            }
        }

        //UC5 - Using Reflection Create MoodAnalyser with parameter constructor
        public object CreateMoodMoodAnalyserParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(AnalyzeMood);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD, "Could not find constructor");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_CLASS, "Could not find class");
            }
        }
        //UC6 - Use Reflector to invoke MoodAnalyzer method 
        public string InvokeAnalyzeMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(AnalyzeMood);
                MethodInfo methodInfo = type.GetMethod(methodName);
                MoodAnalyserReflector reflector = new MoodAnalyserReflector();
                object moodAnalyserObject = reflector.CreateMoodMoodAnalyserParameterObject("MoodAnalyserPro.AnalyzeMood", "AnalyzeMood", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException)
            {

                throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD, "Method not found");
            }
        }
        //UC7 - Method to change mood dynamically (Set field value)
        public string SetField(string message, string fieldName)
        {
            try
            {
                AnalyzeMood analyse = new AnalyzeMood();
                Type type = typeof(AnalyzeMood);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.EMPTY_MESSAGE, "Message should not be null");
                }
                fieldInfo.SetValue(analyse, message);
                return analyse.message;
            }
            catch (NullReferenceException)
            {

                throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_FIELD, "Field not found");
            }
        }
    }
}
