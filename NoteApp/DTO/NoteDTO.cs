using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DTO
{
    public class NoteDTO
    {
        public object Username { get; internal set; }
        public object ID { get; internal set; }
        public object Password { get; internal set; }
        public object Reminder { get; internal set; }
        public object Content { get; internal set; }
        public object Title { get; internal set; }
    }
}
