using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Portfolio.Models
{
    public class JobViewModel
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Start { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Finish { get; set; }
        public string Title { get; set; }
        public int EmployerId { get; set; }
        public string Description { get; set; }
        public IEnumerable<SelectListItem> Employers { get; set; }
    }
}