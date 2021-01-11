using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Meeting
    {
        [Key]
        public int MeetId { get; set; }
        [Required(ErrorMessage = "Titlul este obligatoriu!")]
        public string TitluMeet { get; set; }
        [MaxLength(500, ErrorMessage = "Nu puteti depasi 500 de caractere!")]
        public string Content { get; set; }
        public DateTime Data { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}