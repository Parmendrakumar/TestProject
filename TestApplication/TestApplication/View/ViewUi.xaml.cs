using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApplication.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUi : ContentPage
    {
        public ViewUi()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            barcode.Text = "";
            width.Text = "";
            height.Text = "";
            depth.Text = "";
        }
    }
}