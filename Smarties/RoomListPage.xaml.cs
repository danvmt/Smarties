﻿using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Smarties
{
    public partial class RoomListPage : ContentPage
    {
        
        public RoomListPage()
        {
            InitializeComponent();
        }


        async void OnButtonClicked(object sender, EventArgs e)
        {
            var room = new Room();
            var vm = new RoomViewModel(room);
            var roomDetailsPage = new RoomDetailsPage(vm);
            await Navigation.PushAsync(roomDetailsPage);
        }

        async void OnSettingsClicked(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            Room room = mi.CommandParameter as Room;
            RoomViewModel vm = new RoomViewModel(room);
            await Navigation.PushAsync(new RoomDetailsPage(vm));
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            Room room = mi.CommandParameter as Room;
            await AppContext.RoomDatabase.DeleteItemAsync(room);
            SetItemsSource();
        }

        async void OnClearClicked(object sender, EventArgs e)
        {
            await AppContext.RoomDatabase.DropTable();
            await InitDBAsync();
            SetItemsSource();
        }

        async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            Room room = e.SelectedItem as Room;
            RoomViewModel vm = new RoomViewModel(room);
            await Navigation.PushAsync(new RoomDetailsPage(vm));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (AppContext.RoomDatabase == null)
            {
                await InitDBAsync();
            }
           
            SetItemsSource();
        }

        private async void SetItemsSource()
        {
            listView.ItemsSource = await AppContext.RoomDatabase.GetItemsAsync();
        }

        private async Task InitDBAsync()
        {
            var fileHelperService = DependencyService.Get<IFileHelper>();
            if (fileHelperService == null)
            {
                return;
            }

            var databaseFilePath = fileHelperService.GetLocalFilePath("RoomSQLite.db3");

            AppContext.RoomDatabase = new RoomDatabase(databaseFilePath);

            var roomList = await AppContext.RoomDatabase.GetItemsAsync();


            if (roomList.Count < 3)
            {
                Room room1 = new Room { RoomName = "Room 1", Beacon = "Beacon1", Hue = "Hue1" };
                Room room2 = new Room { RoomName = "Room 2", Beacon = "Bed Room Beacon", Hue = "Bed Room Hue" };
                Room room3 = new Room { RoomName = "Room 3", Beacon = "Office Beacon", Hue = "Office Hue" };

                await AppContext.RoomDatabase.SaveItemAsync(room1);
                await AppContext.RoomDatabase.SaveItemAsync(room2);
                await AppContext.RoomDatabase.SaveItemAsync(room3);
            }
        }
    }
}
