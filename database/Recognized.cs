using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://stackoverflow.com/questions/7050404/create-code-first-many-to-many-with-additional-fields-in-association-table
namespace Classificator.database
{
    [Table("recognized", Schema = "public")]
    public class Recognized
    {
        [Column("id"), Key]
        public int Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        //[Key]
        public int pic_id { get; set; }
        //[Key]
        public int symp_id { get; set; }
        //[Key]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
        [ForeignKey("symp_id")]
        public Symptom Symptom { get; set; }
        [ForeignKey("pic_id")]
        public Picture Picture { get; set; }
    }
}
