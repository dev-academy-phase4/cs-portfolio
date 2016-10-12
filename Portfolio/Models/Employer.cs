using System.Web.Mvc;

namespace Portfolio.Models
{
    public class Employer
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}