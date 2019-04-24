using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomListView;
using CustomListView.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SabudegListView), typeof(LVRenderer))]
namespace CustomListView.Droid
{
    class LVRenderer : ListViewRenderer
    {

        Context _context;

        public LVRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // unsubscribe
                Control.ItemClick -= OnItemClick;
            }

            if (e.NewElement != null)
            {
                // subscribe
                Control.Adapter = new LVAdapter(_context as Android.App.Activity, e.NewElement as SabudegListView);
                Control.ItemClick += OnItemClick;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SabudegListView.ItemsProperty.PropertyName)
            {
                Control.Adapter = new LVAdapter(_context as Android.App.Activity, Element as SabudegListView);
            }
        }

        void OnItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            ((SabudegListView)Element).NotifyItemSelected(((SabudegListView)Element).Items.ToList()[e.Position - 1]);
        }


    }
}