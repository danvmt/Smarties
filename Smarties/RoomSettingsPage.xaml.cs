using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Smarties
{
    public partial class RoomSettingsPage : ContentPage
    {
        private string selectedHue;
        private string selectedBeacon;
        private string roomName;
        private int ID;
        private List<string> hueList = new List<string>() { "Hue1", "HueTwo", "Hue3" };
        private List<string> beaconList = new List<string>() { "Beacone", "Beacon2", "Beacon3" };

        public List<string> HueList => hueList;
        public List<string> BeaconList => beaconList;

        public string SelectedHue 
        {
            get { return selectedHue;; }
            set
            {
                selectedHue = value;
            }
        }
        public string SelectedBeacon
        {
            get { return selectedBeacon; ; }
            set
            {
                selectedBeacon = value;
            }
        }
        public string RoomName
        {
            get { return roomName; ; }
            set
            {
                roomName = value;
            }
        }


        public RoomSettingsPage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        public RoomSettingsPage(Room room)
        {

            BindingContext = this;

            if (room != null)
            {
                roomName = room.RoomName;
                selectedHue = room.Hue;
                selectedBeacon = room.Beacon;
                ID = room.ID;
            }

            InitializeComponent();

        }

        private void Handle_Completed(object sender, EventArgs e)
        {
            //var room = RoomNameEntry.Text;
            //var beacon = BeaconPicker.SelectedItem.ToString();
            //var hue = HuePicker.SelectedItem.ToString();
            var room = RoomName;
            var beacon = SelectedBeacon;
            var hue = SelectedHue;

            //Add item
            var newRoom = new Room { ID = ID, RoomName = room, Beacon = beacon, Hue = hue };

            AppContext.RoomDatabase.SaveItemAsync(newRoom);

            Navigation.PopToRootAsync();

        }
    }
}
