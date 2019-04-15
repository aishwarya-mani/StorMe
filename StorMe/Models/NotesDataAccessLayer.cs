using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StorMe.Models
{
    public class NotesDataAccessLayer
    {
        StorMeDBContext db = new StorMeDBContext();

        public IEnumerable<Notes> GetAllNotes()
        {
            try
            {
                return db.Notes.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To add new note
        public int AddNote(Notes note)
        {
            try
            {
                db.Notes.Add(note);
                db.SaveChanges();
                return 1;
            }

            catch
            {
                throw;
            }

        }

        //To Update the a particular note    
        public int UpdateNote(Notes note)
        {
            try
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }

            catch
            {
                throw;
            }
        }

        //Get a note with labels
        public Notes GetLabelNotes(string label)
        {
            try
            {
                Notes note = db.Notes.Find(label);
                return note;
            }

            catch
            {
                throw;
            }
        }

        //Get a note with title
        public Notes GetNote(string title)
        {
            try
            {
                Notes note = db.Notes.Find(title);
                return note;
            }

            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee    
        public int DeleteNote(int id)
        {
            try
            {
                Notes note = db.Notes.Find(id);
                db.Notes.Remove(note);
                db.SaveChanges();
                return 1;
            }

            catch
            {
                throw;
            }
        }

        //To Get the list of Cities    
        public List<Notes> GetNotesList()
        {
            List<Notes> lst = new List<Notes>();
            lst = (from NotesList in db.Notes select NotesList).ToList();
            return lst;
        }
    }
}