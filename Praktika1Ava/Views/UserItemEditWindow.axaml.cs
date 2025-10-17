using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using Praktika1Ava.Data;
using System;
using System.Xml.Linq;

namespace Praktika1Ava;

public partial class UserItemEditWindow : Window
{
    private UserItem useritem;

    private UserItem currentUserItem;
    public UserItemEditWindow()
    {
        InitializeComponent();

        useritem = ContextUserItem.useritem;
    }

    public UserItemEditWindow(UserItem useritem)
    {
        InitializeComponent();

        useritem = ContextUserItem.useritem;
        currentUserItem = useritem;

        tbQuantity.Text = useritem.Quantity.ToString();
    }

    private async void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Convert.ToInt32(tbQuantity.Text) <= 0 || Convert.ToInt32(tbQuantity.Text) >= 5000)
        {
            return;
        }
        else
        {
            currentUserItem.Quantity = Convert.ToInt32(tbQuantity.Text);

            App.dbContext.UserItems.Update(currentUserItem);
            App.dbContext.SaveChanges();

            Close();
        }

    }
}