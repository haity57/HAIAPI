using System;

using System.Net;
using UIKit;
using Newtonsoft.Json.Linq;

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
            JObject test = restaurants.getRestaurantsByCoordinates(35.6915, 139.7081);

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", count++);
                // Button.SetTitle(title, UIControlState.Normal);
                for (int i = 0; i < test.Count; i++)
                {
                    Button.SetTitle(test["rest"][i]["name"].ToString(), UIControlState.Normal);
                    break;
                }
			};
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
