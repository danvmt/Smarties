using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smarties
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<object, Page>(this, "NAV", OnNavigate);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<object, Page>(this, "NAV");
        }

        void OnNavigate(object sender, Page target)
        {
            Detail = new NavigationPage(target);
            IsPresented = false;
        }
    }
}
