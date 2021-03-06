using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;

namespace CreactPager
{
	public class MyViewPagerAdapter : FragmentPagerAdapter
	{
		private List<Android.Support.V4.App.Fragment> fragments;
		int fragmentCount;
		public MyViewPagerAdapter(Android.Support.V4.App.FragmentManager fm,int restProperty,string pathToUserDb,FragmentActivity activity) : base(fm)
		{
			this.fragments = new List<Android.Support.V4.App.Fragment>();
			fragments.Add(new FragmentFavourite(restProperty,pathToUserDb,activity));
			fragments.Add(new FragmentNotFavourite(restProperty,pathToUserDb,activity));
			fragmentCount = fragments.Count;

		}


		public override int Count
		{
			get
			{
				return fragmentCount;
			}
		}
		//public override void StartUpdate(View container)
		//{
		//	base.StartUpdate(container);
		//}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{

			return fragments[position];
		}
		// public override IParcelable SaveState()
		//{
		//	return base.SaveState();
		//}

	}
	public class FragmentNotFavourite : Android.Support.V4.App.Fragment
	{
		int restProperty;
		string pathToUserDb;
		FragmentActivity activity;
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.HomeLayout, container, false);
			var listView = view.FindViewById<ListView>(Resource.Id.List);
			var butDelete = view.FindViewById<ImageButton>(Resource.Id.imagebut);
			var butStar = view.FindViewById<ImageButton>(Resource.Id.imageButton1);
			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_drinks.db");
			Person[] persons = MyDataBase.GetNames(pathToDatabase);
			var adapter = new MyAdapter(Activity, persons, pathToDatabase,listView,activity,pathToUserDb,restProperty);
			listView.Adapter = adapter;
			return view;
		}
		public FragmentNotFavourite(int restProperty, string pathToUserDb,FragmentActivity activity)
		{
			this.restProperty = restProperty;
			this.pathToUserDb = pathToUserDb;
			this.activity = activity;
		}
	}
	public class FragmentFavourite : Android.Support.V4.App.Fragment
	{
		int restProperty;
		string pathToUserDb;
		FragmentActivity activity;
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_drinks.db");
			View view = inflater.Inflate(Resource.Layout.Main_new, container, false);
			var gridView = view.FindViewById<GridView>(Resource.Id.gridView1);
			Person[] persons = MyDataBase.GetFavouriteDrinks(pathToDatabase);
			gridView.Adapter = new GridViewAdapter(Context, pathToDatabase,persons,restProperty,pathToUserDb,activity);
			return view;
		}
		public FragmentFavourite(int restProperty, string pathToUserDb,FragmentActivity activity)
		{
			this.restProperty = restProperty;
			this.pathToUserDb = pathToUserDb;
			this.activity = activity;
		}
	}

}

