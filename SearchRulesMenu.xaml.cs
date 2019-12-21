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
    /// Interaction logic for SearchRulesMenu.xaml
    /// </summary>
    public partial class SearchRulesMenu : Page
    {

        #region variable initialiser
        private static string connectionString = "SERVER=localhost;" +
                                                 "DATABASE=revisiontooldbschema;" +
                                                 "UID=c_lykoudis;" +
                                                 "PASSWORD=Stratigosathan210;"; //define connection string with required attributes
        private static MySqlConnection connection = new MySqlConnection(connectionString); //create connection to the database

        #endregion
        public SearchRulesMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// methods to navigate from this menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region navigation methods
        private void SearchRulesMenu_ReturnMainButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void SearchRulesMenu_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchDatabaseMenu_HelpPage());
        }

        private void SearchRulesMenu_SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if(SearchRulesMenu_TypeSelection.Text == "")
            {
                MessageBox.Show("This field is required. Please try again");
            }
            else
            {
                NavigationService.Navigate(new SearchRulesMenu_DataGrid(SearchRulesMenu_TypeSelection.Text, connection));
            }
        }
        #endregion
        /// <summary>
        /// method to retreive necessary rules for the rule type entered by the user
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        public static DataTable FetchBinaryRulesTable(MySqlConnection sqlConnection)
        {
            sqlConnection.Open(); //open the connection
            MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM binaryrules", sqlConnection); //define the command to be ran
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable(); //creates data table for the data from the database to be loaded onto
            dataTable.Load(sqlCommand.ExecuteReader()); //load the data fetched by the command onto the data table
            dataAdapter.Fill(dataTable);
            sqlConnection.Close(); //close the connection
            return dataTable;//return the table with the required data
        }
        public static DataTable FetchBooleanRulesTable(MySqlConnection sqlConnection)
        {
            sqlConnection.Open(); //open the connection
            MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM booleanrules",    
                                                       sqlConnection); //define the command to be ran
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable(); //creates data table for the data from the database to be loaded onto
            dataTable.Load(sqlCommand.ExecuteReader()); //load the data fetched by the command onto the data table
            dataAdapter.Fill(dataTable);
            sqlConnection.Close(); //close the connection
            return dataTable;//return the table with the required data
        }
    }
}
