using System;
using System.Collections.Generic;

namespace desafio
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public DateTime Date { get; set; }
        public byte Active { get; set; }
        public string Country { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
