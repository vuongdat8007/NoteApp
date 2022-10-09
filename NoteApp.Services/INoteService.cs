using System;
using System.Collections.Generic;
using NoteApp.Core.Models;

namespace NoteApp.Services
{
    public interface INoteService
    {
        IList<Notebook> GetAllNotebookCategories();
        int GetCategoryCount(Guid category);
        IList<Note> GetNotes(Guid category);
        Note GetNote(Guid noteId);
        bool DuplicateNote(Guid noteId);
        bool DeleteNote(Guid noteId);
        bool AddNote();
        void SaveNotes();
    }
}
