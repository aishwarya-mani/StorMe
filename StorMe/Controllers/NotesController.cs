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
            return objNote.GetNote(title);
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