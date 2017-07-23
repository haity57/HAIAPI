using System;
using System.Linq;
using UIKit;
using Foundation;
using Xamarin.Themes;

namespace ThemeSample
{
	public class TableViewController : UITableViewController
	{
		public TableViewController ()
		{
			this.Title = "TableView";
			this.TabBarItem = new UITabBarItem ("TableView", new UIImage ("tableIcon.png"), 0);
		}
		
		public Track[] Tracks
		{
			get;
			set;
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (IndustrialTheme.IsIOS7)
				this.EdgesForExtendedLayout = UIRectEdge.None;

			Tracks = SampleTracks.GetTracks().ToArray();
			IndustrialTheme.Apply (this);
			TableView.DataSource = new DataSource (this);
			TableView.RowHeight = 75;

		}
		class DataSource : UITableViewDataSource
		{
			TableViewController Parent;
			public DataSource(TableViewController parent)
			{
				Parent = parent;
			}
			#region implemented abstract members of UITableViewDataSource

			#if __UNIFIED__
			public override nint RowsInSection (UITableView tableView, nint section)
			#else
			public override int RowsInSection (UITableView tableView, int section)
			#endif
			{
				return Parent.Tracks.Length;
			}
			string cellKey = "themedCell";
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (cellKey);
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellKey);
					IndustrialTheme.Apply (cell);
				}
				
				Track track = this.Parent.Tracks[indexPath.Row];
				
				cell.TextLabel.Text = track.TrackName;
				cell.DetailTextLabel.Text = track.ArtistName;
				cell.ImageView.Image = track.AlbumImage;

				return cell;
			}

			#endregion


		}
	}
}

