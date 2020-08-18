using Newtonsoft.Json;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test__API;
using Test__API.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_API
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user_page : ContentPage
    {
        private SQLiteConnection conn;
        public UserData userData;
        readonly User_PageViewModel userPageViewModel;
        public user_page()
        {
                userPageViewModel = new User_PageViewModel();
                InitializeComponent();
                BindingContext = userPageViewModel;
              


            conn = DependencyService.Get<ISQLite>().GetConnection();
            //conn.CreateTable<UserData>();
            // InitializeComponent();

             //GetUserData();

        }

        public void GetUserData()
        {
            //HttpClient client = new HttpClient();

            //var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

            //var users = JsonConvert.DeserializeObject<List<UserData>>(response);

            var data = (from ud in conn.Table<UserData>() select ud);

            UserDataListView.ItemsSource = data;

            //await App.Database.SaveNoteAsync();
        }


        //private async void SaveButton_Clicked(object sender, EventArgs e)
        //{
        //    HttpClient client = new HttpClient();

        //    var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

        //    var users = JsonConvert.DeserializeObject<List<UserData>>(response);

        //    foreach (UserData user in users)
        //    {
        //        conn.Insert(user);   // add to db your each user
        //    }
        //} 

        //private void ShowButton_Clicked(object sender, EventArgs e)
        //{
        //    var data = (from ud in conn.Table<UserData>() select ud);
        //    UserDataListView.ItemsSource = data;
        //}
    }
}