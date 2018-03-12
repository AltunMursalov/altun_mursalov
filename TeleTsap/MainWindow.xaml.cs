using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace TeleTsap {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window {
        public ObservableCollection<ListBoxItem> collection;
        [XmlIgnore]
        private bool chek;

        public MainWindow() {
            InitializeComponent();
            collection = new ObservableCollection<ListBoxItem>();
            chek = false;
            this.allMessages.ItemsSource = collection;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e) {
            if (this.messageBox.Text != String.Empty) {
                if (chek == false) {
                    this.collection.Add(new ListBoxItem {
                        Content = new Border {
                            Background = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                            BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                            BorderThickness = new Thickness(5),
                            CornerRadius = new CornerRadius(15, 15, 15, 15),
                            Child = new TextBlock {
                                Text = this.messageBox.Text,
                                FontSize = 15,
                                TextWrapping = TextWrapping.Wrap
                            }
                        }
                    });
                    chek = true;
                } else {
                    this.collection.Add(new ListBoxItem {
                        Content = new Border {
                            Background = new SolidColorBrush(Color.FromRgb(220, 248, 198)),
                            BorderBrush = new SolidColorBrush(Color.FromRgb(220, 248, 198)),
                            BorderThickness = new Thickness(5),
                            CornerRadius = new CornerRadius(15, 15, 15, 15),
                            Child = new TextBlock {
                                Text = this.messageBox.Text,
                                FontSize = 15,
                                TextWrapping = TextWrapping.Wrap
                            }
                        },
                        HorizontalAlignment = HorizontalAlignment.Right
                    });
                    chek = false;
                }
                this.allMessages.ScrollIntoView(this.allMessages.Items.Cast<ListBoxItem>().Last());
                this.messageBox.Clear();
                this.messageBox.Focus();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            this.messageBox.Focus();
        }

        private void Load() {

        }

        private void Save() {
            using (FileStream file = new FileStream("MessengerBase.xml", FileMode.Create, FileAccess.ReadWrite)) {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ListBoxItem>));
                serializer.Serialize(file, collection);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Save();
        }
    }
}
