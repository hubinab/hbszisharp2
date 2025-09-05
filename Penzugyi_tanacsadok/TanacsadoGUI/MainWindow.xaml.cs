using Data;
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

namespace TanacsadoGUI
{
    public partial class MainWindow : Window
    {
        private readonly Tarolo repo = new Tarolo();
        public MainWindow()
        {
            InitializeComponent();
            repo.SzakteruletekFeltoltese();
            repo.TanacsadokFeltoltese();
            SzakteruletComboBox.ItemsSource = repo.Szakteruletek;
            SzakteruletComboBox.DisplayMemberPath = "Megnevezes";
        }
        private void SzakteruletComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kivalasztott = SzakteruletComboBox.SelectedItem as Szakterulet;
            if (kivalasztott != null)
            {
                var szurtTanacsadok = repo.SzurtTanacsadok(kivalasztott.SzakteruletId);

                TanacsadoComboBox.ItemsSource = szurtTanacsadok;
                TanacsadoComboBox.DisplayMemberPath = "Nev";

                TelefonTextBox.Text = "";
                EmailTextBox.Text = "";
                OradijTextBox.Text = "";
            }
        }

        private void TanacsadoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kivalasztott = TanacsadoComboBox.SelectedItem as Tanacsado;
            if (kivalasztott != null)
            {
                TelefonTextBox.Text = kivalasztott.Telefon;
                EmailTextBox.Text = kivalasztott.Email;
                OradijTextBox.Text = kivalasztott.Oradij.ToString();
            }
        }

    }
}