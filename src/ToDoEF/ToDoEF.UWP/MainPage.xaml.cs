namespace ToDoEF.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new ToDoEF.App());
        }
    }
}
