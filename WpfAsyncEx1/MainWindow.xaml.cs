﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfAsyncEx1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void Invoked_Button_Click(object sender, RoutedEventArgs e)
        {
            await PrintGoodAsync();
            textBlock.Text += "\n" + "Invoked_Button_Click finished";
        }

        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text += "\n" + "Was Printed";
        }



        async Task PrintGoodAsync()
        {

            var result = await Task.Run(() => PrintGood());

            textBlock.Text += "\n" + result;
        }




        async Task<string> PrintGood()
        {
            await Task.Delay(5000);
            //Thread.Sleep(5000);
            return "Invoked!!";
        }

    }
}