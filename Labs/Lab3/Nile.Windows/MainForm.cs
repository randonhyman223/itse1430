/*
 * Randon Hyman
 * ITSE 1430
 * Lab 3
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Nile.Data;
using Nile.Data.Memory;

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

            RefreshUI();
        }

        #region Event Handlers

        //Called when a cell is double clicked
        private void OnCellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            EditMovie(movie);
        }

        //Called when a key is pressed while in a cell
        private void OnCellKeyDown( object sender, KeyEventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                DeleteMovie(movie);
            } else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EditMovie(movie);
            };
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var button = sender as ToolStripMenuItem;

            var form = new MovieDetailForm("Add Movie");

            //Show form modally
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //Add to database
            _database.Add(form.Movie, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);

            RefreshUI();                
        }

        private void OnMovieEdit( object sender, EventArgs e )
        {
            //Get selected movies
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show(this, "No movie selected", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            EditMovie(movie);
        }

        private void OnMovieRemove( object sender, EventArgs e )
        {
            //Get selected movies
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show(this, "No movie selected", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            DeleteMovie(movie);
        }
        
        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Not implemented", "Help About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        #region Private Members

        //Helper method to handle deleting movies
        private void DeleteMovie( Movie movie )
        {
            if (!ShowConfirmation("Are you sure?", "Remove Movie"))
                return;

            //Remove movie
            _database.Remove(movie.Id);

            RefreshUI();
        }

        //Helper method to handle editing movies
        private void EditMovie( Movie product )
        {
            var form = new MovieDetailForm(product);
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //Update the movie
            form.Movie.Id = product.Id;
            _database.Update(form.Movie, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);

            RefreshUI();
        }

        private Movie GetSelectedMovie ( )
        {
            //Get the first selected row in the grid, if any
            if (dataGridView1.SelectedRows.Count > 0)
                return dataGridView1.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void RefreshUI ()
        {
            //Get movie
            var products = _database.GetAll();
            productBindingSource.DataSource = products.ToList(); 
        }

        private bool ShowConfirmation ( string message, string title )
        {
            return MessageBox.Show(this, message, title
                             , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                           == DialogResult.Yes;
        }

        private IMovieDatabase _database = new MemoryProductDatabase();
    }
    #endregion;
}
