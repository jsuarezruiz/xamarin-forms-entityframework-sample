using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoEF.Models;
using ToDoEF.Services.EF;
using ToDoEF.Services.Navigation;
using ToDoEF.ViewModels.Base;
using Xamarin.Forms;

namespace ToDoEF.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private ObservableCollection<TodoItem> _items;
        private TodoItem _selectedItem;

        private ICommand _addCommand;

        private INavigationService _navigationService;
        private IEntityFrameworkService _entityFrameworkService;

        public TodoListViewModel(
            INavigationService navigationService,
            IEntityFrameworkService entityFrameworkService)
        {
            _navigationService = navigationService;
            _entityFrameworkService = entityFrameworkService;
        }

        public ObservableCollection<TodoItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public TodoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                _navigationService.NavigateTo<TodoItemViewModel>(_selectedItem);
            }
        }

        public ICommand AddCommand
        {
            get { return _addCommand = _addCommand ?? new Command(AddCommandExecute); }
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            var result = _entityFrameworkService.GetAll();

            Items = new ObservableCollection<TodoItem>(result);
        }

        private void AddCommandExecute()
        {
            var todoItem = new TodoItem();
            _navigationService.NavigateTo<TodoItemViewModel>(todoItem);
        }
    }
}