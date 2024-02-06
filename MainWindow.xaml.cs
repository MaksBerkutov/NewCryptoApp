using NewCryptoApp.Core.MVVM.View;
using System.Windows;


namespace NewCryptoApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Core.Navigate.RegisterFrame(ref MainFrame);
            RegistryPages();
            Core.Navigate.GoTo(nameof(MainPageView));
        }

        private void RegistryPages()
        {
            Core.Navigate.RegisterPage<MainPageView>();
            Core.Navigate.RegisterPage<InfoPageView>();
        }
    }
}
