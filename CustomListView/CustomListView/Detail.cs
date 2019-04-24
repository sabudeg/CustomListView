using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomListView
{
    public class Detail : ContentPage
    {

        public Detail(object obj)
        {

            var dismissButton = new Button { Text = "Dismiss" };
            dismissButton.Clicked += OnButtonClicked;
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}
