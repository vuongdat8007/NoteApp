using Prism.Regions;

namespace NoteApp.Core.Navigation
{
    public class NavigationItem : INavigationItem
    {
        public string NavigationRegion { get; set; }
        public string NavigationPath { get; set; }
        public NavigationParameters NavigationParameters { get; set; }
    }
}
