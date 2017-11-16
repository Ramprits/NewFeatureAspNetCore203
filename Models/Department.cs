using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewFeatureApplication.Infrastructure;

namespace NewFeatureApplication.Models {
    [Table ("Department", Schema = "MST")]
    public class Department : ClientChangeTracker {
        [Key]
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}