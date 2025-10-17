using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using MsBox.Avalonia;
using Praktika1Ava.Data;
using Praktika1Ava.Views;
using System;
using System.Linq;

namespace Praktika1Ava;

public partial class ItemsPage : UserControl
{
    public ItemsPage()
    {
        InitializeComponent();

        MainDataGrid.ItemsSource = App.dbContext.Items.ToList();

        if (CurrentUser.currentUser.Role == 0)
        {
            btnAdd.IsVisible = false;
            btnDelete.IsVisible = false;
        }
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (CurrentUser.currentUser.Role == 0)
        {
            return;
        }
        else
        {
            var selectedItem = MainDataGrid.SelectedItem as Item;

            if (selectedItem == null) return;

            ContextItems.item = selectedItem;

            var editPage = new ItemEditWindow(new Item());
            var parent = this.VisualRoot as Window;
            await editPage.ShowDialog(parent);

            MainDataGrid.ItemsSource = App.dbContext.Items.ToList();
        }
    }

    private async void btnAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var addPage = new AddItemWindow();
        var parent = this.VisualRoot as Window;
        await addPage.ShowDialog(parent);

        MainDataGrid.ItemsSource = App.dbContext.Items.ToList();
    }

    private async void btnAddToBasket_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedItem = MainDataGrid.SelectedItem as Item;

        if (selectedItem == null) return;

        if (App.dbContext.UserItems.FirstOrDefault(x => x.ItemId == selectedItem.Id && x.UserId == CurrentUser.currentUser.Id) == null)
        {
            App.dbContext.UserItems.Add(new UserItem
            {
                Id = App.dbContext.UserItems.Any() == false ? 1 : Convert.ToInt32(App.dbContext.UserItems.Max(x => x.Id).ToString()) + 1,
                ItemId = selectedItem.Id,
                UserId = CurrentUser.currentUser.Id,
                Quantity = 1
            });

            App.dbContext.SaveChanges();
        }
        else
        {
            var updateBasket = App.dbContext.UserItems.FirstOrDefault(x => x.ItemId == selectedItem.Id && x.UserId == CurrentUser.currentUser.Id);

            updateBasket.Quantity += 1;

            App.dbContext.SaveChanges();
        }
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Предупреждение", "Вы точно хотите удалить?", MsBox.Avalonia.Enums.ButtonEnum.YesNo);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            var selectedItem = MainDataGrid.SelectedItem as Item;

            if (selectedItem == null) return;

            App.dbContext.Items.Remove(selectedItem);
            App.dbContext.SaveChanges();

            MainDataGrid.Columns.Clear();

            MainDataGrid.ItemsSource = App.dbContext.Items.ToList();
        }
        else
        {
            return;
        }
    }
}