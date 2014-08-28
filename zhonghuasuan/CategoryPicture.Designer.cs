namespace zhonghuasuan
{
    partial class CategoryPicture
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.price = new System.Windows.Forms.LinkLabel();
            this.title = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.price.Location = new System.Drawing.Point(5, 171);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(138, 12);
            this.price.TabIndex = 7;
            this.price.TabStop = true;
            this.price.Text = "9.9=>99.99  800=>80";
            this.price.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.price_LinkClicked);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(3, 6);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(123, 12);
            this.title.TabIndex = 6;
            this.title.Text = "彩色塑料膜  装修膜";
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(3, 24);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(140, 140);
            this.pic.TabIndex = 5;
            this.pic.TabStop = false;
            this.pic.DoubleClick += new System.EventHandler(this.pic_DoubleClick);
            // 
            // CategoryPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.price);
            this.Controls.Add(this.title);
            this.Controls.Add(this.pic);
            this.Name = "CategoryPicture";
            this.Size = new System.Drawing.Size(147, 188);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel price;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox pic;
    }
}
