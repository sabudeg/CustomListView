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
using Android.Graphics.Drawables;
using CustomListView;

using System.Threading.Tasks;
using Xamarin.Forms.Platform.Android;
using System.Drawing;

namespace CustomListView.Droid
{
    class LVAdapter : BaseAdapter<DataSource>
    {

        Activity context;
        IList<DataSource> tableItems = new List<DataSource>();

        public IEnumerable<DataSource> Items
        {
            set
            {
                tableItems = value.ToList();
            }
        }

        public LVAdapter(Activity context, SabudegListView view)
        {
            this.context = context;
            tableItems = view.Items.ToList();
        }

        public override DataSource this[int position]
        {
            get
            {
                return tableItems[position];
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = tableItems[position];

            var view = convertView;



            if (view == null)
            {
                // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.SabudegListView, null);

                Android.Graphics.Color color = position % 2 == 0 ? Android.Graphics.Color.Gray : Android.Graphics.Color.DarkGray;

                view.SetBackgroundColor(color);
            }

            view.FindViewById<TextView>(Resource.Id.Food).Text = item.Food;
            view.FindViewById<TextView>(Resource.Id.Category).Text = item.Category;

            // grab the old image and dispose of it
            if (view.FindViewById<ImageView>(Resource.Id.Image).Drawable != null)
            {
                using (var image = view.FindViewById<ImageView>(Resource.Id.Image).Drawable as BitmapDrawable)
                {
                    if (image != null)
                    {
                        if (image.Bitmap != null)
                        {
                            //image.Bitmap.Recycle ();
                            image.Bitmap.Dispose();
                        }
                    }
                }
            }

            // If a new image is required, display it
            if (!String.IsNullOrWhiteSpace(item.Image))
            {
                context.Resources.GetBitmapAsync(item.Image).ContinueWith((t) => {
                    var bitmap = t.Result;
                    if (bitmap != null)
                    {
                        view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(bitmap);
                        bitmap.Dispose();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                // clear the image
                view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(null);
            }

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get { return tableItems.Count; }
        }

    }

    class LVAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}