using System;
using System.Linq;
using DataAccessLayer.Models;

namespace TransformConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = new Converter().ToInsertConvert(typeof(User));

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == "DataAccessLayer.Models").ToArray();

            

            foreach (var type in types)
            {
                Console.WriteLine(new Converter().ToInsertConvert(type));
            }
        }
    }
}
