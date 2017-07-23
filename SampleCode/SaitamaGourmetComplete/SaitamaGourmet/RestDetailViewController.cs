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

        public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CallButton.TouchUpInside += (sender, e) =>
			{
				var alertCotroller = UIAlertController.Create("お店に電話をかける",targetRestData.name+"\n"+targetRestData.tel, UIAlertControllerStyle.Alert);
				// Create the actions.
				alertCotroller.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction =>
															  Console.WriteLine("The 'Okay/Cancel' alert's cancel action occured.")));

				alertCotroller.AddAction(UIAlertAction.Create("Call", UIAlertActionStyle.Default, alertAction => UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + targetRestData.tel))));
				PresentViewController(alertCotroller, true, null);

			};
			targetRestData = ((RestDetailTabViewController)(this.ParentViewController)).targetRestData;

			restNameLabel.Text = targetRestData.name;
			restNameLabel.AdjustsFontSizeToFitWidth = true;
			telLabel.Text = targetRestData.tel;
			telLabel.Text = targetRestData.tel;
			prShort.Text = targetRestData.pr_short;

			string labelDammy = targetRestData.line + targetRestData.station + " " + targetRestData.walk + "分";
			trafficLabel.Text = labelDammy;
			trafficLabel.Lines = 0;
			trafficLabel.SizeToFit();
			trafficLabel.AdjustsLetterSpacingToFitWidth = true;

			//string UrlMobile = "ぐるなびページへ　" + targetRestData.url_mobile;
			//labelUrlMobile.Text = UrlMobile;

			if (targetRestData.shop_image1 != null)
			{
				restImage.Image = FromUrl(targetRestData.shop_image1);
			}
			else {
				restImage.Image = UIImage.FromFile("noImage2BIG.png");
			}
			string[] tableItems = new string[] {
				
				"[営業情報]",
				targetRestData.opentime,
				targetRestData.holiday,
				targetRestData.business_hour,

				"[住所]",
				targetRestData.address,

				"[予算]",
				targetRestData.budget+"円",

				"[カード]",
				targetRestData.credit_card,

				"[その他]",
				targetRestData.note

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
			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return 30;
			}
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
				string item = TableItems[indexPath.Row];



				if (cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);


				}
				if (item != null)
				{
					cell.TextLabel.Text = item;
					cell.TextLabel.Font = UIFont.SystemFontOfSize(13f);


						//cell.TextLabel.TextColor = UIColor.Red;
						//cell.TextLabel.Font = UIFont.PreferredTitle3;


				}
				if(item == null)
				{
					cell.TextLabel.Text = "情報無し";
					cell.TextLabel.Font = UIFont.SystemFontOfSize(13f);
				}

				return cell;
			}
		}
	}
}