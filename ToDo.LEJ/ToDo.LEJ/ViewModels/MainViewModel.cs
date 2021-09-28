using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.LEJ.Models;
using ToDo.LEJ.Repositories;
using ToDo.LEJ.Views;
using Xamarin.Forms;

namespace ToDo.LEJ.ViewModels
{
    public class MainViewModel: ViewModel
    {
        private readonly TodoItemRepository _repos;
        public ICommand AddItem => new Command(async () =>
        {
            var itemView = Resolver.Resolve<ItemView>();
            await Navigation.PushAsync(itemView);
        });

        public TodoItemViewModel SelectedItem
        {
            get { return null; }
            set
            {
                Device.BeginInvokeOnMainThread(async () => await
                NavigateToItem(value));
                RaisePropertyChanged(nameof(SelectedItem));
            }
        }

        private async Task NavigateToItem(TodoItemViewModel item)
        {
            if (item == null)
            {
                return;
            }
            var itemView = Resolver.Resolve<ItemView>();
            var vm = itemView.BindingContext as ItemViewModel;

            vm.Item = item.Item;
            await Navigation.PushAsync(itemView);
        }

        public ObservableCollection<TodoItemViewModel> Items { get; set; }

        public MainViewModel(TodoItemRepository repos)
        {
            repos.OnItemAdded += (sender, item) =>
            Items.Add(CreateTodoItemViewModel(item));
            repos.OnItemUpdated += (sender, item) =>
            Task.Run(async () => await LoadData());

            _repos = repos;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            var items = await _repos.GetItems();
            var itemViewModels = items.Select(i =>
            CreateTodoItemViewModel(i));
            Items = new ObservableCollection<TodoItemViewModel>
            (itemViewModels);
        }

        private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
        {
            var itemViewModel = new TodoItemViewModel(item);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;
        }
        private void ItemStatusChanged(object sender, EventArgs e)
        {
        }
    }
}
