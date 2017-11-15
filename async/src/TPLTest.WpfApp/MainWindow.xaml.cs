using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TPLTest.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
	    private readonly Repository _repository;
        public MainWindow()
        {
            InitializeComponent();
	        _repository = new Repository();
        }

	    private async void RunTask_OnClick(object sender, RoutedEventArgs e)
	    {
		    var task = await _repository.GetModelAsync();

		    RunTask.Content = "Task complete, run again";
	    }
    }
}
