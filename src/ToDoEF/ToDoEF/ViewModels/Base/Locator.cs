using Autofac;
using Autofac.Core;
using ToDoEF.Services.EF;
using ToDoEF.Services.Navigation;

namespace ToDoEF.ViewModels.Base
{
    public class Locator
    {
        private readonly IContainer _container;
        private ContainerBuilder _builder;

        public Locator()
        {
            _builder = new ContainerBuilder();

            _builder.RegisterType<NavigationService>().As<INavigationService>();
            _builder.RegisterType<EntityFrameworkService>().As<IEntityFrameworkService>();

            _builder.RegisterType<TodoListViewModel>();
            _builder.RegisterType<TodoItemViewModel>();

            _container = _builder.Build();
        }

        public TodoListViewModel TodoListViewModel
        {
            get { return _container.Resolve<TodoListViewModel>(); }
        }

        public TodoItemViewModel TodoItemViewModel
        {
            get { return _container.Resolve<TodoItemViewModel>(); }
        }
    }
}