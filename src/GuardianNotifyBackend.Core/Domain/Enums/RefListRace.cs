using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Domain.Enums
{
    public enum RefListRace
    {
        [Description("Black")]
        Black = 1,

        [Description("Coloured")]
        Coloured = 2,

        [Description("White")]
        White = 3,

        [Description("Indian")]
        Indian = 4,

        [Description("Other")]
        Other = 5,
    }
}
