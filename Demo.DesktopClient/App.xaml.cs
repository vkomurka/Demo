using Demo.Desktop.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo.DesktopClient
{
    public partial class App : Application
    {
        public App(Context context, MainPage mainPage)
        {
            InitializeComponent();

            MainPage = mainPage;
        }
    }
}