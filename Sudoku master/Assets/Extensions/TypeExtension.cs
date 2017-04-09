using System;
using System.Reflection;

namespace Catalyst.Core.Utility
{
    public static class TypeExtension
    {
        /// <summary>
        ///     Fetch the existing assemblies and their types
        ///     to find the first matching <paramref name="name" />
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Type GetTypeByName(string name)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.Name == name)
                        return type;
                }
            }

            return null;
        }

        /// <summary>
        ///     Returns the nearest parent class that is generic.
        /// </summary>
        public static Type GetBaseGenericType(this Type type)
        {
            if (type.IsGenericType)
                return type;

            if (type.BaseType == null)
                return null;

            return type.BaseType.GetBaseGenericType();
        }
    }
}
