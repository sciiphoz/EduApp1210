using Avalonia.Controls;
using Avalonia.Data;
using Praktika1Ava.Data;
using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Praktika1Ava.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContentControl.Content = new UsersPage();
        }
        private void btnItems_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContentControl.Content = new ItemsPage();
        }

        public void EditItem(Item item)
        {
            var editPage = new ItemEditWindow(new Item());
            editPage.ShowDialog(this);
        }
    }
}