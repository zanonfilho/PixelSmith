using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace PixelSmith {
	class scatterplot {

		public ModelVisual3D model;

		public ModelVisual3D highlight_model;


		public scatterplot() {

			make_model();
		}


		private void make_model() {
			model = new ModelVisual3D();

			highlight_model = new ModelVisual3D();

			Random rand = new Random((int)System.DateTime.Now.Ticks);

			//	box b;

			MeshGeometry3D mg3d = new MeshGeometry3D();

			MeshGeometry3D other_mg3d = new MeshGeometry3D();




			for (double x = -5; x <= 5; x += 0.5)
			{
				for (double y = -5; y <= 5; y += 0.5)
				{
					for (double z = -5; z <= 5; z += 0.5)
					{
						box b = new box(new Point3D(x, y, z), .3, .3, .3);

						if (rand.Next(100) > 90)
						{
							for (int i = 0; i < b.p3dl.Count; ++i)
							{
								other_mg3d.Positions.Add(b.p3dl[i]);
							}

							int count = other_mg3d.Positions.Count;

							for (int i = 0; i < b.i32l.Count; ++i)
							{
								other_mg3d.TriangleIndices.Add(b.i32l[i] + count);
							}
						}
						else
						{

							for (int i = 0; i < b.p3dl.Count; ++i)
							{
								mg3d.Positions.Add(b.p3dl[i]);
							}

							int count = mg3d.Positions.Count;

							for (int i = 0; i < b.i32l.Count; ++i)
							{
								mg3d.TriangleIndices.Add(b.i32l[i] + count);
							}
						}
					}

				}

			}


			//model.Children.Add(b.model);

			//}

			EmissiveMaterial em = new EmissiveMaterial(new SolidColorBrush(Color.FromArgb(12, 255, 255, 255)));

			DiffuseMaterial dm = new DiffuseMaterial(new SolidColorBrush(Colors.Yellow));

			//DiffuseMaterial dm = new DiffuseMaterial(Brushes.White);
			//dm.Color = Colors.Orchid;


			GeometryModel3D gm3d = new GeometryModel3D(mg3d, em);

			GeometryModel3D gm3d2 = new GeometryModel3D(other_mg3d, dm);


			model.Content = gm3d;

			highlight_model.Content = gm3d2;

			//model.Freeze();


		}



	}
}
