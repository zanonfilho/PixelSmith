using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PixelSmith {
	class box {

		private double[,] visual_extents; //axis  {x,y,z},  {-,+}

		public GeometryModel3D model;

		//public Point3DCollection p3dc;

		public List<Point3D> p3dl;

		public List<Int32> i32l;




		public box(Point3D position, double x_length, double y_length, double z_length) {
			p3dl = new List<Point3D>();
			i32l = new List<int>();


			visual_extents = new double[3, 2];  // axis  {x,y,z},  {-,+}

			visual_extents[0, 0] = position.X - (x_length / 2.0);
			visual_extents[0, 1] = position.X + (x_length / 2.0);

			visual_extents[1, 0] = position.Y - 0;
			visual_extents[1, 1] = position.Y + y_length;

			visual_extents[2, 0] = position.Z - (z_length / 2.0);
			visual_extents[2, 1] = position.Z + (z_length / 2.0);

			generate_box_model();


		}














		private void generate_plane(MeshGeometry3D mesh, Point3D a, Point3D b, Point3D c, Point3D d) {
			p3dl.Add(a);
			p3dl.Add(b);
			p3dl.Add(c);
			p3dl.Add(d);

			//p3dl.Add(c);
			//p3dl.Add(d);
			//p3dl.Add(a);

			i32l.Add(p3dl.Count - 4);
			i32l.Add(p3dl.Count - 3);
			i32l.Add(p3dl.Count - 2);

			i32l.Add(p3dl.Count - 2);
			i32l.Add(p3dl.Count - 1);
			i32l.Add(p3dl.Count - 4);


			//p3dc.Add(a);
			//p3dc.Add(b);
			//p3dc.Add(c);

			//mesh.Positions.Add(a);
			//mesh.Positions.Add(b);
			//mesh.Positions.Add(c);

			//mesh.Positions.Add(c);
			//mesh.Positions.Add(d);
			//mesh.Positions.Add(a);

			//mesh.Positions.Add(a);
			//mesh.TextureCoordinates.Add(new Point(0, 1));

			//mesh.Positions.Add(b);
			//mesh.TextureCoordinates.Add(new Point(0, 0));

			//mesh.Positions.Add(c);
			//mesh.TextureCoordinates.Add(new Point(1, 0));

			//mesh.Positions.Add(d);
			//mesh.TextureCoordinates.Add(new Point(1, 1));


			//mesh.TriangleIndices.Add(mesh.Positions.Count - 4); // a
			//mesh.TriangleIndices.Add(mesh.Positions.Count - 3); // b
			//mesh.TriangleIndices.Add(mesh.Positions.Count - 2); // c

			//mesh.TriangleIndices.Add(mesh.Positions.Count - 2); // c
			//mesh.TriangleIndices.Add(mesh.Positions.Count - 1); // d
			//mesh.TriangleIndices.Add(mesh.Positions.Count - 4); // a
		}









		private void generate_box_model() {
			MeshGeometry3D mesh = new MeshGeometry3D();

			Point3D[] points = new Point3D[8];

			for (int z = 0; z < 2; z++)
			{ // corresponds to sign of z axis
				for (int y = 0; y < 2; y++)
				{
					for (int x = 0; x < 2; x++)
					{
						points[(z * 4) + (y * 2) + x] = new Point3D(visual_extents[0, x], visual_extents[1, y], visual_extents[2, z]);
					}
				}
			}

			generate_plane(mesh, points[6], points[4], points[5], points[7]);
			generate_plane(mesh, points[7], points[5], points[1], points[3]);

			generate_plane(mesh, points[3], points[1], points[0], points[2]);
			generate_plane(mesh, points[2], points[0], points[4], points[6]);

			generate_plane(mesh, points[2], points[6], points[7], points[3]);
			generate_plane(mesh, points[4], points[0], points[1], points[5]);


			//		MaterialGroup material_group = new MaterialGroup();


			//material_group.Children.Add(new EmissiveMaterial(new ImageBrush(new BitmapImage(new Uri("c:\\dumb.jpg")))));
			//		material_group.Children.Add(new EmissiveMaterial(new SolidColorBrush( color  )));

			//material_group.Children.Add(new DiffuseMaterial(new SolidColorBrush(color)));

			//material_group.Children.Add(new EmissiveMaterial(new ImageBrush(new BitmapImage(new Uri("c:\\dumb.jpg")))));

			//			DiffuseMaterial dm = new DiffuseMaterial(new SolidColorBrush(color));
			//dm.Color = color;
			//dm.AmbientColor = color;
			//dm.AmbientColor = color;
			//em.Color = color;

			//			model = new GeometryModel3D(mesh, dm);

			//			model.Freeze();
		}









	}
}
