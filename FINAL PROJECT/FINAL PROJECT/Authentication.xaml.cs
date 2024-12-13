using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FINAL_PROJECT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authentication : ContentPage
    {
        private const string hardcodedUsername = "Kamaldeep";
        private const string hardcodedPassword = "Sheridan";
        public Authentication()
        {
           
            InitializeComponent();

        }
        private void OnLoginClicked(object sender, EventArgs e)
        {
            if (UsernameEntry.Text == hardcodedUsername && PasswordEntry.Text == hardcodedPassword)
            {
                Navigation.PushAsync(new inputPage());
            }
            else
            {
                DisplayAlert("Error", "Invalid login credentials.", "OK");
            }
        }
    }
}