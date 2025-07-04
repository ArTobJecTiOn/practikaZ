﻿using practikaZ.models;
using practikaZ.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace practikaZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigate(new Page1());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrmMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Теперь только вперед");
            }
        }
        private void FrmMain_ContentRendered(object sender, EventArgs e)
        {

        }
        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
