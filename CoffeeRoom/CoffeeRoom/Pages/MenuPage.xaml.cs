using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu = CoffeeRoom.Models.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoffeeRoom.Services;

namespace CoffeeRoom.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        private ObservableCollection<Menu> _menus;
        private bool _isLoaded = false; 

        public MenuPage ()
		{
			InitializeComponent ();
            _menus = new ObservableCollection<Menu>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!_isLoaded)
            {
                var apiServices = new ApiServices();
                var menus = await apiServices.GetMenus();
                foreach (var menu in menus)
                    _menus.Add(menu);

                _isLoaded = true; 
            }
            

            LvMenu.ItemsSource = _menus;
            BusyIndicator.IsRunning = false;
        }

        private void LvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenu = e.SelectedItem as Menu;

            if (selectedMenu != null)
            {
                var subMenus = selectedMenu.SubMenus;
                Navigation.PushAsync(new SubMenuPage(subMenus));
            }

            ((ListView)sender).SelectedItem = null;   
        }
    }
}