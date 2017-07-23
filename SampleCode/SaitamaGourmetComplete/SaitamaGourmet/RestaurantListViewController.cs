using Foundation; using System; using System.Collections.Generic; using Newtonsoft.Json.Linq; using UIKit; using CoreGraphics;  namespace SaitamaGourmet { 	public partial class RestaurantListViewController : UIViewController 	{ 		public AreaMasterMiddles targetAreaItem { get; set; } 		public List<Restaurants> restData { get; set; } 		DataSource dataSource; 		public string selectedCategory;  		public RestaurantListViewController(IntPtr handle) : base(handle) 		{ 		}  		public void SetDetailItem(AreaMasterMiddles newTargetAreaItem) 		{ 			if (targetAreaItem != null) 			{ 				targetAreaItem = newTargetAreaItem;  				ConfigureView(); 			}  		}  		void ConfigureView() 		{
			// Update the user interface for the detail item
			Title = NSBundle.MainBundle.LocalizedString("レストラン一覧", "レストラン一覧");  			restData = new List<Restaurants>(); 			dataSource = new DataSource(this);  			if (IsViewLoaded && targetAreaItem != null) 			{

				// レストラン情報取得

				RestaurantSearchParam param = new RestaurantSearchParam(); 				param.areacode_m = targetAreaItem.areacode_m; 				param.category_l = selectedCategory;  				GourmetNaviAPI gourmetApi = new GourmetNaviAPI(); 				JObject data = gourmetApi.GetRestrantData(GourmetNaviAPI.ResturantSearch, param);

				//if (data == null && data.Count <= 2)
				//{
				//	UIAlertView alert = new UIAlertView();
				//	alert.Title = "Error";
				//	alert.AddButton("OK");
				//	alert.AddButton("Cancel");
				//	alert.Message = "This should be an error message";
				//	alert.Show();
				//}
				int i = 0; 				int count = 0; 				int perPage = 0; 				if (!IsCheckNull(data["total_hit_count"])) 				{
					count = (int)data["total_hit_count"] - 4; 				}
				if (!IsCheckNull(data["hit_per_page"]))
				{
					perPage = (int)data["hit_per_page"]; 				}

				int index = 0; 				if (count > 0)
				{
					while (i < count)
					{
						if (i < count)
						{
							Restaurants rest = new Restaurants();

							try
							{
								if (!IsCheckNull(data["rest"][index]["name"]))
								{
									rest.name = (string)data["rest"][index]["name"];
								}

								if (!IsCheckNull(data["rest"][index]["name_sub"]))
								{
									rest.name_sub = (string)data["rest"][index]["name_sub"];
								}

								if (!IsCheckNull(data["rest"][index]["name_kana"]))
								{
									rest.name_kana = (string)data["rest"][index]["name_kana"];
								}

								if (!IsCheckNull(data["rest"][index]["business_hour"]))
								{
									rest.business_hour = (string)data["rest"][index]["business_hour"];
								}

								if (!IsCheckNull(data["rest"][index]["opentime"]))
								{
									rest.opentime = data["rest"][index]["opentime"].ToString();
								}

								if (!IsCheckNull(data["rest"][index]["holiday"]))
								{
									rest.holiday = (string)data["rest"][index]["holiday"];
								}

								if (!IsCheckNull(data["rest"][index]["address"]))
								{
									rest.address = (string)data["rest"][index]["address"];
								}

								if (!IsCheckNull(data["rest"][index]["tel"]))
								{
									rest.tel = (string)data["rest"][index]["tel"];
								}

								if (!IsCheckNull(data["rest"][index]["fax"]))
								{
									rest.fax = (string)data["rest"][index]["fax"];
								}

								if (!IsCheckNull(data["rest"][index]["pr"]["pr_short"]))
								{
									rest.pr_short = (string)data["rest"][index]["pr"]["pr_short"];
								}

								if (!IsCheckNull(data["rest"][index]["pr"]["pr_long"]))
								{
									rest.pr_long = (string)data["rest"][index]["pr"]["pr_long"];
								}

								if (!IsCheckNull(data["rest"][index]["access"]["line"]))
								{
									rest.line = (string)data["rest"][index]["access"]["line"];
								}

								if (!IsCheckNull(data["rest"][index]["access"]["station"]))
								{
									rest.station = (string)data["rest"][index]["access"]["station"];
								}

								if (!IsCheckNull(data["rest"][index]["access"]["station_exit"]))
								{
									rest.station_exit = (string)data["rest"][index]["access"]["station_exit"];
								}

								if (!IsCheckNull(data["rest"][index]["access"]["walk"]))
								{
									rest.walk = (string)data["rest"][index]["access"]["walk"];
								}

								if (!IsCheckNull(data["rest"][index]["access"]["note"]))
								{
									rest.note = (string)data["rest"][index]["access"]["note"];
								}

								if (!IsCheckNull(data["rest"][index]["budget"]))
								{
									rest.budget = (string)data["rest"][index]["budget"];
								}

								if (!IsCheckNull(data["rest"][index]["image_url"]["shop_image1"]))
								{
									rest.shop_image1 = (string)data["rest"][index]["image_url"]["shop_image1"];
								}

								if (!IsCheckNull(data["rest"][index]["image_url"]["shop_image2"]))
								{
									rest.shop_image2 = (string)data["rest"][index]["image_url"]["shop_image2"];
								}

								if (!IsCheckNull(data["rest"][index]["image_url"]["qrcode"]))
								{
									rest.qrcode = (string)data["rest"][index]["image_url"]["qrcode"];
								}

								if (!IsCheckNull(data["rest"][index]["url_mobile"]))
								{
									rest.url_mobile = (string)data["rest"][index]["url_mobile"];
								}

								if (!IsCheckNull(data["rest"][index]["url"]))
								{
									rest.url = (string)data["rest"][index]["url"];
								}

								if (!IsCheckNull(data["rest"][index]["credit_card"]))
								{
									rest.credit_card = (string)data["rest"][index]["credit_card"];
								}

								if (!IsCheckNull(data["rest"][index]["latitude"]))
								{
									rest.latitude = (double)data["rest"][index]["latitude"];
								}

								if (!IsCheckNull(data["rest"][index]["longitude"]))
								{
									rest.longitude = (double)data["rest"][index]["longitude"];
								}
								//rest.latitude_wgs84 = (double)data["rest"][index]["latitude_wgs84"];
								//rest.longitude_wgs84 = (double)data["rest"][index]["ongitude_wgs84"];

							}
							catch (Exception e)
							{
								Console.WriteLine(e.ToString());
								break;
							}
							index++;
							restData.Add(rest);
							dataSource.Objects.Add(rest);
						}

						i++;

						if ((i % perPage) == 0)
						{
							param.offset_page++;
							index = 0;
							try
							{
								data = gourmetApi.GetRestrantData(GourmetNaviAPI.ResturantSearch, param);
							}
							catch (Exception e)
							{
								Console.WriteLine(e.ToString());
								break;
							};
						}
					}

					RestaurantListTableView.Source = dataSource;
					((RestaurantTabViewController)(this.ParentViewController)).SetRestData(restData);
				}
				else {
					var alert = UIAlertController.Create("メッセージ", "指定され店舗の情報が存在しません。", UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, action =>
					{

						NavigationController.PopViewController(true);

					}));
					this.PresentViewController(alert, true, null);
				} 			}
		}  		private bool IsCheckNull(object o) 		{ 			if (o == null || o.ToString() == "{}") 			{ 				return true; 			} 			else { 				return false; 			} 		}  		public override void ViewDidLoad() 		{ 			base.ViewDidLoad(); 			// Perform any additional setup after loading the view, typically from a nib. 			targetAreaItem = ((RestaurantTabViewController)(this.ParentViewController)).targetAreaItem; 			selectedCategory = ((RestaurantTabViewController)(this.ParentViewController)).selectedCategory;  			ConfigureView(); 		}  		public override void ViewWillAppear(bool animated) 		{ 			base.ViewWillAppear(animated); 		}  		public override void ViewWillDisappear(bool animated) 		{ 			base.ViewWillDisappear(animated); 			((RestaurantTabViewController)(this.ParentViewController)).SetRestData(restData); 		}  		public override void DidReceiveMemoryWarning() 		{ 			base.DidReceiveMemoryWarning(); 		}  		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender) 		{ 			if (segue.Identifier == "restDetailFromList") 			{ 				var indexPath = RestaurantListTableView.IndexPathForSelectedRow; 				var item = dataSource.Objects[indexPath.Row];  				((RestDetailTabViewController)segue.DestinationViewController).SetDetailItem(item); 			} 		}  		static UIImage FromUrl(string uri) 		{ 			using (var url = new NSUrl(uri)) 			using (var data = NSData.FromUrl(url)) 				return UIImage.LoadFromData(data); 		}  		class DataSource : UITableViewSource 		{ 			NSString CellIdentifier = new NSString("Cell"); 			readonly List<Restaurants> objects = new List<Restaurants>(); 			readonly RestaurantListViewController controller;  			public DataSource(RestaurantListViewController controller) 			{ 				this.controller = controller; 			}  			public IList<Restaurants> Objects 			{ 				get { return objects; } 			}  			// Customize the number of sections in the table view. 			public override nint NumberOfSections(UITableView tableView) 			{ 				return 1; 			}  			public override nint RowsInSection(UITableView tableview, nint section) 			{ 				return objects.Count; 			}  		 			private int rowNumber { get; set; } 			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath) 			{ 				return 80; 			}  			public override void RowSelected(UITableView tableView, NSIndexPath indexPath) 			{  				controller.PerformSegue("restDetailFromList", this);  			} 			public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath) 			{ 				// Return false if you do not want the specified item to be editable. 				return true; 			}  			//Customize the appearance of table view cells. 			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) 			{  				var cell = tableView.DequeueReusableCell(CellIdentifier) as CustomVegeCell; 				if (cell == null) 				{ 					cell = new CustomVegeCell(CellIdentifier); 				} 				if (String.IsNullOrWhiteSpace(objects[indexPath.Row].shop_image1)) 				{ 					cell.UpdateCell(objects[indexPath.Row].name 					  , UIImage.FromFile("noImage2.png") 					  , objects[indexPath.Row].address, objects[indexPath.Row].station, objects[indexPath.Row].budget); 				} 				else { 					cell.UpdateCell(objects[indexPath.Row].name 					  , FromUrl(objects[indexPath.Row].shop_image1) 					  , objects[indexPath.Row].address, objects[indexPath.Row].station, objects[indexPath.Row].budget); 				} 				cell.BackgroundColor = UIColor.Clear;    				return cell;   			}  		} 	}   	// Custom Cell  	public class CustomVegeCell : UITableViewCell 	{ 		UILabel headingLabel; 		UILabel subheadingLabel; 		UILabel subheadingLabel1; 		UILabel subheadingLabel2;  		UIImageView imageView;   		public CustomVegeCell(NSString Cell) : base(UITableViewCellStyle.Default, Cell)  		{ 			imageView = new UIImageView(); 			headingLabel = new UILabel() 			{ 				Font = UIFont.FromName("Cochin-BoldItalic", 17f), 				TextColor = UIColor.FromRGB(127, 51, 0), 				//BackgroundColor = UIColor.Clear 			} ; 			subheadingLabel = new UILabel() 			{ 				Font = UIFont.FromName("AmericanTypewriter", 12f), 				TextColor = UIColor.FromRGB(80, 80, 80), 				//TextAlignment = UITextAlignment.Center, 				BackgroundColor = UIColor.Clear 			} ;  			subheadingLabel1 = new UILabel() 			{ 				Font = UIFont.FromName("AmericanTypewriter", 11f), 				TextColor = UIColor.FromRGB(10, 10, 10), 			} ;  			subheadingLabel2 = new UILabel() 			{ 				Font = UIFont.FromName("AmericanTypewriter", 12f), 				TextColor = UIColor.Red, 			} ;  			headingLabel.Lines = 0; 			headingLabel.LineBreakMode = UILineBreakMode.CharacterWrap; 			headingLabel.SizeToFit();  			subheadingLabel.Lines = 0; 			subheadingLabel.LineBreakMode = UILineBreakMode.CharacterWrap; 			subheadingLabel.SizeToFit();  			subheadingLabel1.Lines = 0; 			subheadingLabel1.LineBreakMode = UILineBreakMode.CharacterWrap; 			subheadingLabel1.SizeToFit();  			ContentView.AddSubviews(new UIView[] { imageView, headingLabel, subheadingLabel, subheadingLabel1, subheadingLabel2 });  		}  		public void UpdateCell(string caption, UIImage image, string subtitle, string subtitle1, string subtitle2) 		{  			headingLabel.Text = caption; 			imageView.Image = image; 			subheadingLabel.Text = subtitle; 			subheadingLabel1.Text = "最寄駅:" + subtitle1; 			subheadingLabel2.Text = "予算:" + subtitle2 + "円～";   		}  		public override void LayoutSubviews() 		{ 			base.LayoutSubviews(); 			imageView.Frame = new CGRect(3, 2, 70, ContentView.Bounds.Height - 3); 			headingLabel.Frame = new CGRect(ContentView.Bounds.Width - 300, -2, 300, 40); 			subheadingLabel.Frame = new CGRect(ContentView.Bounds.Width - 300, 30, 300, 35); 			subheadingLabel1.Frame = new CGRect(ContentView.Bounds.Width - 135, 45, 300, 50); 			subheadingLabel2.Frame = new CGRect(ContentView.Bounds.Width - 300, 45, 300, 50); 		} 	} } 







