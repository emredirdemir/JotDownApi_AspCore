using JotDown.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotDown.Business.Abstract
{
    public interface INoteManager
    {
        List<Note> GetAll();
        Note Get(Note note);
        List<Note> GetById(int CategoryId);

        void Delete(Note note);
        void Add(Note note);
        void update(Note note);
    }
}
