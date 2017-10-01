using System.ComponentModel.DataAnnotations;

namespace TEK.Core.Entity
{
    public class OrderHeader : BaseDataEntity
    {
        [Required]
        [StringLength(255)]
        public string Number { get; set; }

        public virtual Company Customer { get; set; }
    }
}