using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotDown.Entities.Concrete
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int CategorId { get; set; }
    }
}
