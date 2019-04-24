using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CustomListView.iOS
{

    public class ListViewiOSCell : UITableViewCell
    {

        UILabel food, category;
        UIImageView image;
        public ListViewiOSCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;

            int position = int.Parse(cellId);

            UIColor color = position == 0 ? UIColor.Gray : UIColor.DarkGray;

            ContentView.BackgroundColor = color;

            image = new UIImageView();

            food = new UILabel()
            {
                BackgroundColor = UIColor.Clear
            };

            category = new UILabel()
            {
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };

            ContentView.Add(food);
            ContentView.Add(category);
            ContentView.Add(image);
        }

        public void UpdateCell(string caption, string subtitle, UIImage image)
        {
            food.Text = caption;
            category.Text = subtitle;
            this.image.Image = image;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            food.Frame = new CoreGraphics.CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
            category.Frame = new CoreGraphics.CGRect(100, 18, 100, 20);
            image.Frame = new CoreGraphics.CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
        }
    }
}