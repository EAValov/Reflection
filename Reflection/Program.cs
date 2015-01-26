using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            while (!String.IsNullOrWhiteSpace(path = Console.ReadLine().Trim().ToLower()))
            {
                GetDLLDescription(path);
            }
        }

        static void GetDLLDescription(string path)
        {
            List<String> Dlls = new List<string>();

            Dlls.AddRange(Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".dll") || s.EndsWith(".DLL")));

            foreach (var dll in Dlls)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(dll);

                    foreach (var type in assembly.GetTypes())
                    {
                        Console.WriteLine(type.Name); //class name
                        foreach (var Method in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                        {
                            if (Method.IsFamily || Method.IsPublic) //check for public and prodected methods
                            Console.WriteLine("-> {0}", Method.Name);
                        }
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Something go wrong with {0}", dll);
                    throw;
                }
            }
        }
    }


}
