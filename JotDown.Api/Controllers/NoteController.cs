using JotDown.Business.Abstract;
using JotDown.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JotDown.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteManager _manager;

        public NoteController(INoteManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_manager.GetAll());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Note note)
        {
            _manager.Add(note);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Note note)
        {
            _manager.update(note);
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Note note)
        {
            _manager.Delete(note);
            return Ok();
        }

        [HttpPost]
        [Route("getbycategory")]
        public IActionResult GetByCategory(int id)
        {
            
            return Ok(_manager.GetById(id));
        }
    }
}
