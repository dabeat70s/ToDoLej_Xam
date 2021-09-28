using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ToDo.LEJ.Models;
using ToDo.LEJ.Repositories;
using Xamarin.Forms;

namespace ToDo.LEJ.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly TodoItemRepository _repository;

        public TodoItem Item { get; set; }
        public ItemViewModel(TodoItemRepository repository)
        {
            _repository = repository;
            Item = new TodoItem() { Due = DateTime.Now.AddDays(1) };
        }
        public ICommand Save => new Command(async () =>
        {
            await _repository.AddOrUpdate(Item);
            await Navigation.PopAsync();
        });
    }
}
