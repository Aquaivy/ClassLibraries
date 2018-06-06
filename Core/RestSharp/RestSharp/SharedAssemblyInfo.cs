using System;
using System.Reflection;
using RestSharp;



namespace RestSharp
{
    internal class SharedAssemblyInfo
    {
#if SIGNED
        public const string VERSION = "100.0.0";
        public const string FILE_VERSION = "105.2.3";
#else
        public const string VERSION = "105.2.3";
#endif
    }
}
