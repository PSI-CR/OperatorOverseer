using AuditLibrary.OperatorInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OperatorOverseer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CreateOperatorWindow _createOperatorWindow;
        private OperatorInfoData _operatorData;
        private ObservableCollection<OperatorInfoView> _operators;
        public MainWindow(OperatorInfoData operatorData)
        {
            InitializeComponent();
            _operatorData = operatorData;
            _createOperatorWindow = new CreateOperatorWindow(operatorData);
            setOperatorInfoView();
            setPermissionsView();
        }
        private void setPermissionsView()
        {
            _permissionsStackPanel.Children.Clear();
            foreach (string permission in _operatorData.GetPermissions())
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = permission;
                textBlock.Padding = new Thickness(5);
                textBlock.Margin = new Thickness(5);
                textBlock.Background = new SolidColorBrush(Color.FromRgb(210, 210, 210));
                textBlock.Width = 200;
                _permissionsStackPanel.Children.Add(textBlock);
            }
        }
        private void setOperatorInfoView()
        {
            _operators = new ObservableCollection<OperatorInfoView>(_operatorData.GetAllOperators().Select(x => new OperatorInfoView(x)).ToList());
            dataGrid.ItemsSource = _operators;
        }        
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button editButton && editButton.Tag is int operatorNumber)
            {
                // Find the operator to edit based on the operator number
                var operatorToEdit = _operatorData.Read(operatorNumber);
                if (operatorToEdit != null)
                {
                    EditOperatorWindow editOperatorWindow = new EditOperatorWindow(operatorToEdit);
                    editOperatorWindow.ShowDialog();
                    _operatorData.Update(editOperatorWindow.GetEditedOperator());
                    setOperatorInfoView();
                }
            }
        }

        // Event handler for "Remove" button
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button removeButton && removeButton.Tag is int operatorNumber)
            {
                // Find the operator to remove based on the operator number
                var operatorToRemove = _operators.FirstOrDefault(op => op.Number == operatorNumber);
                if (operatorToRemove != null)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure that you want to remove " + operatorToRemove.Name + " ?", "Atention!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        _operators.Remove(operatorToRemove);
                        _operatorData.Delete(operatorNumber);
                    }
                }
            }
        }
        private void OpenCreateOperatorWindow(object sender, RoutedEventArgs e)
        {
            _createOperatorWindow.ShowDialog();
            setOperatorInfoView();
        }

        private void AddPermission(object sender, RoutedEventArgs e)
        {
            string permission = _addPermissionTextbox.Text;
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure that you want to add the " + permission + " permission?", "Atention!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                _operatorData.AddPermission(permission, false);
                setPermissionsView();
            }
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
            return;
        }
    }
}
