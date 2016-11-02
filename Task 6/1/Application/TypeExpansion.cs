using System;

namespace Application
{
    public static class TypeExpansion
    {
        public static Object InitilizateUsingEmptyConstructor(this Type type)
        {
            var constructorInfo = type.GetConstructor(new Type[] { });

            if (constructorInfo == null)
                throw new Exception("Type has no empty constructor.");

            return constructorInfo.Invoke(new Object[] { });
        }
    }
}
