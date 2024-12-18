﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OopLabs.Linq
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load; // Подписываемся на событие Load
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeArtistsListBox();
        }

        private void InitializeArtistsListBox()
        {
            var artists = Album.GetAlbums()
                .Select(album => album.Artist)
                .Distinct()
                .OrderBy(artist => artist) // Сортировка исполнителей
                .ToList();

            ArtistsListBox.DataSource = artists;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ArtistsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AlbumsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Исполнители";
            // 
            // ArtistsListBox
            // 
            this.ArtistsListBox.FormattingEnabled = true;
            this.ArtistsListBox.ItemHeight = 16;
            this.ArtistsListBox.Location = new System.Drawing.Point(12, 20);
            this.ArtistsListBox.Name = "ArtistsListBox";
            this.ArtistsListBox.Size = new System.Drawing.Size(258, 228);
            this.ArtistsListBox.TabIndex = 1;
            this.ArtistsListBox.SelectedIndexChanged += new System.EventHandler(this.ArtistsListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Альбомы";
            // 
            // AlbumsListBox
            // 
            this.AlbumsListBox.FormattingEnabled = true;
            this.AlbumsListBox.ItemHeight = 16;
            this.AlbumsListBox.Location = new System.Drawing.Point(279, 20);
            this.AlbumsListBox.Name = "AlbumsListBox";
            this.AlbumsListBox.Size = new System.Drawing.Size(283, 228);
            this.AlbumsListBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(576, 253);
            this.Controls.Add(this.AlbumsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArtistsListBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ArtistsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedArtist = ArtistsListBox.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedArtist))
            {
                var albums = Album.GetAlbums()
                    .Where(album => album.Artist == selectedArtist)
                    .OrderByDescending(album => album.Date) // Сортировка альбомов
                    .ToList();

                AlbumsListBox.DataSource = albums;
                AlbumsListBox.DisplayMember = "Title";
            }
        }
    }
}