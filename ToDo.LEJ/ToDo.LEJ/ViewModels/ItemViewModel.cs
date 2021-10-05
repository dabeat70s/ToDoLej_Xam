using Newtonsoft.Json;
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
        public string PageTitle { get; set; } = "New todo item";
        public bool ShowDelete { get; set; } 
        public string DeleteText { get; set; }  
        public TodoItem Item { get; set; }
        public ItemViewModel(TodoItemRepository repository)
        {
            _repository = repository;
            Item = new TodoItem() { Due = DateTime.Now.AddDays(1) };
            ShowDelete = false;
        }
        public ICommand Save => new Command(async () =>
        {
            await _repository.AddOrUpdate(Item);
            await Navigation.PopAsync();
        });

        public ICommand DeleteToDo => new Command(async (arg) =>
        {
            //var tt = new Tuple<TodoItem, Object>(Item, arg);
            //var jsonArg = JsonConvert.SerializeObject(tt);
            if (ShowDelete)
            {
                var resp = await App.Current.MainPage.DisplayAlert
                    ("Delete", $"'{Item.Title}'{Environment.NewLine}Dated for {String.Format("{0:dddd, MMMM d, yyyy}", Item.Due)} will be deleted ", "Yes", "No");
                if (resp)
                {
                    await _repository.DelelteItem(Item);
                    await Navigation.PopAsync();
                } 
            }
        });

    }
}
