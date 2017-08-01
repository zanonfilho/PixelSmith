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

namespace PixelSmith {
	/// <summary>
	/// Interaction logic for SelectImagesFinished.xaml
	/// </summary>
	public partial class SelectImages : Window {
		public SelectImages() {
			InitializeComponent();

			this.DataContext = Models.ArtDataSource.GetArtProjects();

		}
	}
}
