using System.ComponentModel.DataAnnotations;

namespace Vrote_Diana_Laborator2.Models
{
    public class Author
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]

        public string FullName
        {
            get { return $"{LastName}{FirstName}"; }
        }
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
