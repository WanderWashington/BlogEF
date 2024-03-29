using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEf.Models 
{
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Image{ get; set; }
        public string Bio { get; set; }

        public IList<Post> Posts { get; set; }

        public IList<Role> Roles { get; set; }

        public string Slug { get; set; }

        public string Github { get; set; }
    }
}