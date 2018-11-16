using CoffeeRoom.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeRoom.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubMenuPage : ContentPage
	{
        private ObservableCollection<SubMenu> _subMenus;  

        public SubMenuPage(List<SubMenu> subMenus)
        {
            InitializeComponent();
            _subMenus = new ObservableCollection<SubMenu>();

            foreach (var subMenu in subMenus)
                _subMenus.Add(subMenu);

            LvSubMenu.ItemsSource = _subMenus;
        }
    }
}