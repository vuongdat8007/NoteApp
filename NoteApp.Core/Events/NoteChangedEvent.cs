using Prism.Events;

namespace NoteApp.Core.Events
{
    public class NoteChangedEvent : PubSubEvent<string>
    {
    }
}
