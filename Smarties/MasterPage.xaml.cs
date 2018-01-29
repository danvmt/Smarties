using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smarties
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        //public ListView ListView { get { return listView; } }


        void OnHomeClicked(object sender, EventArgs e)
        {
            //(Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new WelcomePage());
            //(Application.Current.MainPage as MasterDetailPage).IsPresented = false;
            //rootPage.Detail = new NavigationPage(new WelcomePage());
            //rootPage.IsPresented = false;

            MessagingCenter.Send<object, Page>(this, "NAV", new WelcomePage());
        }

        void OnRoomsClicked(object sender, EventArgs e)
        {
            //rootPage.Detail = new NavigationPage(new RoomListPage());
            //rootPage.IsPresented = false;

            MessagingCenter.Send<object, Page>(this, "NAV", new RoomListPage());
        }
    }


}
