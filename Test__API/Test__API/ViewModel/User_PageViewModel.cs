using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using Test_API;
using Xamarin.Forms;
using Test_API.View;
using System.Collections.ObjectModel;

namespace Test__API.ViewModel
{

    public class User_PageViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection conn;
        public UserData userData;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<UserData> UsersList { get; set; }

        public User_PageViewModel()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<UserData>();
            
        }

        public Command SaveCommand
        {
            get
            {
                return new Command(SaveData);
            }
        }

        public Command ShowCommand
        {
            get
            {
                return new Command(ShowData);
            }
        }



        private async void SaveData()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

            var users = JsonConvert.DeserializeObject<List<UserData>>(response);

            foreach (UserData user in users)
            {
                conn.Insert(user);   // add to db your each user
            }
        }

        private void ShowData()
        {
            var data = (from ud in conn.Table<UserData>() select ud);
            UsersList = new ObservableCollection<UserData>(data);
            Console.WriteLine("Total Items in DataBase : - " + UsersList.Count());
            conn.DropTable<UserData>();

            //var dael = (from conn.Delete<UserData>() 
            //user_page u = new user_page();
            //u.GetUserData();  
        }
    }
}


