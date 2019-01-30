using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Common;

namespace Calculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var plugins = new Dictionary<int, ICalculator>();
            const string pluginFolder = @"C:\Plugin";
            var allFiles = Directory.GetFiles(pluginFolder);

            var index = 0;
            foreach (var file in allFiles)
            {
                var asm = Assembly.LoadFile(file);
                var classType = asm.GetTypes().FirstOrDefault(x => typeof(ICalculator).IsAssignableFrom(x));
                if (classType != null)
                {
                    var classInstance = Activator.CreateInstance(classType) as ICalculator;
                    index++;
                    plugins.Add(index, classInstance);
                }
            }

            Console.Clear();
            Console.Write("Enter value #1 :");
            var value1 = int.Parse(Console.ReadLine());
            Console.Write("Enter value #2 :");
            var value2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose an option:");

            foreach (var plugin in plugins) Console.WriteLine($"{plugin.Key}) {plugin.Value.Name}");

            var option = int.Parse(Console.ReadLine());
            var instance = plugins[option];
            Console.WriteLine($"The result is {instance.Calculate(value1, value2)}");
            Console.ReadKey();
        }
    }
}