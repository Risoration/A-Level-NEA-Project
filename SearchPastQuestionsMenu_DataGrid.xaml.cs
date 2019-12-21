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
    /// Interaction logic for SearchPastQuestionMenu_DataGrid.xaml
    /// </summary>
    public partial class SearchPastQuestionsMenu_DataGrid : Page
    {
        public SearchPastQuestionsMenu_DataGrid(string questionType, int questionDifficulty, string questionOutcome, DateTime? questionDCreation, DateTime? questionDAttempt, MySqlConnection sqlConnection)
        {
            InitializeComponent();

            dataGrid.DataContext = SearchPastQuestionsMenu.FetchQuestionsTable(sqlConnection, questionType, questionDifficulty, questionOutcome, questionDCreation, questionDAttempt);
        }

        private void SearchRulesMenu_DataGrid_SearchPastQuestionsMenu_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchPastQuestionsMenu());
        }

        private void SearchPastQuestionsMenu_DataGrid_ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }
    }
}
