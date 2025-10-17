using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Praktika1Ava.Data;

namespace Praktika1Ava;

public partial class NavigationWindow : Window
{
    public NavigationWindow()
    {
        InitializeComponent();

        userName.Text = CurrentUser.currentUser.Name;
    
        if (CurrentUser.currentUser.Role == 0)
        {
            btnUsers.IsVisible = false;
        } 
    }

    private void btnUsers_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContentControl.Content = new UsersPage();
    }
    private void btnItems_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContentControl.Content = new ItemsPage();
    }
    private void btnBasket_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContentControl.Content = new BasketPage();
    }

    public void EditItem(Item item)
    {
        var editPage = new ItemEditWindow(new Item());
        editPage.ShowDialog(this);
    }
}
