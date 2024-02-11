using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewCryptoApp.Core.UI
{
    /// <summary>
    /// Логика взаимодействия для SearchBarComponent.xaml
    /// </summary>
    public partial class SearchBarComponent : UserControl
    {
        public object SearchCommand
        {
            get { return (object)GetValue(SearchCommandProperty); }
            set{ SetValue(SearchCommandProperty, value); }
        }
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register(nameof(SearchCommand), typeof(object), typeof(SearchBarComponent),
              new PropertyMetadata(null));

        public object TextSearch
        {
            get { return (object)GetValue(TextSearchProperty); }
            set { SetValue(TextSearchProperty, value); }
        }
        public static readonly DependencyProperty TextSearchProperty =
            DependencyProperty.Register(nameof(TextSearch), typeof(object), typeof(SearchBarComponent),
              new PropertyMetadata(null));
        public SearchBarComponent()
        {
            InitializeComponent();
        }
    }
}
