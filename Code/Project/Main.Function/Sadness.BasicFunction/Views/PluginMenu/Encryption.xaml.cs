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
using System.Windows.Shapes;
using Sadness.BasicFunction.ViewModels.PluginMenu;

namespace Sadness.BasicFunction.Views.PluginMenu
{
    /// <summary>
    /// Encryption.xaml 的交互逻辑
    /// </summary>
    public partial class Encryption : Window
    {
        /// <summary>
        /// Encryption.xaml 的构造函数
        /// </summary>
        public Encryption()
        {
            InitializeComponent();
            this.DataContext = new EncryptionViewModel();
        }
    }
}
