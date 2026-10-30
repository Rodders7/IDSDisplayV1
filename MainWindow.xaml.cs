using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Windows.Threading;
using TextBox = System.Windows.Controls.TextBox;


namespace ids;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private DispatcherTimer _holdTimer;
    private bool _mouseHeld;
    public MainWindow()
    {
        InitializeComponent();
        _holdTimer = new DispatcherTimer();
        _holdTimer.Interval = TimeSpan.FromSeconds(5);
        _holdTimer.Tick += HoldTimer_Tick;
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        _mouseHeld = true;
        _holdTimer.Start();
    }

    private void Window_MouseUp(object sender, MouseButtonEventArgs e)
    {
        _mouseHeld = false;
        _holdTimer.Stop();
    }

    private void HoldTimer_Tick(object? sender, EventArgs e)
    {
        _holdTimer.Stop();

        if (_mouseHeld)
        {
            ShowAdminMenu();
        }
    }

    private void ShowAdminMenu()
    {
        var result = MessageBox.Show(
            "Yes = Settings\nNo = Exit Application",
            "Admin Menu",
            MessageBoxButton.YesNoCancel);

        if (result == MessageBoxResult.Yes)
        {
            ShowPasswordDialog();
        }
        else if (result == MessageBoxResult.No)
        {
            Application.Current.Shutdown();
        }
    }

    private void ShowPasswordDialog()
{
    var passwordWindow = new PasswordWindow();

    if (passwordWindow.ShowDialog() == true)
    {
        MessageBox.Show("Settings would open here.");
    }
}
}