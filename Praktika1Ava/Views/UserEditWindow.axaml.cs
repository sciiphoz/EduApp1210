using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using Praktika1Ava.Data;
using Praktika1Ava.Views;
using System.Threading.Tasks;

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

    private async void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Предупреждение", "Вы точно хотите сохранить?", MsBox.Avalonia.Enums.ButtonEnum.YesNo);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            currentUser.Name = tbName.Text;
            currentUser.Login = tbLogin.Text;

            App.dbContext.Users.Update(currentUser);
            App.dbContext.SaveChanges();

            Close();
        }
        else
        {
            Close();
        }
    }
}