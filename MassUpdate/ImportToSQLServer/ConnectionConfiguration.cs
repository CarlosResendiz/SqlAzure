using System;
using System.Collections.Generic;
using System.Text;

namespace ImportToSQLServer
{
    public class ConnectionConfiguration
    {
        public string TargetServerName { get; set; }
        public string SourceDirectory { get; set; }
        public string DatabasesTextFileName { get; set; }

    }
}
