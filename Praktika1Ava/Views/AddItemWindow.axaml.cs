using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Praktika1Ava.Data;
using Praktika1Ava.Views;
using System;
using System.Linq;

namespace Praktika1Ava;

public partial class AddItemWindow : Window
{
    public AddItemWindow()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var id = Convert.ToInt32(App.dbContext.Items.Max(x => x.Id).ToString()) + 1;
        var name = tbName.Text;
        var desc = tbDesc.Text;

        var newItem = new Item()
        {
            Id = id,
            Name = name,
            Desc = desc,
        };

        App.dbContext.Items.Add(newItem);
        App.dbContext.SaveChanges();

        Close();
    }
}