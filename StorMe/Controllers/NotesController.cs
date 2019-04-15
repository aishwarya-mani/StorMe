using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StorMe.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StorMe.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        NotesDataAccessLayer objNote = new NotesDataAccessLayer();

        [HttpGet]
        [Route("api/StorMe/Index")]
        public IEnumerable<Notes> Get()
        {
            return objNote.GetAllNotes();
            //return objNote.GetAllNote();
        }

        [HttpPost]
        [Route("api/StorMe/Create")]
        public int Create(Notes note)
        {
            return objNote.AddNote(note);
        }

        [HttpGet]
        [Route("api/StorMe/Note/{label}")]
        public Notes DetailsLabel(string label)
        {
            return objNote.GetLabelNotes(label);
        }

        [HttpGet]
        [Route("api/StorMe/Note/{title}")]
        public Notes DetailsTitle(string title)
        {
            return objNote.GetNote(title);
        }

        [HttpPut]
        [Route("api/StorMe/Edit")]
        public int Edit(Notes note)
        {
            return objNote.UpdateNote(note);
        }

        [HttpDelete]
        [Route("api/StorMe/Delete/{id}")]
        public int Delete(int id)
        {
            return objNote.DeleteNote(id);
        }

        [HttpGet]
        [Route("api/StorMe")]
        public IEnumerable<Notes> Details()
        {
            return objNote.GetNotesList();
        }
    }
}