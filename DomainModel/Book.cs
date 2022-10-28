using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Url { get; set; }
        public string Cover { get; set; }
        public Category Category { get; set; }
        public Genre Genre { get; set; }
        public Public Public { get; set; }
    }
}
