using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace NEA___Boolean_and_Binary_Algebra_Revision_Tool
{
    /// <summary>
    /// Interaction logic for SearchPastQuestionsMenu.xaml
    /// </summary>
    public partial class SearchPastQuestionsMenu : Page
    {
        #region variable initialiser
        private static string connectionString = "SERVER=localhost;" +
                                                 "DATABASE=revisiontooldbschema;" +
                                                 "UID=c_lykoudis;" +
                                                 "PASSWORD=Stratigosathan210;"; //define connection string with required attributes
        public static MySqlConnection connection = new MySqlConnection(connectionString); //create connection to the database
        #endregion
        public SearchPastQuestionsMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// methods to navigate from this menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchPastQuestionsMenu_ReturnMainButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void SearchPastQuestionsMenu_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchDatabaseMenu_HelpPage());
        }
        private void SearchPastQuestionsMenu_SearchButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchPastQuestionsMenu_DataGrid(SearchPastQuestionsMenu_TypeSelection.Text, SearchPastQuestionsMenu_DifficultySelection.SelectedIndex, SearchPastQuestionsMenu_OutcomeSelection.Text, SearchPastQuestionsMenu_CreationDateSelection.SelectedDate, SearchPastQuestionsMenu_LastAttemptDateSelection.SelectedDate, connection));
        }
        public static DataTable FetchQuestionsTable(MySqlConnection sqlConnection, string questionType, int questionDiff, string questionSucc, DateTime? questionCDate, DateTime? questionADate)
        {
            sqlConnection.Open();
            MySqlCommand sqlCommand = new MySqlCommand("SELECT Question_Written, Question_AUser, Question_AProgram, Question_Difficulty, Question_Outcome, Question_DCreation, Question_DAttempt FROM questions WHERE Question_Type = {0} AND Question_Difficulty = {1} AND Question_Outcome = {2} AND Question_DCreation = {3} AND Question_DAttempt = {4}"
                                                       ,sqlConnection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlCommand.ExecuteReader());
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }


    }
}
