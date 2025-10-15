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
