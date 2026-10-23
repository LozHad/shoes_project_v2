using shoes_project_v2.Models;

namespace shoes_project_v2
{
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
            this.Load += FormProducts_Load;
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadCatalog();
            flowLayoutPanelProducts.Dock = DockStyle.Fill;
            flowLayoutPanelProducts.AutoScroll = true;
        }

        private void LoadCatalog()
        {
            flowLayoutPanelProducts.Controls.Clear();

            try
            {
                using (var db = new ShoesDbContext())
                {
                    var products = db.VProductsCatalogs.ToList();
                    var oneMonthAgo = DateOnly.FromDateTime(DateTime.Now.AddDays(-30));

                    var recentProductIds = db.Orders
                        .Where(o => o.OrderDate >= oneMonthAgo)
                        .SelectMany(o => o.OrderItems.Select(oi => (long)oi.StockItem.ProductId))
                        .Distinct()
                        .ToList();


                    foreach (var p in products)
                    {
                        ProductCard card = new ProductCard();

                        bool hasOrders = p.ProductId.HasValue && recentProductIds.Contains((long)p.ProductId);

                        Image productImg = LoadProductImage(p.Image);

                        card.FillData(
                            brand: p.ManufacturerName ?? "Без бренда",
                            name: p.ProductName,
                            category: p.CategoryName ?? "Без категории",
                            composition: p.Composition ?? "Не указан",
                            totalPairs: (int)(p.QuantityAvailable ?? 0),
                            basePrice: (decimal)(p.Price ?? 0),
                            hasOrdersLastMonth: hasOrders,
                            productImages: productImg
                        );

                        flowLayoutPanelProducts.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить каталог товаров: {ex.Message}", "Ошибка подключения к БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image LoadProductImage(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;

            try
            {
                string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                string fullPath = Path.Combine(imagesFolder, imageName);

                if (File.Exists(fullPath))
                {
                    return Image.FromFile(fullPath);
                }
            }
            catch
            {
            }

            return null;
        }
    }
}
