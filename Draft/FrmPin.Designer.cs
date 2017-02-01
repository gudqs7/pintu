namespace Draft
{
	partial class FrmPin
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPin));
			this.ilPinTu = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// ilPinTu
			// 
			this.ilPinTu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPinTu.ImageStream")));
			this.ilPinTu.TransparentColor = System.Drawing.Color.Transparent;
			this.ilPinTu.Images.SetKeyName(0, "1.jpg");
			this.ilPinTu.Images.SetKeyName(1, "5.jpg");
			this.ilPinTu.Images.SetKeyName(2, "test1.jpg");
			// 
			// FrmPin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 440);
			this.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmPin";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList ilPinTu;



	}
}

