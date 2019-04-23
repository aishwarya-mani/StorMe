using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.Extensions.Logging;

namespace StorMe.Models
{
    public class NotesDataAccessLayer
    {
        StorMeDBContext db = new StorMeDBContext();

        //To fetch all notes
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

        //Get a note with label
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
        public Notes GetTitleNote(string title)
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

        //Get a note with id
        public Notes GetNote(int id)
        {
            try
            {
                Notes note = db.Notes.Find(id);
                return note;
            }

            catch
            {
                throw;
            }
        }

        //To Delete a particular note
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
    }
}