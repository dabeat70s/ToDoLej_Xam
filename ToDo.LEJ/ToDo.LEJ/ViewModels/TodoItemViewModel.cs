using System;
using System.Collections.Generic;
using System.Text;
using ToDo.LEJ.Models;

namespace ToDo.LEJ.ViewModels
{
    public class TodoItemViewModel : ViewModel
    {
        public TodoItemViewModel(TodoItem item) => Item = item;

        public event EventHandler ItemStatusChanged;
        public TodoItem Item { get; private set; }
        public string StatusText => Item.Completed ? "Reactivate" :
        "Completed";
    }
}
