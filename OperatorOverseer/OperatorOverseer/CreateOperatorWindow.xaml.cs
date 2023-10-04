using AuditLibrary.OperatorInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OperatorOverseer
{
    /// <summary>
    /// Interaction logic for CreateOperatorWindow.xaml
    /// </summary>
    public partial class CreateOperatorWindow : Window
    {
        private OperatorInfoData _operatorData;
        private List<CheckBox> _checkBoxes;
        public CreateOperatorWindow(OperatorInfoData operatorData)
        {
            InitializeComponent();
            _operatorData = operatorData;
            initializePermissions();
        }
        private void initializePermissions()
        {
            List<string> permissions = _operatorData.GetPermissions();
            _checkBoxes = new List<CheckBox>();
            foreach (string permission in permissions)
            {
                CheckBox box = new CheckBox();
                box.Content = permission;
                _permissionsCheckBoxes.Children.Add(box);
                _checkBoxes.Add(box);
            }
        }
        // Event handler for "Create" button
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, bool> permissions = new Dictionary<string, bool>();
            foreach(CheckBox box in _checkBoxes)
            {
                permissions.Add((string)box.Content, (bool)box.IsChecked);
            }
            // Create a new OperatorInfo object with data from TextBoxes
            var newOperator = new OperatorInfo
            {
                Number = int.Parse(numberTextBox.Text),
                Name = nameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Device = deviceTextBox.Text,
                Permissions = permissions
            };

            // Add the new operator to the ObservableCollection and save to JSON
            _operatorData.Create(newOperator);

            // Clear TextBoxes
            ClearTextBoxes();
        }
        // Helper method to clear TextBoxes
        private void ClearTextBoxes()
        {
            numberTextBox.Clear();
            nameTextBox.Clear();
            lastNameTextBox.Clear();
            deviceTextBox.Clear();
        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        private void PositiveIntegerTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[1-9]\d*$");
            string proposedText = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, e.Text);

            if (!regex.IsMatch(proposedText))
            {
                e.Handled = true;
            }
        }
    }
}
