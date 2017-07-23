using Foundation;
using System;
using UIKit;
using System.CodeDom.Compiler;

namespace SaitamaGourmet
{

	public partial class RestDetailViewController : UIViewController
	{
		
		public Restaurants targetRestData { get; set; }
		public RestDetailViewController(IntPtr handle) : base(handle)
		{
		}

		public void SetDetailItem(Restaurants newTargetRestaurant)
		{
			if (newTargetRestaurant != null)
			{
				targetRestData = newTargetRestaurant;
			}
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			restNameLabel.Text = targetRestData.name;
			telLabel.Text = targetRestData.tel;
			lineLabel.Text = targetRestData.line;
			stationLabel.Text = targetRestData.station;
			stationExitLabel.Text = targetRestData.station_exit;
			walkLabel.Text = targetRestData.walk;
			addrLabel.Text = targetRestData.address;
			prShort.Text = targetRestData.pr_short;

			restImage.Image = FromUrl(targetRestData.shop_image1);

			string[] tableItems = new string[] {
				
				"[営業情報]",
				targetRestData.opentime,
				targetRestData.holiday,
				targetRestData.business_hour,

				"[平均予算]",
				targetRestData.budget,

				"[カード]",
				targetRestData.credit_card,

				"[その他]",
				targetRestData.note,

			};

			if (tableItems != null){
				restTotalInfo.Source = new TableSource(tableItems);
			}
		}

		static UIImage FromUrl(string uri)
		{
			using (var url = new NSUrl(uri))
			using (var data = NSData.FromUrl(url))
				return UIImage.LoadFromData(data);
		}

		public class TableSource : UITableViewSource
		{

			string[] TableItems;
			string CellIdentifier = "TableCell";

			public TableSource(string[] items)
			{
				TableItems = items;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return TableItems.Length;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
				string item = TableItems[indexPath.Row];

				//---- if there are no cells to reuse, create a new one
				if (cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
				}
				if (item != null)
				{
					cell.TextLabel.Text = item;
				}
				else
				{
					cell.TextLabel.Text = "情報無し";
				}

				return cell;
			}
		}
	}
}