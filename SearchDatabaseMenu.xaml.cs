using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace NEA___Boolean_and_Binary_Algebra_Revision_Tool
{
    /// <summary>
    /// Interaction logic for SearchDatabaseMenu.xaml
    /// </summary>
    public partial class SearchDatabaseMenu : Page
    {
        public SearchDatabaseMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// methods to navigate from this menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReturnMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void SearchDatabaseMenu_PastQuesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchPastQuestionsMenu());
        }

        private void SearchDatabaseMenu_QuesSuccRateButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchQuestionsSuccessRatesMenu());
        }

        private void SearchDatabaseMenu_RulesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchRulesMenu());
        }

        private void SearchDatabaseMenu_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchDatabaseMenu_HelpPage());
        }

        private void SearchDatabaseMenu_ReturnMainButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }
    }
}
