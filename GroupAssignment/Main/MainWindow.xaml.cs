﻿using System.Windows;
using GroupAssignment.Items;
using GroupAssignment.Search;

namespace GroupAssignment.Main {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// opens search window
        /// </summary>
        /// <param name="sender">UI object</param>
        /// <param name="e">event</param>
        private void OpenSearchWindow(object sender, RoutedEventArgs e) {
            var sw = new SearchWindow();
            Close();
            sw.ShowDialog();
        }

        private void BtnToItems_Click(object sender, RoutedEventArgs e)
        {
            var iw = new ItemsWindow();
            Close();
            iw.ShowDialog();
        }
    }
}