using System;
using System.Collections.Generic;
using System.Text;

namespace Ingaia.Data.Context
{
    public class ServerConfig
    {
        public MongoDbConfig MongoDB { get; set; } = new MongoDbConfig();
    }
}
