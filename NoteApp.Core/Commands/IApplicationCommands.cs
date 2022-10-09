using Prism.Commands;

namespace NoteApp.Core.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand NavigateCommand { get; }
    }
}
