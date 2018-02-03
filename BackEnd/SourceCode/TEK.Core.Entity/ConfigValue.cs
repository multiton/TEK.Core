using System.ComponentModel.DataAnnotations;

namespace TEK.Core.Entity
{
    public class ConfigValue : BaseDataEntity
    {
        [Required]
        [StringLength(127)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string CurrentValue { get; set; }

        [Required]
        [StringLength(255)]
        public string DefaultValue { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}