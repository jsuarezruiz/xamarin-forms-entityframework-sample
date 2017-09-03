using System;
using System.IO;
using ToDoEF.iOS.Services.EF;
using ToDoEF.Services.EF;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace ToDoEF.iOS.Services.EF
{
    public class DatabaseService : IDatabaseService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments), 
                "..", 
                "Library", 
                AppSettings.DatabaseName);
        }
    }
}