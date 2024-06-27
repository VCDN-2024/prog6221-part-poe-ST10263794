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
using System.Windows.Shapes;

namespace ST10263794_PROG6221_POE_Part3
{
    public partial class StepEntryWindow : Window
    {
        public string Step { get; private set; }

        public StepEntryWindow()
        {
            InitializeComponent();
        }

        // Event handler for saving the step
        private void SaveStep_Click(object sender, RoutedEventArgs e)
        {
            Step = StepDescription.Text;
            DialogResult = true;
            Close();
        }
    }
}
