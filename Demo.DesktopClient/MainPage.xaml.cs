using Demo.Desktop.Model;
using Demo.Desktop.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.DesktopClient
{
    public partial class MainPage : ContentPage
    {
        public Context Context { get; set; }

        public MainPage(Context context)
        {
            context.Database.Migrate();

            Context = context ?? throw new ArgumentNullException(nameof(context));
            var setting = context.Settings.FirstOrDefault();

            InitializeComponent();

            if (setting != null)
            {
                DemoServerBaseUrlEditor.Text = setting.DemoServerBaseUrl;
            }
        }

        private void SaveButton_OnClicked(object sender, EventArgs e)
        {
            var setting = Context.Settings.FirstOrDefault();
            setting.DemoServerBaseUrl = DemoServerBaseUrlEditor.Text;
            Context.SaveChanges();
        }
    }
}