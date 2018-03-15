using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificator.database
{
    [Table("symptoms", Schema = "public")]
    public class Symptom
    {
        public Symptom()
        {
            this.Pictures = new HashSet<Picture>();
            this.Users = new HashSet<User>();
        }
        [Column("id"), Key]
        public int Id { get; set; }
        [Column("symptom_name")]
        public string Symptom_name { get; set; }
        public ICollection<Recognized> Recognized_ { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
