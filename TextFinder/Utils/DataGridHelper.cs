//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using TextFinder.Models;

//namespace TextFinder.Utils
//{
//    public class DataGridHelper
//    {
//        private static HashSet<string> _currencyColumns = new HashSet<string>();
//        public static readonly DependencyProperty UseAttributesProperty =
//            DependencyProperty.RegisterAttached("UseAttributes", typeof(bool), typeof(DataGridHelper), new PropertyMetadata(false, OnUseAttributesChanged));

//        public static bool GetUseAttributes(DependencyObject obj)
//        {
//            return (bool)obj.GetValue(UseAttributesProperty);
//        }

//        public static void SetUseAttributes(DependencyObject obj, bool value)
//        {
//            obj.SetValue(UseAttributesProperty, value);
//        }

//        private static void OnUseAttributesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            var dataGrid = d as DataGrid;

//            if (dataGrid is null)
//            {
//                dataGrid.Loaded -= DataGrid_Loaded;
//                dataGrid.AutoGeneratingColumn -= DataGrid_AutoGeneratingColumn;
//            }
//            else
//            {
//                dataGrid.Loaded += DataGrid_Loaded;
//                dataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
//            }
//        }

//        private static void DataGrid_Loaded(object sender, RoutedEventArgs e)
//        {
//            if (sender is DataGrid dataGrid)
//            {
//                ObservableCollection<DataGridColumn> columns = dataGrid.Columns;
//                PropertyInfo[] properties = typeof(AccountBook).GetProperties();
//                int count = properties.Length;

//                for (int i = 0; i < count; i++)
//                {
//                    string name = properties[i].Name;
//                    var headerAttr = typeof(AccountBook).GetProperty(name).GetCustomAttributes<HeaderAttribute>().FirstOrDefault();
//                    var currencyAttr = typeof(AccountBook).GetProperty(name).GetCustomAttributes<CurrencyAttribute>().FirstOrDefault();

//                    if (headerAttr != null)
//                    {
//                        columns[i].Header = headerAttr.Header;
//                    }

//                    if (currencyAttr != null)
//                    {
//                        _currencyColumns.Add(name);
//                    }
//                }
//            }
//        }

//        private static void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
//        {
//            if (e.Column.Header is string header
//                && _currencyColumns.Contains(header)
//                && e.Column is DataGridTextColumn textColumn)
//            {
//                textColumn.Binding = new Binding(header)
//                {
//                    StringFormat = "N2"
//                };
//            }
//        }
//    }
//}