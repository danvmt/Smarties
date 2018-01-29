using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smarties
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //MessagingCenter.Send<object, string>(this, "NAV", "ROOMS");
        }
    }
}
