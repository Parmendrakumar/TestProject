using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Model;
using Xamarin.Forms;

namespace TestApplication.ViewModel
{
    class MyNameViewModel : INotifyPropertyChanged
    {
        public string BarCode { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Depth { get; set; }

       
        public ObservableCollection<ModelClass> speakers{ get; set; }

        public MyNameViewModel()
        {           
            speakers = new ObservableCollection<ModelClass>();
        }

        public void AddNewItem()
        {            
                speakers.Add(new ModelClass()
                {
                    // here you can add any value to collection               
                 });            
        }
        public Command showCommand
        {
            get
            {
                return new Command(() =>
                {
                    string message = "Dimm( " + Height + " x " + Width + " x " + Depth + " )" + " " + BarCode;
                    DependencyService.Get<IMessage>().LongAlert(message);
                });
            }
        }
        public Command resetCommand
        {
            get
            {
                return new Command(() =>
                {
                    //  string message = "Dimm( " + Height + " x " + Width + " x " + Depth + " )" + " " + BarCode;
                    //   DependencyService.Get<IMessage>().LongAlert(message);
                    BarCode = "";
                    Width = "";
                    Height = "";
                    Depth = "";

                });
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
