using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomListView;
using CustomListView.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SabudegListView), typeof(ListViewiOSRenderer))]
namespace CustomListView.iOS
{
    public class ListViewiOSRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                Control.Source = new ListViewiOSSource(e.NewElement as SabudegListView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SabudegListView.ItemsProperty.PropertyName)
            {
                Control.Source = new ListViewiOSSource(Element as SabudegListView);
            }
        }

    }
}