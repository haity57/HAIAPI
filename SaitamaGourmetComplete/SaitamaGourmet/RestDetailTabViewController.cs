using Foundation;
using System;
using UIKit;

namespace SaitamaGourmet
{
    public partial class RestDetailTabViewController : UITabBarController
    {
		public Restaurants targetRestData { get; set; }
        public RestDetailTabViewController (IntPtr handle) : base (handle)
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
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
		}
    }
}