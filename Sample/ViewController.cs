using System;

using UIKit;
using Hyphenate.iOS.UI;
using Hyphenate.iOS.Lib;
using Foundation;

namespace Sample
{
    public partial class ViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Demo";
            View.BackgroundColor = UIColor.White;

            var btn = new UIButton();
            btn.Frame = new CoreGraphics.CGRect(100, 100, 100, 100);
            btn.BackgroundColor = UIColor.Yellow;
            btn.SetTitle("Btn", UIControlState.Normal);
            btn.AddTarget((sender, e) =>
            {
                var page = new EaseConversationListViewController();
                NavigationController.PushViewController(page, true);
            }, UIControlEvent.TouchUpInside);
            View.AddSubview(btn);
        }
    }

    public partial class ChatViewController : EaseMessageViewController, IEMUserListViewControllerDataSource
    {
        [Export("userListViewController:modelForBuddy:")]
        public IIUserModel UserListViewController(EaseUsersListViewController userListViewController, string buddy)
        {
            var x = new EMVideoMessageBody();
            return new EaseUserModel(buddy);
        }

    }
}
