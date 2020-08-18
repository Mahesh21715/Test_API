using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Test__API.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(TestAPI_Droid))]
namespace Test__API.Droid
{
    public class TestAPI_Droid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "MyUserDatabase.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbPath, dbName);

            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}