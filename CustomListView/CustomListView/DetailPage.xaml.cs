using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(object obj)
        {
            InitializeComponent();

                title.Text += (obj as DataSource).Food;
                foodLabel.Text += (obj as DataSource).Food;
                categoryLabel.Text += (obj as DataSource).Category;
                imageFood.Source = (obj as DataSource).Image;
                detailLabel.Text = (obj as DataSource).Food + " is a " + (obj as DataSource).Category;
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}