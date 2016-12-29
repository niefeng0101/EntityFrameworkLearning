using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public enum SntonUpdateFlag
    {
        Read = 0,
        Unread = 1
    }
    public enum SntonOperateFlag
    {
        Add = 0,
        Update = 1,
        Delete = 2
    }
    public enum SntonWorkTaskStatus
    {
        Create = 0,
        Active = 1,
        Completed = 2,
        AgingButLess = 3,
        OnlyLess = 4,
        Cancelled = 5,
        NoSample=6
    }
}
