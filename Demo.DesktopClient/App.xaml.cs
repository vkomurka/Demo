using Demo.Desktop.Model;
using Demo.DesktopClient.Pages;
using Microsoft.EntityFrameworkCore;

namespace Demo.DesktopClient;

public partial class App : Application
{
    public App(Context context, MainPage mainPage)
    {
        InitializeComponent();

        MainPage = new LoginPage();
    }
}