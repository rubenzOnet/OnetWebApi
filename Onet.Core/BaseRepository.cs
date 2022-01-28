using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Core
{
    public class BaseRepository
    {
        protected readonly DbSession _session;
        protected BaseRepository(DbSession session)
        {
            _session = session;
        }

    }
}
