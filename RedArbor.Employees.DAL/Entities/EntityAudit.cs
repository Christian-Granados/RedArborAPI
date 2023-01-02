using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Employees.DAL.Entities
{
    public class EntityAudit
    {
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeletedOn { get; set; }
    }
}
