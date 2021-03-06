using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace CreactPager
{
	public class ColorAdapter : BaseAdapter
	{
		Context context;

		public ColorAdapter(Context c)
		{
			context = c;

		}
		public override int Count { get { return ColorsHex.Length; } }

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return 0;
		}

		// create a new ImageView for each item referenced by the Adapter
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			ImageView i = new ImageView(context);

			i.SetImageResource(Resource.Drawable.transparentButton);
			i.SetColorFilter(Color.ParseColor(ColorsHex[position]));
			i.SetScaleType(ImageView.ScaleType.FitXy);
			return i;
		}

		// references to our images
		string [] ColorsHex =
		{
			"#f01313",
			"#171515",
			"#2be01b",
			"#641d80",
			"#e3b80e",
			"#0e0ee8",
			"#0dff00",
			"#fff200",
			"#05edf5",
			"#7be4e8",
			"#7d1d1d",
			"#0e008c",
			"#94943a",
			"#71d978",
			"#f07b07"
		};
		public string CurrentColor(int position)
		{
			return ColorsHex[position];
		}

	}
}