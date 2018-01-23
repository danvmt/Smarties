using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;

namespace Smarties
{
    public partial class SmartiesPage : ContentPage
    {

        ObservableCollection<Room> rooms = new ObservableCollection<Room>();


        public SmartiesPage()
        {
            InitializeComponent();

            listView.ItemsSource = rooms;

            //rooms.Add(new Room { RoomName = "Room 1", Beacon = "Beacon1", Hue = "Hue1" });
            //rooms.Add(new Room { RoomName = "Room 2", Beacon = "Bed Room Beacon", Hue = "Bed Room Hue" });
            //rooms.Add(new Room { RoomName = "Room 3", Beacon = "Office Beacon", Hue = "Office Hue" });

        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoomSettingsPage());
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            //Console.WriteLine(sender);

        }


        async void OnClearClicked(object sender, EventArgs e)
        {
            await AppContext.RoomDatabase.DropTable();
        }
    }
}
