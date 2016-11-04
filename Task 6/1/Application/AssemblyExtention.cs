using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Application
{
    public static class AssemblyExtention
    {
        public static List<Type> GetTypesWithInterface(this Assembly assembly, Type interfaceType)
        {
            return assembly.GetTypes()
                .ToList()
                .FindAll(type => type.GetInterfaces().Contains(interfaceType));
        } 
    }
}
