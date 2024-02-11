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
    /// Логика взаимодействия для ListBoxComponent.xaml
    /// </summary>
    public partial class ListBoxComponent : UserControl
    {
        public object ItemsSoure
        {
            get { return (object)GetValue(ItemsSoureProperty); }
            set
            { SetValue(ItemsSoureProperty, value); }
        }
        public static readonly DependencyProperty ItemsSoureProperty =
            DependencyProperty.Register(nameof(ItemsSoure), typeof(object), typeof(ListBoxComponent),
              new PropertyMetadata(null));

        public object SelectedItems
        {
            get { return (object)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register(nameof(SelectedItems), typeof(object), typeof(ListBoxComponent),
              new PropertyMetadata(null));
        public DataTemplate AdditionalContent
        {
            get { return (DataTemplate)GetValue(AdditionalContentProperty); }
            set { SetValue(AdditionalContentProperty, value); }
        }
        public static readonly DependencyProperty AdditionalContentProperty =
            DependencyProperty.Register(nameof(AdditionalContent), typeof(DataTemplate), typeof(ListBoxComponent),
              new PropertyMetadata(null));
        public ListBoxComponent()
        {
            InitializeComponent();
        }
    }
}
