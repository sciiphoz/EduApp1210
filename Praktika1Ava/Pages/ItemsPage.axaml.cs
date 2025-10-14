using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Praktika1Ava.Data;
using Praktika1Ava.Views;
using System.Linq;

namespace Praktika1Ava;

public partial class ItemsPage : UserControl
{
    public ItemsPage()
    {
        InitializeComponent();

        MainDataGrid.ItemsSource = App.dbContext.Items.ToList();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedItem = MainDataGrid.SelectedItem as Item;

        if (selectedItem == null) return;

        ContextItems.item = selectedItem;

        var editPage = new ItemEditWindow(new Item());
        var parent = this.VisualRoot as Window;
        await editPage.ShowDialog(parent);

        MainDataGrid.ItemsSource = App.dbContext.Items.ToList();
    }

    private async void btnAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var addPage = new AddItemWindow();
        var parent = this.VisualRoot as Window;
        await addPage.ShowDialog(parent);

        MainDataGrid.ItemsSource = App.dbContext.Items.ToList();
    }

    private void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedItem = MainDataGrid.SelectedItem as Item;

        if (selectedItem == null) return;

        App.dbContext.Items.Remove(selectedItem);
        App.dbContext.SaveChanges();

        MainDataGrid.Columns.Clear();

        MainDataGrid.ItemsSource = App.dbContext.Items.ToList();
    }
}