using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Framework;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryLocation = "C:\\Users\\Вадим\\Desktop\\ПРОГИ\\GIT курсы по C#\\Task 6\\1";
            
            var directoryInfo = new DirectoryInfo(directoryLocation);

            var dllFiles = directoryInfo.GetUniqueDllFiles();

            var frameworkDllFile = dllFiles.Find(file => file.Name == "Framework.dll");
            dllFiles.Remove(frameworkDllFile);
            
            List<Type> typesOfPlugins =
                dllFiles.SelectMany(
                    file =>
                        Assembly.LoadFrom(file.FullName)
                            .GetTypesWithInterface(typeof (IPlugin)))
                    .ToList();

            List<IPlugin> plugins = typesOfPlugins.Select(
                type =>
                    (IPlugin) type.InitilizateUsingEmptyConstructor())
                .ToList();

            plugins.ForEach(plugin => Console.WriteLine(plugin.Name));
        }
    }
}
