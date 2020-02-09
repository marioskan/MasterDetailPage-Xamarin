using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();
            menuList.Add(new MasterPageItem() { Title = "First", Icon = "", TargetType = typeof(FirstPage) });
            menuList.Add(new MasterPageItem() { Title = "Second", Icon = "", TargetType = typeof(SecondPage) });

            navigationList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FirstPage)));

            this.BindingContext = new
            {
                Footer = "Example"
            };
        }

        private void NavigationList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;

        }
    }
}
