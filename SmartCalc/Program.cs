using System;
using System.Linq;
using System.Reflection;

namespace AssemblyLoader
{
    class AssemblyLoader
    {
        static void Main(string[] args)
        {
            try
            {
                const string extensionPath = @"C:\";

                //Load Assembly from file
                Assembly assembly = Assembly.LoadFrom(extensionPath + "Test1.dll");
                DisplayAssembly(assembly);
                CreateInstance(assembly);

            }
            catch
            {
                Console.WriteLine("Can't Load Assembly");
            }
            Console.ReadKey();

            static void DisplayAssembly(Assembly a)
            {

                Console.WriteLine("Assembly Info");
                Console.WriteLine("============================================");
                Console.WriteLine("Name:{0}", a.GetName().Name);
                Console.WriteLine("Version:{0}", a.GetName().Version);
                Console.WriteLine("Culture:{0}", a.GetName().CultureInfo.DisplayName);
                Console.WriteLine("Loaded from GAC?:{0}", a.GlobalAssemblyCache);
            }

            static void CreateInstance(Assembly a)
            {
                //  Get Type and Create Instance
                try
                {
                    var type = a.GetType("Test1.SmartCalc");
                    dynamic obj = Activator.CreateInstance(type);
                    Console.WriteLine("Create a {0} using late binding", type);

                    //Get public property “newNumber” info and value, and then set it to 9.
                    obj.newNumber = 9;

                    Console.WriteLine("newNumber Value is {0}", obj.newNumber);
                }

                catch
                {
                    Console.WriteLine("Can't Create Assembly Instance");
                }
                Console.ReadKey();

            }
        }
    }

}

