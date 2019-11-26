using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INote.API.Dtos
{
    public class PostNoteDto
    {
        [Required(ErrorMessage ="Başlık alanı zorunludur")]
        [StringLength(50, ErrorMessage ="Başlık çok uzun olmuş")]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}