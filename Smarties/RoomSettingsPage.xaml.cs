using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Smarties
{
    public partial class RoomSettingsPage : ContentPage
    {
        //string selectedHue;
        //string selectedBeacon;
        private List<string> hueList = new List<string>() { "Hue1", "HueTwo", "Hue3" };
        private List<string> beaconList = new List<string>() { "Beacone", "Beacon2", "Beacon3" };
        //private List<Beacon> beaconList = new List<Beacon>();
        private ObservableCollection<Room> rooms;

        //public List<string> HueList => hueList;

        public List<string> HueList => hueList;
        public List<string> BeaconList => beaconList;


        public RoomSettingsPage()
        {
            InitializeComponent();
        }

        public RoomSettingsPage(ObservableCollection<Room> rooms)
        {


            this.rooms = rooms;

            BindingContext = this;

            InitializeComponent();

            //beaconList.Add(new Beacon { BeaconName = "Beacone" });

            //HuePicker.SetBinding(Picker.ItemsSourceProperty, "hueList");
            //BeaconPicker.SetBinding(Picker.ItemsSourceProperty, "beaconList");
        }

        private void Handle_Completed(object sender, EventArgs e)
        {
            var room = RoomNameEntry.Text;
            var beacon = BeaconPicker.SelectedItem.ToString();
            var hue = HuePicker.SelectedItem.ToString();

            //Add item
            var newRoom = new Room { RoomName = room, Beacon = beacon, Hue = hue };

            AppContext.RoomDatabase.SaveItemAsync(newRoom);

            Navigation.PopToRootAsync();

        }
    }
}
