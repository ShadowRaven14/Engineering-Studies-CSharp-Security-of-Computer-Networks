using PS4.Ex;
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

namespace PS4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            LFSR lfsr = new(seedLFSR.Text, tapsLFSR.Text);
            List<int> temp = lfsr.Generate();
            string temptext = "";
            foreach(int i in temp)
            {
                temptext = temptext + i.ToString();
            }
            generated.Text = temptext;
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {

            Cipher cipher = new(bitString.Text, streamTaps.Text);
            cipherResult.Text = cipher.Encrypt();
            string temptext = "";
            foreach (int i in cipher.seed)
            {
                temptext = temptext + i.ToString();
            }
            streamSeed.Text = temptext;
            
        }
    }
}
