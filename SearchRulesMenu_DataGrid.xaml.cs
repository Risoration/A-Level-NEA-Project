using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace NEA___Boolean_and_Binary_Algebra_Revision_Tool
{
    /// <summary>
    /// Interaction logic for DataGridMenu.xaml
    /// </summary>
    public partial class SearchRulesMenu_DataGrid : Page
    {
        public SearchRulesMenu_DataGrid(string ruleType, MySqlConnection sqlConnection)
        {
            InitializeComponent();

            if (ruleType == "Binary")
            {
                dataGrid.DataContext = SearchRulesMenu.FetchBinaryRulesTable(sqlConnection);
            }
            else if (ruleType == "Boolean")
            {
                dataGrid.DataContext = SearchRulesMenu.FetchBooleanRulesTable(sqlConnection);
            }
        }

        private void SearchRulesMenu_DataGrid_SearchRulesMenu_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchRulesMenu());
        }

        private void SearchRulesMenu_DataGrid_ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }
    }
}
