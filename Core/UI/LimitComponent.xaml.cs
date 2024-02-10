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
    /// Логика взаимодействия для LimitComponent.xaml
    /// </summary>
    public partial class LimitComponent : UserControl
    {
        public object Limit
        {
            get { return (object)GetValue(LimitProperty); }
            set
            { SetValue(LimitProperty, value); }
        }
        public static readonly DependencyProperty LimitProperty =
            DependencyProperty.Register(nameof(Limit), typeof(object), typeof(LimitComponent),
              new PropertyMetadata(null));

        public object RefreshCommand
        {
            get { return (object)GetValue(RefreshCommandProperty); }
            set { SetValue(RefreshCommandProperty, value); }
        }
        public static readonly DependencyProperty RefreshCommandProperty =
            DependencyProperty.Register(nameof(RefreshCommand), typeof(object), typeof(LimitComponent),
              new PropertyMetadata(null));
        public LimitComponent()
        {
            InitializeComponent();
        }
    }
}
