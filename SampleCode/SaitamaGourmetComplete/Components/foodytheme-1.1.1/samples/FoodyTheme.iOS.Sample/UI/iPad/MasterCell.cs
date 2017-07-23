// This file has been autogenerated from parsing an Objective-C header file added in Xcode.using System;
using System;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
#endif

namespace ThemeSample {
	public partial class MasterCell : UITableViewCell {
		public MasterCell (IntPtr handle) : base (handle)
		{
		}

		public override void SetSelected (bool selected, bool animated)
		{
			var bg = UIImage.FromFile ("ipad-menu-item" + (selected ? "-selected" : string.Empty) + ".png");
			var count = UIImage.FromFile ("ipad-menu-count" + (selected ? "-selected" : string.Empty) + ".png");

			BgImageView.Image = bg;
			CountBg.Image = count;

			DishLabel.TextColor = selected ? UIColor.White : UIColor.Black;
			CountLabel.TextColor = selected ? UIColor.Black : UIColor.White;
		
			base.SetSelected (selected, animated);
		}

		public void Init (Recipe recipe)
		{
			if (recipe == null)
				throw new ArgumentNullException ("recipe");
			DishLabel.Text = recipe.Name;
		}

		protected override void Dispose (bool disposing)
		{
			ReleaseDesignerOutlets ();
			base.Dispose (disposing);
		}
	}
}
