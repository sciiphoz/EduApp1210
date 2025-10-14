using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Praktika1Ava.Data;
using Praktika1Ava.Views;

namespace Praktika1Ava;

public partial class ItemEditWindow : Window
{
    private Item item;

    private Item currentItem;
    public ItemEditWindow()
    {
        InitializeComponent();
    
        item = ContextItems.item;
    }

    public ItemEditWindow(Item item)
    {
        InitializeComponent();

        item = ContextItems.item;
        currentItem = item;

        tbName.Text = item.Name;
        tbDesc.Text = item.Desc;
    }

    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        currentItem.Name = tbName.Text;
        currentItem.Desc = tbDesc.Text;

        App.dbContext.Items.Update(currentItem);
        App.dbContext.SaveChanges();

        Close();
    }
}