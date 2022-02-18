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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCas
{
    /// <summary>
    /// Interaction logic for Spinner.xaml
    /// </summary>
    public partial class Spinner : UserControl
    {
        public Spinner()
        {
            InitializeComponent();
            ((Storyboard)FindResource("WaitStoryboard")).Begin();

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ((Storyboard)FindResource("WaitStoryboard")).Stop();
        }
    }
}
