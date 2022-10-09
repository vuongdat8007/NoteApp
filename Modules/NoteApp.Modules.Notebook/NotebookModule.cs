using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using NoteApp.Core;

namespace NoteApp.Modules.Notebook
{
    public class NotebookModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public NotebookModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.NotebookRegion, typeof(Views.Notebook));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<Views.Notebook, ViewModels.NotebookViewModel>();
        }
    }
}