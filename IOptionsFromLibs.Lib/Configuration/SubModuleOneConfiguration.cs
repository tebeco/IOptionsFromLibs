using System;

namespace IOptionsFromLibs.Lib.Configuration
{
    public class SubModuleOneConfiguration
    {
        public BackendConfiguration[] Backends { get; set; } = Array.Empty<BackendConfiguration>();
    }

    public class BackendConfiguration
    {
        public string Name { get; set; }
        public Uri endpoint { get; set; }
    }
}
