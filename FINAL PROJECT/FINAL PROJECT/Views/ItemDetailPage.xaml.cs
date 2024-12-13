using FINAL_PROJECT.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FINAL_PROJECT.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}