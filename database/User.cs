using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificator.database
{
    [Table("users", Schema = "public")]
    public class User
    {
        public User()
        {
            this.Pictures = new HashSet<Picture>();
            this.Symptoms = new HashSet<Symptom>();
        }

        [Column("id"), Key]
        public int Id { get; set; }
        [Column("user_name")]
        public string User_name { get; set; }
        public ICollection<Recognized> Recognized_ { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Symptom> Symptoms { get; set; }
    }
}
