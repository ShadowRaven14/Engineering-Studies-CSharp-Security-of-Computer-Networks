using PS3.Algorytmy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PS3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (RailFence.IsChecked == true)
            {
                RailFence railfence = new RailFence(Text.Text.ToString(), Int32.Parse(n.Text.ToString()));
                Outcome.Text = railfence.Encrypt();
            }
            else if (PrzestawienieMacierzowe2a.IsChecked == true)
            {
                Macierzowe2a _2a = new Macierzowe2a(Text.Text.ToString(), klucz2a.Text.ToString());
                Outcome.Text = _2a.Encrypt();
            }
            else if (PrzestawienieMacierzowe2b.IsChecked == true)
            {
                Macierzowe2b _2b = new Macierzowe2b(Text.Text.ToString(), klucz2b.Text.ToString());
                Outcome.Text = _2b.Encrypt();
            }
            Outcome.IsEnabled = true;
        }

        private void RailFence_Checked(object sender, RoutedEventArgs e)
        {
            TextboxEnabled(n);
        }
        private void PrzestawienieMacierzowe2a_Checked(object sender, RoutedEventArgs e)
        {
            TextboxEnabled(klucz2a);
        }

        private void PrzestawienieMacierzowe2b_Checked(object sender, RoutedEventArgs e)
        {
            TextboxEnabled(klucz2b);
        }

        private void TextboxEnabled(TextBox textBox)
        {
            foreach (TextBox txtBx in FindVisualChildren<TextBox>(this))
            {
                txtBx.IsEnabled = false;
            }
            textBox.IsEnabled = true;
            Text.IsEnabled = true;
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T t)
                    {
                        yield return t;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (RailFence.IsChecked == true)
            {
                RailFence rf = new RailFence(Text.Text.ToString(), Int32.Parse(n.Text.ToString()));
                Outcome.Text = rf.Decrypt();
            }
            else if (PrzestawienieMacierzowe2a.IsChecked == true)
            {
                Macierzowe2a _2a = new Macierzowe2a(Text.Text.ToString(), klucz2a.Text.ToString());
                Outcome.Text = _2a.Decrypt();
            }
            else if (PrzestawienieMacierzowe2b.IsChecked == true)
            {
                Macierzowe2b _2b = new Macierzowe2b(Text.Text.ToString(), klucz2b.Text.ToString());
                Outcome.Text = _2b.Decrypt();
            }
            Outcome.IsEnabled = true;
        }
    }
}
