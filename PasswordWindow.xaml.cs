using System.Windows;

namespace ids;

public partial class PasswordWindow : Window
{
    public PasswordWindow()
    {
        InitializeComponent();
    }

    private void BtnOk_Click(object sender, RoutedEventArgs e)
    {
        if (PasswordBox.Password == "ids72")
        {
            DialogResult = true;
        }
        else
        {
            MessageBox.Show(
                "Invalid Password",
                "Access Denied",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}