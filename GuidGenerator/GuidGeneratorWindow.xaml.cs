using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

namespace GuidGenerator {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		static readonly Guid k_Guid = Guid.NewGuid();

		static readonly string[] k_Formats = new string[] { "D","N","B","P" };

		readonly ImmutableDictionary<string,string> m_FormatedGuids;

		public MainWindow () {
			InitializeComponent();
			m_FormatedGuids = k_Formats.ToImmutableDictionary(format => format,format => k_Guid.ToString(format));
			formatSelector.ItemsSource = m_FormatedGuids;
			formatSelector.SelectedIndex = 0;
		}

		private void generateButton_Click (object sender,RoutedEventArgs e) {
			if (formatSelector.SelectedItem is KeyValuePair<string,string> format) {
				textBox.Text = Guid.NewGuid().ToString(format.Key);
			}
		}

	}
}
