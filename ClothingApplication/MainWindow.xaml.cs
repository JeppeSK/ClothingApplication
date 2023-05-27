using ClothingApplication.DAL;
// using ClothingApplication.Migrations;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;


namespace ClothingApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

 //           var initializer = new MigrateDatabaseToLatestVersion<ClothContext, Configuration>();
 //           Database.SetInitializer(initializer);

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
