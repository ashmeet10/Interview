using System;

namespace Interview
{
    static class ExtensionClass
    {
        public static bool IsNullOrEmpty(this String strval)
        {
            return strval is null || strval == "Null" || strval == "NULL" || strval == "null" || strval.Length == 0;
        }
    }
}