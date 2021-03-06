// This file has been autogenerated from parsing an Objective-C header file added in Xcode.using Xamarin.Themes;
using System;
using Xamarin.Themes;


#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;

using System.Drawing;
using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace ThemeSample {
	public partial class DetailThemeController : UIViewController {
		public DetailThemeController (IntPtr handle) : base (handle)
		{
		}

		UIButton btnAction;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			FoodyTheme.Apply (View);

			var edit = new UIBarButtonItem ("Edit", UIBarButtonItemStyle.Bordered, null, null);
			NavigationItem.SetRightBarButtonItem (edit, false);

			btnAction = new UIButton (UIButtonType.Custom);
			btnAction.SetBackgroundImage (FoodyTheme.SharedTheme.ButtonImage, UIControlState.Normal);
			btnAction.SetTitle ("Press me!", UIControlState.Normal);
			btnAction.Frame = new CGRect (0, 0, 200, 40);
			btnAction.TouchUpInside += HandleTouchUpInside;
			btnAction.Center = ScrollView.Center;
			ScrollView.AddSubview (btnAction);

			TableSteps.WeakDelegate = this;
			TableSteps.WeakDataSource = this;
			
		}

		[Export ("tableView:numberOfRowsInSection:")]
		int NumberOfRows (UITableView tableView, int section)
		{
			return Recipe.PreparationSteps.Length;
		}

		[Export ("tableView:heightForRowAtIndexPath:")]
		nfloat HeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			var ns = new NSString (Recipe.PreparationSteps[indexPath.Row]);
			var stepSize = ns.StringSize (UIFont.SystemFontOfSize(14), new CGSize (220, 1000));

			return 50 + stepSize.Height;
		}

		const string CellIdentifier = "StepListCell";

		[Export ("tableView:cellForRowAtIndexPath:")]
		UITableViewCell CellForRow (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (CellIdentifier) as StepListCell;
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.Init (Recipe, indexPath.Row);

			return cell;
		}

		void HandleTouchUpInside (object sender, EventArgs e)
		{
			(new UIAlertView ("Message", "You pressed the button", null, "OK", null)).Show ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.Title = Recipe.Name;

			DishImage.Image = Recipe.Image;

			string ingridients = string.Empty;
			foreach (var ing in Recipe.Ingredients) {
				ingridients += ing + "\n";
			}
			IngredientsTextView.Text = ingridients;


			nfloat tableHeight = 0f;
			foreach (var item in Recipe.PreparationSteps) {
				var ns = new NSString (item);				
				var stepSize = ns.StringSize (UIFont.SystemFontOfSize(14), new CGSize (220, 1000));
				tableHeight += 50 + stepSize.Height;
			}

			var tableFrame = TableSteps.Frame;
			tableFrame.Height = tableHeight;
			TableSteps.Frame = tableFrame;

			ScrollView.ContentSize = new CGSize (320, 470 + tableHeight);

			var btnFrame = btnAction.Frame;
			btnFrame.Y = ScrollView.ContentSize.Height - 50;
			btnAction.Frame = btnFrame;


		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			ReleaseDesignerOutlets ();

			btnAction.TouchUpInside -= HandleTouchUpInside;
			btnAction.Dispose ();
			btnAction = null;
		}

		public Recipe Recipe { get ; set; }
	}
}
