using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Games_Report__CodeFirst_.Entities
{
    public class GameInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Title { get; set; }

        [Required, StringLength(255)]
        public string Creator { get; set; }

        [Required, StringLength(255)]
        public string Style { get; set; }

        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        [Required,StringLength(255)]
        public string GameMode { get; set; } = "single";
       
        public int CountOfSoldCopies { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Title}|{Creator}|{Style}|{ReleaseDate}|{GameMode}|{CountOfSoldCopies}";
        }
    }
    
}
