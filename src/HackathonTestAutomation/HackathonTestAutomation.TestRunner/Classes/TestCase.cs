using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace HackathonTestAutomation.TestRunner.Classes
{
    public class TestCase
    {
        [DisplayName("Execute")]
        [Browsable(true)]
        public bool ShouldRun { get; set; }
        [Browsable(true)]
        public string Description { get; set; }
        [Browsable(true)]
        public List<MethodInfo> Methods { get; set; }

        public string Method { get; set; }

        [Browsable(true)]
        public string Class { get; set; }

        public TestCase(bool shouldRun, string description, string method, string @class)
        {
            ShouldRun = shouldRun;
            Description = description;
            Method = method;
            Class = @class;
        }

        public TestCase(string description, List<MethodInfo> methods, string @class)
        {
            Description = description;
            Methods = methods;
            Class = @class;
        }

        public TestCase()
        {

        }

        public List<string> getClassName()
        {

            char[] text = Class.ToCharArray();

            List<int> indexes = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.')
                {
                    indexes.Add(i + 1);
                }
            }

            List<string> names = new List<string>();

            //string[] names = null ;

            int itNb = 0;

            for (int i = 0; i < indexes.Count; i++)
            {
                if ((i + 1) <= indexes.Count)
                {
                    if (i == 0)
                    {
                        names.Add(Class.Substring(0, indexes[i] - 1));
                    }
                    else
                    {
                        int len = Class.Length;
                        string test = Class.Substring((indexes[i - 1]), (indexes[i] - indexes[i - 1] - 1));
                        // string s = this.Class.Substring(indexes[i] - 1, indexes[i + 1] - 1);
                        //  names.Add(Class.Substring(25, 29)) ;   

                        names.Add(test);
                        // names.Add(this.Class.Substring(indexes[i]+1, indexes[i+1]-1));
                    }
                    //names[i] = text
                    //names[i] = Class.Substring(indexes[i], indexes[i + 1]);
                }

                if (i == indexes.Count - 1)
                {
                    string test = Class.Substring((indexes[i]), (Class.Length) - indexes[i]);
                    names.Add(test);
                }
            }

            // string className = Class.Substring(lastDotIndex+1, Class.Length);

            //return className;
            return names;
        }
    }
}
