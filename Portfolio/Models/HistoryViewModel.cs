using System.Collections.Generic;

namespace Portfolio.Models
{
    public class HistoryViewModel
    {
        public string Title { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}