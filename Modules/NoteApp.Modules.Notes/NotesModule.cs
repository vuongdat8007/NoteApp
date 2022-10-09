using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using NoteApp.Core;

namespace NoteApp.Modules.Notes
{
    public class NotesModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public NotesModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.NotesRegion, typeof(Views.Notes));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<Views.Notes, ViewModels.NotesViewModel>();

            containerRegistry.RegisterForNavigation<Views.Notes, ViewModels.NotesViewModel>();
        }
    }
}