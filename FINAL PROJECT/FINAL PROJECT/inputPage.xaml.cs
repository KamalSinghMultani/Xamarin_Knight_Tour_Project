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
    public partial class inputPage : ContentPage
    {
        public inputPage()
        {
            InitializeComponent();
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(RowsEntry.Text);
            int cols = Convert.ToInt32(ColsEntry.Text);
            int startRow = Convert.ToInt32(StartRowEntry.Text);
            int startCol = Convert.ToInt32(StartColEntry.Text);
            int numTrials = Convert.ToInt32(NumTrialsEntry.Text);

            if (rows > 0 && cols > 0 && startRow >= 0 && startCol >= 0 && numTrials > 0)
            {
                // Input validation successful, navigate to the knight's tour simulation page
                Navigation.PushAsync(new NewMainPage(rows, cols, startRow, startCol, numTrials));
            }
            else
            {
                DisplayAlert("Error", "Please enter valid numbers for all fields.", "OK");
            }
        }
    }
}