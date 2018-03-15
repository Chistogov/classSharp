using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificator.database
{
    [Table("pictures", Schema = "public")]
    public class Picture
    {
        public Picture()
        {
            this.Symptoms = new HashSet<Symptom>();
            this.Users = new HashSet<User>();
        }
        [Column("id"), Key]
        public int Id { get; set; }
        [Column("pic_name")]
        public string Pic_name { get; set; }
        [Column("index_date")]
        public DateTime Date { get; set; }
        [Column("note")]
        public string Note { get; set; }
        [Column("hash")]
        public string Hash { get; set; }
        [Column("first_rec")]
        public bool Recognized { get; set; }
        [Column("skipped")]
        public bool Skipped { get; set; }
        public ICollection<Recognized> Recognized_ { get; set; }
        public virtual ICollection<Symptom> Symptoms { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
