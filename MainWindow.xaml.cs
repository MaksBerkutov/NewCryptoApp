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
            Core.Navigate.Navigate.RegisterFrame(ref MainFrame);
            RegistryPages();
            Core.Navigate.Navigate.GoTo(nameof(Page1));
        }

        private void RegistryPages()
        {
            Core.Navigate.Navigate.RegisterPage<Page1>();
            Core.Navigate.Navigate.RegisterPage<Page2>();
        }
    }
}
