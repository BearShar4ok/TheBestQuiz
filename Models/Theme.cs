﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestQuiz.Models
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
