using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Domain.Enums
{
    public enum RefListGender
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Male")]
        Male = 1,
        /// <summary>
        /// 
        /// </summary>    
        [Description("Female")]
        Female = 2,

        [Description("Other")]
        NotDisclosed = 0
    }
}
