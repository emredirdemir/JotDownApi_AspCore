using JotDown.Business.Abstract;
using JotDown.DataAccess.Abstract;
using JotDown.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotDown.Business.Concrete
{
    public class NoteManager : INoteManager
    {
        private INoteDal _noteDal;
        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }
        public void Add(Note note)
        {
            _noteDal.AddNote(note);
        }

        public void Delete(Note note)
        {
            _noteDal.Delete(note);
        }

        public Note Get(Note note)
        {
           return _noteDal.GetNote(note);
        }

        public List<Note> GetAll()
        {
            return _noteDal.GetNotes();
        }

        public List<Note> GetById(int CategoryId)
        {
            return _noteDal.GetNotesByCategory(CategoryId);
        }

        public void update(Note note)
        {
            _noteDal.Update(note);
        }
    }
}
