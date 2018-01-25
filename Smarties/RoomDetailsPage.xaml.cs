using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Smarties
{
    public partial class RoomDetailsPage : ContentPage
    {
        RoomViewModel vm;

        public RoomDetailsPage(RoomViewModel vm)
        {
            this.vm = vm;
            BindingContext = vm;

            InitializeComponent();
        }

        private void Handle_Completed(object sender, EventArgs e)
        {

            Room newRoom = vm.CreateRoom();

            AppContext.RoomDatabase.SaveItemAsync(newRoom);

            Navigation.PopToRootAsync();
        }
    }
}
