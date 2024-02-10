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

namespace NewCryptoApp.Core.UI.Template
{
    /// <summary>
    /// Логика взаимодействия для TemplateTradeVariation.xaml
    /// </summary>
    public partial class TemplateTradeVariation : UserControl
    {
        public object MarketName
        {
            get { return (object)GetValue(MarketNameProperty); }
            set { SetValue(MarketNameProperty, value); }
        }
        public static readonly DependencyProperty MarketNameProperty =
            DependencyProperty.Register(nameof(MarketName), typeof(object), typeof(TemplateTradeVariation),
              new PropertyMetadata(null));
        public TemplateTradeVariation()
        {
            InitializeComponent();
        }
    }
}
