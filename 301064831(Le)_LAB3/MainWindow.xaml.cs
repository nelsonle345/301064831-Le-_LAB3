using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using _301064831_Le__LAB3.ViewModel;

namespace _301064831_Le__LAB3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model ViewModel { get; set; } = new Model();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel; 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
            var comboBox = sender as ComboBox;
            var selectedItem = comboBox.SelectedItem;

            if (selectedItem != null)
            {
                
                ViewModel.HandleComboBoxSelection(selectedItem);
            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            var selectedItems = dataGrid.SelectedItems;

            foreach (var selectedItem in selectedItems)
            {
                if (selectedItem is OrderedItem orderedItem)
                {

                    ViewModel.RecalculateBill();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearBill();
        }
    }
}
