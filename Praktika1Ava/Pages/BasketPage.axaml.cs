using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using Praktika1Ava.Data;
using System.Linq;

namespace Praktika1Ava;

public partial class BasketPage : UserControl
{
    public BasketPage()
    {
        InitializeComponent();

        RefreshData();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedUserItem = MainDataGrid.SelectedItem as UserItem;

        if (selectedUserItem == null) return;

        ContextUserItem.useritem = selectedUserItem;

        var editPage = new UserItemEditWindow(new UserItem());
        var parent = this.VisualRoot as Window;
        await editPage.ShowDialog(parent);

        RefreshData();
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Предупреждение", "Вы точно хотите удалить?", MsBox.Avalonia.Enums.ButtonEnum.YesNo);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            var selectedUserItem = MainDataGrid.SelectedItem as UserItem;

            if (selectedUserItem == null) return;

            App.dbContext.UserItems.Remove(selectedUserItem);
            App.dbContext.SaveChanges();

            RefreshData();
        }
        else
        {
            return;
        }
    }

    private void RefreshData()
    {
        MainDataGrid.ItemsSource = App.dbContext.UserItems.Include("Item").Include("User").Where(x => x.UserId == CurrentUser.currentUser.Id).ToList();
        FullPrice.Text = App.dbContext.UserItems.Include("Item").Where(x => x.UserId == CurrentUser.currentUser.Id).Sum(x => x.Item.Price * x.Quantity).ToString();
    }
}