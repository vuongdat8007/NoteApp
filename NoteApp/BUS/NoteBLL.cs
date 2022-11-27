using NoteApp.DAL;
using NoteApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BUS
{
    
    public class NoteBLL
    {
        public NotesDAL dalNote;

        public NoteBLL()
        {
            dalNote = new NotesDAL();
        }

        public DataTable getAllNotes()
        {
            return dalNote.getAllNotes();
        }

        public bool AddNote(NoteDTO note)
        {
            return dalNote.AddNote(note);
        }

        public bool DeleteNote(NoteDTO note)
        {
            return dalNote.DeleteNote(note);
        }

        public DataTable SearchNote(string searchString)
        {
            return dalNote.SearchNote(searchString);
        }

    }
}
