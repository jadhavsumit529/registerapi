using System;
using System.Collections.Generic;

namespace registerapi.Models
{
    public partial class Info
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dateofbirth { get; set; } 
        public string Profession { get; set; } = null!;
    }
}
