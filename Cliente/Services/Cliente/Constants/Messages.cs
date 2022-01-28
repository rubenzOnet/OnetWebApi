using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Cliente.Services.Cliente.Constants
{
    internal struct Messages
    {
        internal struct Client
        {
            internal const string OK = "Client List";
            internal const string EX = "Unexpected error when trying to register a new user";
            internal const string Create = "The client was created successfullly";
            internal const string NotExists = "The client doesn.t exists";
        }

    }
}
