using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApplication
{
    public partial class MainPage : ContentPage
    {
        string strBarCode = "";
        string strHeight = "";
        string strWidth = "";
        string strDepth = "";
        public MainPage()
        {
            InitializeComponent();           
        }

        // Method for Submit Data to server
        private async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                Boolean boolisValid = await IsValid();
                if(boolisValid)
                {
                    strBarCode = barcode.Text;
                    strHeight = h.Text;
                    strWidth = w.Text;
                    strDepth = d.Text;
                    string message = "Dimm( " + strHeight + " x " + strWidth + " x " + strDepth + " ) " + strBarCode;
                    // DependencyService.Get<IMessage>().ShortAlert("ShortMessage");
                    DependencyService.Get<IMessage>().LongAlert(message);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        //Validation
        public async Task<Boolean> IsValid()
        {
            if (barcode.Text == null || barcode.Text == "")
            {
                await DisplayAlert("Alert", "Please Enter Barcode", "Ok");
                barcode.Focus();
                return false;
            }
           else if (w.Text == null || w.Text == "")
            {
                await DisplayAlert("Alert", "Please Enter Width", "Ok");
                w.Focus();
                return false;
            }
           else if (h.Text == null || h.Text == "")
            {
                await DisplayAlert("Alert", "Please Enter Height", "Ok");
                h.Focus();
                return false;
            }
           else if (d.Text == null || d.Text == "")
            {
                await DisplayAlert("Alert", "Please Enter Depth", "Ok");
                d.Focus();
                return false;
            }
            return true;
        }

        //Reset all Entries
        private void Reset(object sender, EventArgs e)
        {
            barcode.Text = "";
            h.Text = "";
            w.Text = "";
            d.Text = "";
        }
    }
}
