namespace shoes_project_v2
{
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        public void FillData(string brand, string name, string category, string composition, int totalPairs, decimal basePrice, bool hasOrdersLastMonth, Image productImages)
        {
            lblHeader.Text = $"{brand} | {name}";

            lblCategory.Text = $"Категория: {category}";
            lblComposition.Text = $"Состав: {composition}";

            if (totalPairs > 5)
            {
                lblQuantity.Text = "Количество: много";
            }
            else
            {
                lblQuantity.Text = "Количество: мало";
            }

            decimal finalPrice = basePrice;
            if (!hasOrdersLastMonth)
            {
                finalPrice = basePrice * 0.75m;
            }
            lblPrice.Text = $"{finalPrice:N2} руб.";

            if (productImages != null)
            {
                pbImage.Image = productImages;
            }
            else
            {
                pbImage.Image = Properties.Resources.picture;
            }

            if (totalPairs <= 3)
            {
                this.BackColor = Color.FromArgb(255, 220, 220);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }
    }
}
