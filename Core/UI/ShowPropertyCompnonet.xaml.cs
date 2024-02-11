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
    /// Логика взаимодействия для ShowPropertyCompnonet.xaml
    /// </summary>
    public partial class ShowPropertyCompnonet : UserControl
    {
        public object PropName
        {
            get { return (object)GetValue(PropNameProperty); }
            set { SetValue(PropNameProperty, value); }
        }
        public static readonly DependencyProperty PropNameProperty =
            DependencyProperty.Register(nameof(PropName), typeof(object), typeof(ShowPropertyCompnonet),
              new PropertyMetadata(null));
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(object), typeof(ShowPropertyCompnonet),
              new PropertyMetadata(null));
        public ShowPropertyCompnonet()
        {
            InitializeComponent();
        }
    }
}
