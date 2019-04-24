using System;
using System.Collections.Generic;

namespace CustomListView
{
	public class DataSource
	{
        public string Image { get; set; }
		public string Food { get; set; }
		public string Category { get; set; }

		public DataSource (string food, string category, string imageSource)
		{
			Food = food;
			Category = category;
			Image = imageSource;
		}

		public static List<DataSource> GetList ()
		{
			var foodList = new List<DataSource> ();

			foodList.Add (new DataSource ("Apple", "Fruit", "apple"));
			foodList.Add (new DataSource ("Dragon Fruit", "Fruit", "ejdermeyvesi"));
			foodList.Add (new DataSource ("Banana", "Fruit", "banana"));
			foodList.Add (new DataSource ("Garlic", "Vegetables", "garlic"));
			foodList.Add (new DataSource ("Beetroot", "Vegetables", "beetroot"));
			foodList.Add (new DataSource ("Onion", "Vegetables", "onion"));
			foodList.Add (new DataSource ("Watermelon", "Both", "watermelon"));

			return foodList;
		}
	}
}
