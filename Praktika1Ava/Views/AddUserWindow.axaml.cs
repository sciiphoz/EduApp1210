using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Praktika1Ava.Data;
using Praktika1Ava.Views;
using System;
using System.Linq;

namespace Praktika1Ava;

public partial class AddUserWindow : Window
{
    public AddUserWindow()
    {
        InitializeComponent();
    }
    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var id = Convert.ToInt32(App.dbContext.Users.Max(x => x.Id).ToString()) + 1;
        var name = tbName.Text;
        var login = tbLogin.Text;

        var newUser = new User()
        {
            Id = id,
            Name = name,
            Login = login,
        };

        App.dbContext.Users.Add(newUser);
        App.dbContext.SaveChanges();

        Close();
    }
}