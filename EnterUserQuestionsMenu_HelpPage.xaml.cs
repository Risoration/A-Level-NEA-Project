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
    /// Interaction logic for EnterUserQuestionsMenu_HelpPage.xaml
    /// </summary>
    public partial class EnterUserQuestionsMenu_HelpPage : Page
    {
        public EnterUserQuestionsMenu_HelpPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// methods to navigate from this menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterUserQuestionsMenu_HelpPage_ReturnToMain_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void ReturnToEnterUserQuestionsMenu_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EnterUserQuestionsMenu());
        }
    }
}
