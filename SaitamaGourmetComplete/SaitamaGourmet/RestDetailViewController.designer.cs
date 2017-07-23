// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SaitamaGourmet
{
    [Register ("RestDetailViewController")]
    partial class RestDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CallButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel prShort { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView restImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel restNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView restTotalInfo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel telLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel trafficLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CallButton != null) {
                CallButton.Dispose ();
                CallButton = null;
            }

            if (prShort != null) {
                prShort.Dispose ();
                prShort = null;
            }

            if (restImage != null) {
                restImage.Dispose ();
                restImage = null;
            }

            if (restNameLabel != null) {
                restNameLabel.Dispose ();
                restNameLabel = null;
            }

            if (restTotalInfo != null) {
                restTotalInfo.Dispose ();
                restTotalInfo = null;
            }

            if (telLabel != null) {
                telLabel.Dispose ();
                telLabel = null;
            }

            if (trafficLabel != null) {
                trafficLabel.Dispose ();
                trafficLabel = null;
            }
        }
    }
}