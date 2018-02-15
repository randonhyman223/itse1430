using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            var product = new Product();
            Decimal.TryParse("123", out var price);
            product.Price = price;

            var name = product.Name;
            //product.Name = "Product A";
            product.SetName("Product A");
            //product.Description = "None";
            product.Price = 50;
            product.IsDiscontinued = true;

            var price2 = product.ActualPrice;

            var error = product.ToString();

            var str = product.ToString();

            var productB = new Product();
            // product.Name = "Product B";
            //productB.SetName("ProductB");
            //productB.Description = product.Description;
            error = productB.Validate();

        }
    }
}
