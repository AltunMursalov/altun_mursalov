using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace TextEditor {
    public partial class MainWindow : Window {
        private DispatcherTimer timer;
        public MainWindow() {
            InitializeComponent();
            timer = new DispatcherTimer();
        }

        private void Open_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog {
                Filter = "TXT Files (*.txt)|*.txt"
            };
            if (openFile.ShowDialog() == true) {
                if (contentTextBox.Text != String.Empty) {
                    var result = MessageBox.Show("Do you want to save the current text?", "Info", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes) {
                        SaveFileDialog saveFile = new SaveFileDialog {
                            DefaultExt = ".txt",
                            AddExtension = true,
                            Filter = "TXT Files (*.txt)|*.txt"
                        };
                        if (saveFile.ShowDialog() == true) {
                            using (FileStream stream = new FileStream(saveFile.FileName,
                                FileMode.Create, FileAccess.ReadWrite)) {
                                StreamWriter writer = new StreamWriter(stream);
                                writer.WriteLine(contentTextBox.Text);
                            }
                        }
                    } else if (result == MessageBoxResult.Cancel) {
                        return;
                    }
                }
                contentTextBox.Text = File.ReadAllText(openFile.FileName);
                this.Title = "TextEditor";
                this.Title += $" - {openFile.SafeFileName}";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e) {
            if (contentTextBox.Text != String.Empty) {
                SaveFileDialog saveFile = new SaveFileDialog {
                    DefaultExt = ".txt",
                    AddExtension = true,
                    Filter = "TXT Files (*.txt)|*.txt"
                };
                if (saveFile.ShowDialog() == true) {
                    using (FileStream stream = new FileStream(saveFile.FileName,
                        FileMode.Create, FileAccess.ReadWrite)) {
                        StreamWriter writer = new StreamWriter(stream);
                        writer.WriteLine(contentTextBox.Text);
                    }
                }
            }
        }

        private void Copy_Click(object sender, RoutedEventArgs e) {
            if (contentTextBox.SelectedText != String.Empty)
                Clipboard.SetText(contentTextBox.SelectedText);
        }

        private void Cut_Click(object sender, RoutedEventArgs e) {
            if (contentTextBox.SelectedText != String.Empty) {
                Clipboard.SetText(contentTextBox.SelectedText);
                contentTextBox.Text = contentTextBox.Text.Replace(contentTextBox.SelectedText, String.Empty);
            }
        }

        private void Paste_Click(object sender, RoutedEventArgs e) {
            contentTextBox.Text += Clipboard.GetText();
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e) {
            if (contentTextBox.SelectedText != String.Empty)
                contentTextBox.SelectAll();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e) {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (FileStream stream = new FileStream($"{path}\\{this.Title.Replace("TextEditor - ", String.Empty)}.txt",
                        FileMode.Create, FileAccess.ReadWrite)) {
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(contentTextBox.Text);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) {
            timer.Stop();
        }
    }
}