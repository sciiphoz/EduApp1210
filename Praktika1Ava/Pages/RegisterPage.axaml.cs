using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Praktika1Ava.Data;
using System;
using System.Linq;

namespace Praktika1Ava;

public partial class RegisterPage : UserControl
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private void btnSubmit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!(userName.Text == string.Empty || userLogin.Text == string.Empty))
        {
            if (userPassword.Text == confirmPassword.Text)
            {
                var newUser = new User()
                {
                    Id = App.dbContext.Users.Any() == false ? 1 : Convert.ToInt32(App.dbContext.Users.Max(x => x.Id).ToString()) + 1,
                    Name = userName.Text,
                    Login = userLogin.Text,
                    Password = userPassword.Text
                };

                CurrentUser.currentUser = newUser;

                App.dbContext.Users.Add(newUser);
                App.dbContext.SaveChanges();

                var parent = this.VisualRoot as Window;
                var nav = new NavigationWindow();
                nav.Show();
                parent.Close();
            }
            else
            {
                return;
            }
        }
        else 
        {
            return;
        }
    }
}