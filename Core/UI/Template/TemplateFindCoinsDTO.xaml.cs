﻿using System;
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
    /// Логика взаимодействия для TemplateFindCoinsDTO.xaml
    /// </summary>
    public partial class TemplateFindCoinsDTO : UserControl
    {
        public object CommandToMore
        {
            get { return (object)GetValue(CommandToMoreProperty); }
            set { SetValue(CommandToMoreProperty, value); }
        }
        public static readonly DependencyProperty CommandToMoreProperty =
            DependencyProperty.Register(nameof(CommandToMore), typeof(object), typeof(TemplateFindCoinsDTO),
              new PropertyMetadata(null));
        public TemplateFindCoinsDTO()
        {
            InitializeComponent();
        }
    }
}
