using System;

using UIKit;

namespace RestaurantsAPI.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Call API
            Restaurants restaurants = new Restaurants();
            string test = restaurants.getRestaurantsByCoordinates(35.6915, 139.7081).ToString();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", count++);
				// Button.SetTitle(title, UIControlState.Normal);
                Button.SetTitle(test, UIControlState.Normal);
			};
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
