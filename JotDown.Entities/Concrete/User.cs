using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotDown.Entities.Concrete
{
    public class User
    {
        public User()
        {
            Notes = new List<Note>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public List<Note> Notes { get; set; }
    }
}
