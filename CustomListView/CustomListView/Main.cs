using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomListView
{
    public class Main : ContentPage
    {
        SabudegListView sabudegListView;
        public Main()
        {
            sabudegListView = new SabudegListView
            {
                Items = DataSource.GetList(),
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = new Grid
            {
                RowDefinitions = {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Star) }
                },
                Children = {
                    //new Label { Text = App.Description, HorizontalTextAlignment = TextAlignment.Center },
                    //sabudegListView
                }
            };

            sabudegListView.ItemSelected += OnItemSelected;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new Detail(e.SelectedItem));
        }

    }
}
