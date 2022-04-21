using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part_twelve
{
    public partial class MainForm : Form
    {
        List<string> movies = new List<string>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string film = txtTitle.Text.Trim();
            if (!String.IsNullOrEmpty(film) && !movies.Contains(film))
                movies.Add(film);
            lstMovies.DataSource = null;
            lstMovies.DataSource = movies;
            txtTitle.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstMovies.SelectedIndex >= 0)
                movies.Remove((string)lstMovies.SelectedItem);
            lstMovies.DataSource = null;
            lstMovies.DataSource = movies;
            txtTitle.Clear();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            movies.Sort();
            lstMovies.DataSource = null;
            lstMovies.DataSource = movies;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofdMovie.ShowDialog() == DialogResult.OK)
            {
                movies.Clear();
                foreach (string line in File.ReadLines(ofdMovie.FileName))
                    movies.Add(line);
                lstMovies.DataSource = null;
                lstMovies.DataSource = movies;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sfdMovie.ShowDialog() == DialogResult.OK)
            {
                string file = sfdMovie.FileName;
                if (file.Substring(file.Length - 4) != ".txt")
                    file += ".txt";
                StreamWriter writer = new StreamWriter(file);
                foreach (string movie in movies)
                    writer.WriteLine(movie);
                writer.Close();
            }
        }
    }
}
