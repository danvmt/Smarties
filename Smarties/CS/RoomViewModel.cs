using System;
using System.Collections.Generic;

namespace Smarties
{
    public class RoomViewModel : BaseViewModel
    {
        private Room room;

        public RoomViewModel(Room room)
        {
            this.room = room;

            RoomName = room.RoomName;
            SelectedHue = room.Hue;
            SelectedBeacon = room.Beacon;
        }

        private List<string> hueList = new List<string>() { "Hue1", "HueTwo", "Hue3" };
        private List<string> beaconList = new List<string>() { "Beacone", "Beacon2", "Beacon3" };

        public List<string> HueList => hueList;
        public List<string> BeaconList => beaconList;


        string selectedHue;
        public string SelectedHue
        {
            get {  return selectedHue; }
            set
            {
                selectedHue = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }

        string selectedBeacon;
        public string SelectedBeacon
        {
            get { return selectedBeacon; }
            set
            {
                selectedBeacon = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }

        string roomName;
        public string RoomName
        {
            get { return roomName; }
            set
            {
                roomName = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public bool IsValid
        {
            get
            {
                if (SelectedHue != null &&
                    SelectedBeacon != null &&
                    !string.IsNullOrWhiteSpace(RoomName))
                    return true;
                else
                    return false;
            }
        }

        public string Title
        {
            get 
            {
                return room.ID == 0 ? "New Room" : RoomName;
            }
        }

        public Room CreateRoom()
        {
            return new Room { ID = room.ID, RoomName = RoomName, Beacon = SelectedBeacon, Hue = SelectedHue };
        }
    }
}
