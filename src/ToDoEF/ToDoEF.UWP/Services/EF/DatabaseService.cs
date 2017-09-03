using System.IO;
using ToDoEF.Services.EF;
using ToDoEF.UWP.Services.EF;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace ToDoEF.UWP.Services.EF
{
    public class DatabaseService : IDatabaseService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(
                Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                ToDoEF.AppSettings.DatabaseName);
        }
    }
}
