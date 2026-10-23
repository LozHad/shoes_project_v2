namespace shoes_project_v2
{
    partial class ProductCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbImage = new PictureBox();
            lblHeader = new Label();
            lblCategory = new Label();
            lblQuantity = new Label();
            lblComposition = new Label();
            lblPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // pbImage
            // 
            pbImage.Location = new Point(14, 27);
            pbImage.Margin = new Padding(3, 4, 3, 4);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(120, 120);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblHeader.Location = new Point(159, 13);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(625, 34);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "label1";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblHeader.Click += lblHeader_Click;
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Calibri", 9.75F);
            lblCategory.Location = new Point(150, 57);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(466, 24);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "label1";
            // 
            // lblQuantity
            // 
            lblQuantity.Font = new Font("Calibri", 9.75F);
            lblQuantity.Location = new Point(150, 83);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(466, 24);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "label1";
            // 
            // lblComposition
            // 
            lblComposition.Font = new Font("Calibri", 9.75F);
            lblComposition.Location = new Point(150, 109);
            lblComposition.Name = "lblComposition";
            lblComposition.Size = new Size(518, 49);
            lblComposition.TabIndex = 4;
            lblComposition.Text = "label1";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Right;
            lblPrice.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPrice.Location = new Point(622, 59);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(162, 48);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "label1";
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPrice);
            Controls.Add(lblComposition);
            Controls.Add(lblQuantity);
            Controls.Add(lblCategory);
            Controls.Add(lblHeader);
            Controls.Add(pbImage);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductCard";
            Size = new Size(800, 174);
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbImage;
        private Label lblHeader;
        private Label lblCategory;
        private Label lblQuantity;
        private Label lblComposition;
        private Label lblPrice;
    }
}
