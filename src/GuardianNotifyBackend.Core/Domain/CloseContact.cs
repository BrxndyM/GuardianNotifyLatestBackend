using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Domain
{
    public class CloseContact : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string CellNumber { get; set; }  
        public virtual string EmailAddress { get; set; }
        public virtual Person Person { get; set; }

    }
}
