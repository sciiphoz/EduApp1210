using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Praktika1Ava.Data;
using Praktika1Ava.Views;

namespace Praktika1Ava;

public partial class UserEditWindow : Window
{
    private User user;

    private User currentUser;
    public UserEditWindow()
    {
        InitializeComponent();

        user = ContextUsers.user;
    }

    public UserEditWindow(User user)
    {
        InitializeComponent();
        
        user = ContextUsers.user;
        currentUser = user;

        tbName.Text = user.Name;
        tbLogin.Text = user.Login;
    }

    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        currentUser.Name = tbName.Text;
        currentUser.Login = tbLogin.Text;

        App.dbContext.Users.Update(currentUser);
        App.dbContext.SaveChanges();

        Close();
    }
}