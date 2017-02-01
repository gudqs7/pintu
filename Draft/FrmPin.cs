using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Draft
{
	public partial class FrmPin : Form
	{
		public FrmPin()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		public static int count = 4;//设置难度阶数

		//图片路径
		public static string imagepath ;

		//定义Label集合
		ArrayList labellist = new ArrayList();

		//保存Label集合
		ArrayList right = new ArrayList();

		bool isstrat;//判断是否开始

		int sumStep = 0; 

		static Image img = null;
		int size;
		private void Form1_Load(object sender, EventArgs e)
		{
			this.Focus();
			this.AutoScroll = true;
			ilPinTu.Images[2].Save("c:\\2.jpg");
			imagepath = "c:\\2.jpg";
			string[] path = CutApart(imagepath, count);
			img = Image.FromFile(imagepath);
			size = img.Width < img.Height ? img.Width : img.Height;
			this.Size = new Size(size/12*13, size/6*7);

			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < count; j++)
				{
					Label lbl = new Label();
					lbl.AutoSize = false;
					int cropsize = size / count;
					lbl.Size = new Size(cropsize, cropsize);
					int a = i * cropsize;
					int b = j * cropsize;
					lbl.Location = new Point(a, b);
					lbl.BorderStyle = BorderStyle.FixedSingle;
					lbl.Tag = i;
					//lbl.Text = count * i + j + "";
					lbl.Image = Image.FromFile(path[count * i + j]);
					right.Add(lbl);
				}
			}
			Label lbllast1 = (Label)right[right.Count - 1];
			lbllast1.Tag = -1;
			right[right.Count - 1] = lbllast1;
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < count; j++)
				{
					Label lbl = new Label();
					lbl.AutoSize = false;
					int cropsize = size / count;
					lbl.Size = new Size(cropsize, cropsize);
					int a = i * cropsize;
					int b = j * cropsize;
					lbl.Location = new Point(a, b);
					lbl.BorderStyle = BorderStyle.FixedSingle;
					lbl.Tag = i;
					//lbl.Text = count * i + j + "";
					lbl.Image = Image.FromFile(path[count * i + j]);
					lbl.MouseClick += lbl_MouseClick;
					//MessageBox.Show(path[count*i+j]);
					//MessageBox.Show(count*i+j+"");
					labellist.Add(lbl);
				}
			}
			Label lbllast = (Label)labellist[labellist.Count - 1];
			lbllast.Tag = -1;
			lbllast.Image = null;
			labellist[labellist.Count - 1] = lbllast;
			for (int i = 0; i < labellist.Count; i++)
			{
				Label lbl = (Label)labellist[i];
				this.Controls.Add(lbl);
			}

			for (int i = 0; i < 130; i++)
			{
				int sw = r.Next(0, 4);
				int keys = 0;
				switch (sw)
				{
					case 0:
						keys = (int)Keys.W;
						break;
					case 1:
						keys = (int)Keys.S;
						break;
					case 2:
						keys = (int)Keys.A;
						break;
					case 3:
						keys = (int)Keys.D;
						break;
					default:
						MessageBox.Show(sw+"");
						break;
				}
				zou(keys);
			}
			isstrat = true;
		}

		Random r = new Random();

		void lbl_MouseClick(object sender, MouseEventArgs e)
		{
			sumStep++;
			this.Focus();
			if (e.Clicks > 1)
			{
				return;
			}
			Label lbl = (Label)sender;
			int cropsize = size / count;
			Point p = new Point(lbl.Location.X + cropsize, lbl.Location.Y);
			foreach (Label item in labellist)
			{
				if (item.Tag.Equals(-1) && item.Location.Equals(p))
				{
					Point p2 = lbl.Location;
					lbl.Location = item.Location;
					item.Location = p2;
					CheckFinshed();
					return;
				}
			} p = new Point(lbl.Location.X - cropsize, lbl.Location.Y);
			foreach (Label item in labellist)
			{
				if (item.Tag.Equals(-1) && item.Location.Equals(p))
				{
					Point p2 = lbl.Location;
					lbl.Location = item.Location;
					item.Location = p2;
					CheckFinshed();
					return; ;
				}
			}
			p = new Point(lbl.Location.X, lbl.Location.Y - cropsize);
			foreach (Label item in labellist)
			{
				if (item.Tag.Equals(-1) && item.Location.Equals(p))
				{
					Point p2 = lbl.Location;
					lbl.Location = item.Location;
					item.Location = p2;
					CheckFinshed();
					return; ;
				}
			}
			p = new Point(lbl.Location.X, lbl.Location.Y + cropsize);
			foreach (Label item in labellist)
			{
				if (item.Tag.Equals(-1) && item.Location.Equals(p))
				{
					Point p2 = lbl.Location;
					lbl.Location = item.Location;
					item.Location = p2;
					CheckFinshed();
					return; ;
				}
			}

		}

		/// 判断是否完成
		/// <summary>
		/// 
		/// </summary>
		private void CheckFinshed()
		{
			if (isstrat==false)
			{
				return;
			}
			StringBuilder sb = new StringBuilder();
			bool notfinshed = true;
			for (int i = 0; i < right.Count; i++)
			{
				Label lblNow=(Label )labellist[i];
				Label lblRight=(Label)right[i];
				if (lblNow.Tag.Equals(lblRight.Tag)&&lblNow.Location.Equals(lblRight.Location))
				{
					
				}
				else
				{
					notfinshed = false;
				}
				
				sb.Append(lblNow.Location.X + "  " + lblNow.Location.Y +"  -->  "+ lblRight.Location.X + "  " + lblRight.Location.Y+"\n");
			}
			if (notfinshed)
			{
				if (sumStep<30)
				{
					MessageBox.Show("只用了"+sumStep+"步就完成了!不愧是天才.....");
				}
				else
				{
					MessageBox.Show("用了" + sumStep + "步!");
				}
			}
			//MessageBox.Show(sb.ToString());
		}

		public string[] CutApart(string inputimage, int Count)
		{
			string[] path = new string[Count * Count];
			string fileDirectory = Path.GetDirectoryName(inputimage);
			string fileExtension = Path.GetExtension(inputimage);
			string fileWithoutExtension = Path.GetFileNameWithoutExtension(inputimage);
			Image inputimg = Image.FromFile(inputimage);
			int imgSize = inputimg.Width < inputimg.Height ? inputimg.Width : inputimg.Height;
			int cropSize = imgSize / Count;
			ArrayList arealist = new ArrayList();

			for (int i = 0; i < Count; i++)
			{
				for (int j = 0; j < Count; j++)
				{
					int pointX = i * cropSize;
					int pointY = j * cropSize;
					int areaWidth = pointX + cropSize > imgSize ? imgSize - pointX : cropSize;
					int areaHeight = areaWidth;
					Rectangle rect = new Rectangle(pointX, pointY, areaWidth, areaHeight);
					arealist.Add(rect);
				}
			}

			for (int i = 0; i < arealist.Count; i++)
			{
				Rectangle rect = (Rectangle)arealist[i];
				string fileName = fileDirectory + "\\" + fileWithoutExtension + "_" + i.ToString() + fileExtension;
				Bitmap newBmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format64bppArgb);
				Graphics newBmpGraphics = Graphics.FromImage(newBmp);
				newBmpGraphics.DrawImage(inputimg, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
				newBmpGraphics.Save();
				switch (fileExtension)
				{
					case ".jpg":
					case ".jpeg":
						newBmp.Save(fileName, ImageFormat.Jpeg);
						break;
					case ".gif":
						newBmp.Save(fileName, ImageFormat.Gif);
						break;
					default:
						newBmp.Save(fileName, ImageFormat.Jpeg);
						break;
				}
				path[i] = fileName;
			}

			return path;
		}


		private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
			sumStep++;
			this.Focus();
			int keys = e.KeyChar;
			zou(keys);
		}

		void zou(int keys)
		{
			int cropsize = size / count;
			switch (keys)
			{
				case (int)Keys.W:
				case (int)Keys.W + 32:
				case (int)Keys.Up:
					foreach (Label item in labellist)
					{
						if (item.Tag.Equals(-1))
						{
							Point p = new Point(item.Location.X, item.Location.Y + cropsize);
							foreach (Label change in labellist)
							{
								if (change.Location.Equals(p))
								{
									change.Location = item.Location;
									item.Location = p;
									CheckFinshed();
									return;
								}
							}
						}
					}
					break;
				case (int)Keys.S:
				case (int)Keys.S + 32:
				case (int)Keys.Down:
					foreach (Label item in labellist)
					{
						if (item.Tag.Equals(-1))
						{
							Point p = new Point(item.Location.X, item.Location.Y - cropsize);
							foreach (Label change in labellist)
							{
								if (change.Location.Equals(p))
								{
									change.Location = item.Location;
									item.Location = p;
									CheckFinshed();
									return;
								}
							}
						}
					}
					break;
				case (int)Keys.A:
				case (int)Keys.A + 32:
				case (int)Keys.Left:
					foreach (Label item in labellist)
					{
						if (item.Tag.Equals(-1))
						{
							Point p = new Point(item.Location.X + cropsize, item.Location.Y);
							foreach (Label change in labellist)
							{
								if (change.Location.Equals(p))
								{
									change.Location = item.Location;
									item.Location = p;
									CheckFinshed();
									return;
								}
							}
						}
					}
					break;
				case (int)Keys.D:
				case (int)Keys.D + 32:
				case (int)Keys.Right:
					foreach (Label item in labellist)
					{
						if (item.Tag.Equals(-1))
						{
							Point p = new Point(item.Location.X - cropsize, item.Location.Y);
							foreach (Label change in labellist)
							{
								if (change.Location.Equals(p))
								{
									change.Location = item.Location;
									item.Location = p;
									CheckFinshed();
									return;
								}
							}
						}
					}
					break;
				default:
					break;
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			this.Text = "已走"+sumStep+"步";
		}

	}
}
