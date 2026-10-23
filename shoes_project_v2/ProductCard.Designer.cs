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
            pbImage.Location = new Point(13, 10);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(130, 130);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblHeader.Location = new Point(172, 10);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(574, 40);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "label1";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCategory.Location = new Point(172, 50);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(38, 15);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "label1";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblQuantity.Location = new Point(172, 74);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(38, 15);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "label1";
            // 
            // lblComposition
            // 
            lblComposition.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblComposition.Location = new Point(172, 98);
            lblComposition.Name = "lblComposition";
            lblComposition.Size = new Size(574, 42);
            lblComposition.TabIndex = 4;
            lblComposition.Text = "label1";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Right;
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPrice.Location = new Point(535, 50);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(70, 27);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "label1";
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPrice);
            Controls.Add(lblComposition);
            Controls.Add(lblQuantity);
            Controls.Add(lblCategory);
            Controls.Add(lblHeader);
            Controls.Add(pbImage);
            Name = "ProductCard";
            Size = new Size(755, 150);
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
