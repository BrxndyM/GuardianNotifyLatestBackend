using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNotifyBackend.Domain
{
    public class Location : FullAuditedEntity<Guid>
    {
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual Person Person { get; set; }
    }
}
