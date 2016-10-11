using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class Job
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Employer Employer { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed), ReadOnly(true)]
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}