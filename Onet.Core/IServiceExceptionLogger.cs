using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Core
{
    public interface IServiceExceptionLogger
    {
        void LogException(Exception ex, string specificMessage);

    }
}
