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
    /// Логика взаимодействия для BigButtonComponent.xaml
    /// </summary>
    public partial class BigButtonComponent : UserControl
    {
        public object Command
        {
            get { return (object)GetValue(CommandProperty); }
            set
            { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(object), typeof(BigButtonComponent),
              new PropertyMetadata(null));
        public object Image
        {
            get { return (object)GetValue(ImageProperty); }
            set
            { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(nameof(Image), typeof(object), typeof(BigButtonComponent),
              new PropertyMetadata(null));

        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set
            { SetValue(HeaderProperty, value); }
        }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(object), typeof(BigButtonComponent),
              new PropertyMetadata(null));
        public BigButtonComponent()
        {
            InitializeComponent();
        }
    }
}
