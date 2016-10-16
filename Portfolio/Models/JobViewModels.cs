using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Portfolio.Models
{
    public class JobViewModel
    {
        public int Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Start { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Finish { get; set; }
        public string Title { get; set; }
        [DisplayName("Employer")]
        public string EmployerName { get; set; }
        [DisplayName("About this employer")]
        public string EmployerDescription { get; set; }
        public string Description { get; set; }
    }

    public class JobEditViewModel
    {
        public int Id { get; set; }
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