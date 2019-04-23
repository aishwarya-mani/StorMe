using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StorMe.Models;

namespace StorMe.Controllers
{
    public class NotesController : Controller
    {
        NotesDataAccessLayer objNote = new NotesDataAccessLayer();

        //To fetch all notes
        [HttpGet]
        [Route("api/StorMe/Notes")]
        public IEnumerable<Notes> Get()
        {
            return objNote.GetAllNotes();
        }

        //To add new note
        [HttpPost]
        [Route("api/StorMe/Create")]
        public int Create(Notes note)
        {
            return objNote.AddNote(note);
        }

        //To Update the a particular note  
        [HttpPut]
        [Route("api/StorMe/Edit")]
        public int Edit(Notes note)
        {
            return objNote.UpdateNote(note);
        }

        //Get a note with ID
        [HttpGet]
        [Route("api/StorMe/Note/{id}")]
        public Notes Details(int id)
        {
            return objNote.GetNote(id);
        }

        //Get a note with label
        [HttpGet]
        [Route("api/StorMe/Note/{label}")]
        public Notes DetailsLabel(string label)
        {
            return objNote.GetLabelNotes(label);
        }

        //Get a note with title
        [HttpGet]
        [Route("api/StorMe/Note/{title}")]
        public Notes DetailsTitle(string title)
        {
            return objNote.GetTitleNote(title);
        }
        
        //To Delete a particular note
        [HttpDelete]
        [Route("api/StorMe/Delete/{id}")]
        public int Delete(int id)
        {
            return objNote.DeleteNote(id);
        }
    }
}