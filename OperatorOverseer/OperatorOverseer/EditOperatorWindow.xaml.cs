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
    /// Interaction logic for EditOperatorWindow.xaml
    /// </summary>
    public partial class EditOperatorWindow : Window
    {
        private OperatorInfo _operatorToEdit;
        private List<CheckBox> _checkBoxes;

        public EditOperatorWindow(OperatorInfo operatorToEdit)
        {
            InitializeComponent();

            _operatorToEdit = operatorToEdit;

            // Populate the TextBoxes and CheckBoxes with operator data
            numberTextBox.Text = _operatorToEdit.Number.ToString();
            nameTextBox.Text = _operatorToEdit.Name;
            lastNameTextBox.Text = _operatorToEdit.LastName;
            deviceTextBox.Text = _operatorToEdit.Device;
            initializePermissions(operatorToEdit);
        }

        internal OperatorInfo GetEditedOperator()
        {
            return _operatorToEdit;
        }

        private void initializePermissions(OperatorInfo operatorToEdit)
        {
            _checkBoxes = new List<CheckBox>();
            foreach (var permission in operatorToEdit.Permissions)
            {
                CheckBox box = new CheckBox();
                box.Content = permission.Key;
                box.IsChecked = permission.Value;
                _permissionsCheckBoxes.Children.Add(box);
                _checkBoxes.Add(box);
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, bool> permissions = new Dictionary<string, bool>();
            foreach (CheckBox box in _checkBoxes)
            {
                permissions.Add((string)box.Content, (bool)box.IsChecked);
            }
            // Update the OperatorInfo object with user input
            _operatorToEdit.Number = int.Parse(numberTextBox.Text);
            _operatorToEdit.Name = nameTextBox.Text;
            _operatorToEdit.LastName = lastNameTextBox.Text;
            _operatorToEdit.Device = deviceTextBox.Text;
            _operatorToEdit.Permissions = permissions;

            // Close the window
            Close();
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
