using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ToDo.LEJ.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        #region Fody usage implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
            }
        } 
        #endregion
        public INavigation Navigation { get; set; } // should be abstract to work on all platforms
    }
}
