using System.Windows;
using System.Windows.Controls;

namespace HW3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm;
        public MainWindow()
        {
            InitializeComponent();
            mvm = (MainViewModel)this.DataContext;
            foreach (var uiElement in this.rootLayout.Children)
            {
                if (uiElement is Button)
                {
                    ((Button)uiElement).Click += this.Button_Click;
                }
            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandler buttonHandler = new ButtonHandler(mvm.Operation);
            if (((Button)sender).Name.ToString() != "")
                buttonHandler?.Invoke(((Button)sender).Name.ToString()); 
            else
             buttonHandler.Invoke(((Button)sender).Content.ToString());
        }
    }
}
