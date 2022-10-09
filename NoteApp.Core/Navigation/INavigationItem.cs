using Prism.Regions;

namespace NoteApp.Core.Navigation
{
    public interface INavigationItem
    {
        string NavigationRegion { get; set; }
        string NavigationPath { get; set; }
        NavigationParameters NavigationParameters { get; set; }
    }
}
