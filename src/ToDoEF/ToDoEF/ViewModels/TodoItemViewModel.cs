using System.Windows.Input;
using ToDoEF.Models;
using ToDoEF.Services.EF;
using ToDoEF.Services.Navigation;
using ToDoEF.ViewModels.Base;
using Xamarin.Forms;

namespace ToDoEF.ViewModels
{
    public class TodoItemViewModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _notes;
        private bool _done;
        private TodoItem _item;

        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private INavigationService _navigationService;
        private IEntityFrameworkService _entityFrameworkService;

        public TodoItemViewModel(
            INavigationService navigationService,
            IEntityFrameworkService entityFrameworkService)
        {
            _navigationService = navigationService;
            _entityFrameworkService = entityFrameworkService;
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        public bool Done
        {
            get { return _done; }
            set
            {
                _done = value;
                OnPropertyChanged();
            }
        }

        public TodoItem Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new Command(SaveCommandExecute); }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand = _deleteCommand ?? new Command(DeleteCommandExecute); }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand = _cancelCommand ?? new Command(CancelCommandExecute); }
        }

        public override void OnAppearing(object navigationContext)
        {
            var todoItem = navigationContext as TodoItem;

            if (todoItem != null)
            {
                Id = todoItem.Id;
                Name = todoItem.Name;
                Notes = todoItem.Notes;
                Done = todoItem.Done;

                Item = todoItem;
            }

            base.OnAppearing(navigationContext);
        }


        private void SaveCommandExecute()
        {
            var item = new TodoItem
            {
                Id = Id,
                Name = Name,
                Notes = Notes,
                Done = Done
            };

            _entityFrameworkService.Insert(item);
            _navigationService.NavigateBack();
        }

        private void DeleteCommandExecute()
        {
            _entityFrameworkService.Remove(Item);
            _navigationService.NavigateBack();
        }

        private void CancelCommandExecute()
        {
            _navigationService.NavigateBack();
        }
    }
}