using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestQuiz.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public bool IsCorrect { get; set; }

        [Display(Name = "Theme Id")]
        public int ThemeId { get; set; }

        [ForeignKey("ThemeId")]
        public virtual Theme Theme { get; set; }
    }
}
