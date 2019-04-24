using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CustomListView.iOS
{
    class ListViewiOSSource : UITableViewSource
    {

        IList<DataSource> tableItems;
        SabudegListView listView;
        readonly NSString cellIdentifier = new NSString("TableCell");

        public IEnumerable<DataSource> Items
        {
            //get{ }
            set
            {
                tableItems = value.ToList();
            }
        }

        public ListViewiOSSource(SabudegListView view)
        {
            tableItems = view.Items.ToList();
            listView = view;
        }

        /// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        #region user interaction methods

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            listView.NotifyItemSelected(tableItems[indexPath.Row]);
            Console.WriteLine("Row " + indexPath.Row.ToString() + " selected");
            tableView.DeselectRow(indexPath, true);
        }

        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("Row " + indexPath.Row.ToString() + " deselected");
        }

        #endregion

        /// <summary>
        /// Called by the TableView to get the actual UITableViewCell to render for the particular section and row
        /// </summary>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // request a recycled cell to save memory
            ListViewiOSCell cell = tableView.DequeueReusableCell(cellIdentifier) as ListViewiOSCell;

            // if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new ListViewiOSCell(cellIdentifier);
            }

            if (String.IsNullOrWhiteSpace(tableItems[indexPath.Row].Image))
            {
                cell.UpdateCell(tableItems[indexPath.Row].Food
                    , tableItems[indexPath.Row].Category
                    , null);
            }
            else
            {
                cell.UpdateCell(tableItems[indexPath.Row].Food
                    , tableItems[indexPath.Row].Category
                    , UIImage.FromFile("Images/" + tableItems[indexPath.Row].Image + ".jpg"));
            }

            return cell;
        }


    }
}