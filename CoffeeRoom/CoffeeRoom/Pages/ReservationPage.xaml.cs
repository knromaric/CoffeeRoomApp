using CoffeeRoom.Models;
using CoffeeRoom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeRoom.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReservationPage : ContentPage
	{
		public ReservationPage ()
		{
			InitializeComponent ();
		}

        private async void BtnBookTable_Clicked(object sender, EventArgs e)
        {
            var reservation = new Reservation
            {
                Name = EntName.Text,
                Email = EntEmail.Text,
                Phone = EntPhone.Text,
                TotalPeople = EntTotalPeople.Text,
                Date = DpBookingDate.Date.ToShortDateString(),
                Time = TpBookingTime.Time.ToString()
            };

            var apiServices = new ApiServices();
            var isTableBooked = await apiServices.ReserveTable(reservation);
            if (isTableBooked)
            {
                await DisplayAlert("Hi", "Table booked successfully", "OK");

            }
            else
            {
                await DisplayAlert("Oops", "something went Wrong", "Ok");
            }
        }
    }
}