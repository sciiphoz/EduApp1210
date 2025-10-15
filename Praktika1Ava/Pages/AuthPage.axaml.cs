using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Praktika1Ava.Data;
using System.Linq;
using System.Xml.Linq;

namespace Praktika1Ava;

public partial class AuthPage : UserControl
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void btnSubmit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (App.dbContext.Users.FirstOrDefault(x => x.Login == userLogin.Text && x.Password == userPassword.Text) != null)
        {
            CurrentUser.currentUser = App.dbContext.Users.FirstOrDefault(x => x.Login == userLogin.Text && x.Password == userPassword.Text);
        }
        else
        {
            return;
        }
    }
}