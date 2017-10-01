using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEK.Core.Entity
{
	public class Company : BaseDataEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}