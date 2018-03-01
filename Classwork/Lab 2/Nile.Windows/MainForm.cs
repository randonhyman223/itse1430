/* 
 * Randon Hyman
 * ITSE 1430
 * Lab 2
 */
using System;
using System.Windows.Forms;

namespace MovieLib.Windows
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

        }
        private void PlayingWithProductMembers ()
        { 
            //Create a new product
            var product = new Product();

            //Cannot use properties as out parameters
            Decimal.TryParse("123", out var price);
            product.Price = price;

            //Get the property Name, no need for a function
            var name = product.Name;

            //Set the property Name, Price and IsDiscontinued
            product.Name = "Product A";
            product.Price = 50;
            product.IsDiscontinued = true;

            //product.ActualPrice = 10;
            var price2 = product.ActualPrice;                
 
            //Validate the product
            var error = product.Validate();

            //Convert anything to a string
            var str = product.ToString();

            //Create another product
            var productB = new Product();         

            //Validate the new product
            error = productB.Validate();
        }

        #region Event Handlers

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd ( object sender, EventArgs e )
        {
            var button = sender as ToolStripMenuItem;

            var form = new ProductDetailForm("Add Movie Details");

            //Show form modally
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //"Add" the product
            _product = form.Product;
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            if (_product == null)
                return;

            var form = new ProductDetailForm(_product);
            //form.Product = _product;

            //Show form modally
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //"Editing" the product
            _product = form.Product;
        }

        private void OnProductRemove( object sender, EventArgs e )
        {
            if (!ShowConfirmation("Are you sure?", "Remove Movie"))                             
                return;

            //Remove product
            _product = null;
        }        
        
        private void OnHelpAbout( object sender, EventArgs e )
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
            // MessageBox.Show(this, "Not implemented", "Help About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        private bool ShowConfirmation ( string message, string title )
        {
            return MessageBox.Show(this, message, title
           , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes;
        }

        private Product _product;
    }
}
