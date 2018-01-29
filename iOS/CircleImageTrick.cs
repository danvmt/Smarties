using System;
using UIKit;
namespace Smarties.iOS
{
    public class CircleImageTrick
    {

        private void DoTheTrick()
        {
            var imageView = new UIImageView();

            imageView.Image = new UIImage("homer.jpg");

            imageView.Layer.CornerRadius = 30;
        }

    }
}
