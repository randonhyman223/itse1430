﻿/*
 * Randon Hyman
 * ITSE 1430
 * Lab 3
 */
using System;
using System.Linq;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class MovieDetailForm : Form
    {
        #region Construction

        public MovieDetailForm()
        {
            InitializeComponent();
        }

        public MovieDetailForm( string title ) : this()
        {
            Text = title;
        }

        public MovieDetailForm( Movie movie ) :this("Edit Movie")
        {
            Movie = movie;
        }
        #endregion

        /// <summary>Gets or sets the movie being edited.</summary>
        public Movie Movie { get; set; }
        
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //Load movie
            if (Movie != null)
            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _txtLength.Text = Movie.Length.ToString();
                _chkIsDiscontinued.Checked = Movie.IsDiscontinued;
            };

            ValidateChildren();
        }

        #region Event Handlers

        private void OnCancel( object sender, EventArgs e )
        {
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //Force validation of child controls
            if (!ValidateChildren())
                return;

            // Create movie - using object initializer syntax
            var movie = new Movie() {
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                Length = ConvertToLength(_txtLength),
                IsDiscontinued = _chkIsDiscontinued.Checked,
            };

            //Validate movie using IValidatableObject
            var errors = ObjectValidator.Validate(movie);
            if (errors.Count() > 0)
            {
                //Get first error
                DisplayError(errors.ElementAt(0).ErrorMessage);
                return;
            };            
            
            //Return from form
            Movie = movie;
            DialogResult = DialogResult.OK;

            Close();
        }
        #endregion
        
        private void DisplayError ( string message )
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
        private decimal ConvertToLength ( TextBox control )
        {
            if (Decimal.TryParse(control.Text, out var length))
                return length;

            return -1;
        }

        private void _txtName_Validating( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var textbox = sender as TextBox;

            if (String.IsNullOrEmpty(textbox.Text))
            {

                _errorProvider.SetError(textbox, "Title is required");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }

        private void _txtPrice_Validating( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var textbox = sender as TextBox;

            var length = ConvertToLength(textbox);
            if (length < 0)
            {
                _errorProvider.SetError(textbox, "Length must be >= 0");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }

        private void label4_Click( object sender, EventArgs e )
        {

        }
    }
}
