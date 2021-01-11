using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Subject
    {
        [Key]
        public int StringId { get; set; }
        public virtual Meeting Meeting { get; set; }
        [Required]
        public int MeetId { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }

    }
}