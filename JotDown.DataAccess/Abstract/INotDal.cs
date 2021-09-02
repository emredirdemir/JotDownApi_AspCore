using JotDown.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JotDown.DataAccess.Abstract
{
    public interface INotDal
    {
        List<Note> GetNotes();
        List<Note> GetNotesByCategory(int CategoryId);
        Note GetNote(Note note);
        void Update(Note note);
        void Delete(Note note);
        void AddNote(Note note);

    }
}
