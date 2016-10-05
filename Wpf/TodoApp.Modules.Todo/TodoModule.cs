using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using TodoApp.Modules.Todo.Views;
using TodoApp.Services;

namespace TodoApp.Modules.Todo
{
    public class TodoModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public TodoModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<ITodoService, AzureTodoService>(new ContainerControlledLifetimeManager());
            _container.RegisterTypeForNavigation<TodoForm>();

            _regionManager.RequestNavigate("ContentRegion", "TodoForm");
        }
    }
}