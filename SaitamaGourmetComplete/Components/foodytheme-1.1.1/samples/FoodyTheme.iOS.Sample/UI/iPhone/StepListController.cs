// This file has been autogenerated from parsing an Objective-C header file added in Xcode.using System;
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
	public partial class StepListController : UIViewController {
		public StepListController (IntPtr handle) : base (handle)
		{
		}

		Recipe recipe;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			recipe = DataLoader.GetRecipes () [0];

			StepsTableView.WeakDelegate = this;
			StepsTableView.WeakDataSource = this;
			StepsTableView.BackgroundColor = UIColor.Clear;
			StepsTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			FoodyTheme.Apply (View);

			Title = "Steps";
		}

		[Export ("tableView:numberOfRowsInSection:")]
		int NumberOfRows (UITableView tableView, int section)
		{
			return recipe.PreparationSteps.Length;
		}

		const string CellIdentifier = "StepListCell";

		[Export ("tableView:cellForRowAtIndexPath:")]
		UITableViewCell CellForRow (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (CellIdentifier) as StepListCell;
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.Init (recipe, indexPath.Row);

			return cell;
		}

		[Export ("tableView:heightForRowAtIndexPath:")]
		nfloat HeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			var ns = new NSString (recipe.PreparationSteps[indexPath.Row]);
			var stepSize = ns.StringSize (UIFont.SystemFontOfSize(14), new CGSize (220, 1000));

			return 50 + stepSize.Height;
		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			ReleaseDesignerOutlets ();
		}
	}
}