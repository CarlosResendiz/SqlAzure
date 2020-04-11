using System;
using System.Collections.Generic;
using System.Text;

namespace ExportAzureToBacpac
{
    public class ConnectionConfiguration
    {
        public string SourceServerName { get; set; }
        public string SourceEncryptConnection { get; set; }
        public string TargetDirectory { get; set; }
        public string SourceUser { get; set; }
        public string SourcePassword { get; set; }
        public string DatabasesTextFileName { get; set; }
    }
}
