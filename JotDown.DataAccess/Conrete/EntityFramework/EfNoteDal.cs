using JotDown.DataAccess.Abstract;
using JotDown.DataAccess.Contexts.EntityFramewwork;
using JotDown.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JotDown.DataAccess.Conrete.EntityFramework
{
    public class EfNoteDal: INoteDal
    {
        
        public void AddNote(Note note)
        {
            using (var db = new JotContext())
            {
                db.Add(note);
                db.SaveChanges();
            }
        }

        public void Delete(Note note)
        {
            using (var db = new JotContext())
            {
                db.Remove(note);
                db.SaveChanges();
            }
        }

        public Note GetNote(Note note)
        {
            using (var db = new JotContext())
            {
                Note selectedNote = db.notes.FirstOrDefault(n => n.NoteId == note.NoteId);
                return selectedNote;
            }
        }

        public List<Note> GetNotes()
        {
            using (var db = new JotContext())
            {
                List<Note> notes = db.notes.ToList();
                return notes;
            }
        }

        public List<Note> GetNotesByCategory(int CategoryId)
        {
            using (var db = new JotContext())
            {
                List<Note> notes = db.notes.Where(n => n.CategorId == CategoryId).ToList();

                return notes;
            }
        }

        public void Update(Note note)
        {
            using(var db = new JotContext())
            {
                db.Update(note);
                db.SaveChanges();
            }
        }
    }
}
