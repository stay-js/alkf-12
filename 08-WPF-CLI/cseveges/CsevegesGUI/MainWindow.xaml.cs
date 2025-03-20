using System.Windows;
using System.Windows.Controls;
using System.IO;
using CsevegesLib;

namespace CsevegesGUI
{
    public partial class MainWindow : Window
    {
        private readonly Chats _chats;

        public MainWindow()
        {
            _chats = new(File.ReadAllLines("../../../../csevegesek.txt"));
            InitializeComponent();
            FillComboBoxes();
        }

        public void FillComboBoxes()
        {
            SenderComboBox.ItemsSource = _chats.Senders;
            SenderComboBox.SelectedIndex = 0;

           RecieverComboBox.ItemsSource = _chats.Recievers;
           RecieverComboBox.SelectedIndex = _chats.Recievers.Count() - 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChatsListView.Items.Clear();
            string sndr = SenderComboBox.SelectedValue?.ToString() ?? string.Empty;
            string rcvr = RecieverComboBox.SelectedValue?.ToString() ?? string.Empty;

            var chats = _chats.GetBySenderAndReciever(sndr, rcvr).ToArray();
            
            if (chats.Length == 0)
            {
                ChatsListView.Items.Add("Nem történt beszélgetés");
                return;
            }

            for (int i = 0; i < chats.Length; i++)
            {
                ChatsListView.Items.Add($"{i + 1}. {chats[i]}");
            }
        }
    }
}
