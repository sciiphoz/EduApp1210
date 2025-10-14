using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Praktika1Ava.Data;
using Praktika1Ava.Views;
using System.Linq;

namespace Praktika1Ava;

public partial class UsersPage : UserControl
{
    public UsersPage()
    {
        InitializeComponent();

        MainDataGrid.ItemsSource = App.dbContext.Users.ToList();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedUser = MainDataGrid.SelectedItem as User;

        if (selectedUser == null) return;

        ContextUsers.user = selectedUser;

        var editPage = new UserEditWindow(new User());
        var parent = this.VisualRoot as Window;
        await editPage.ShowDialog(parent);

        MainDataGrid.ItemsSource = App.dbContext.Users.ToList();
    }

    private async void btnAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var addPage = new AddUserWindow();
        var parent = this.VisualRoot as Window;
        await addPage.ShowDialog(parent);

        MainDataGrid.ItemsSource = App.dbContext.Users.ToList();
    }

    private void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedUser = MainDataGrid.SelectedItem as User;

        if (selectedUser == null) return;

        App.dbContext.Users.Remove(selectedUser);
        App.dbContext.SaveChanges();

        MainDataGrid.Columns.Clear();

        MainDataGrid.ItemsSource = App.dbContext.Users.ToList();
    }
}