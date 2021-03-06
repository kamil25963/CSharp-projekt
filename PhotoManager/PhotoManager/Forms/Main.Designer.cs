﻿using System;

namespace PhotoManager
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.imageListMin = new System.Windows.Forms.ImageList(this.components);
            this.imgListView = new System.Windows.Forms.ListView();
            this.imageListNormal = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.albumListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.UserNameInfoLabel = new System.Windows.Forms.Label();
            this.AlbumInfoLabel = new System.Windows.Forms.Label();
            this.ImageMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AlbumDescriptionLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.ImageMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListMin
            // 
            this.imageListMin.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageListMin.ImageSize = new System.Drawing.Size(64, 64);
            this.imageListMin.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgListView
            // 
            this.imgListView.LargeImageList = this.imageListMin;
            this.imgListView.Location = new System.Drawing.Point(16, 147);
            this.imgListView.Margin = new System.Windows.Forms.Padding(4);
            this.imgListView.Name = "imgListView";
            this.imgListView.Size = new System.Drawing.Size(1335, 632);
            this.imgListView.TabIndex = 0;
            this.imgListView.UseCompatibleStateImageBehavior = false;
            this.imgListView.ItemActivate += new System.EventHandler(this.imgListView_ItemActivate);
            this.imgListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgListView_MouseClick);
            // 
            // imageListNormal
            // 
            this.imageListNormal.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListNormal.ImageSize = new System.Drawing.Size(100, 100);
            this.imageListNormal.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.createNewAlbumToolStripMenuItem,
            this.saveAlbumToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(58, 24);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.openToolStripMenuItem.Text = "Add New Photos";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // createNewAlbumToolStripMenuItem
            // 
            this.createNewAlbumToolStripMenuItem.Name = "createNewAlbumToolStripMenuItem";
            this.createNewAlbumToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.createNewAlbumToolStripMenuItem.Text = "Create New Album";
            this.createNewAlbumToolStripMenuItem.Click += new System.EventHandler(this.createNewAlbumToolStripMenuItem_Click);
            // 
            // saveAlbumToolStripMenuItem
            // 
            this.saveAlbumToolStripMenuItem.Name = "saveAlbumToolStripMenuItem";
            this.saveAlbumToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.saveAlbumToolStripMenuItem.Text = "Save Album";
            this.saveAlbumToolStripMenuItem.Click += new System.EventHandler(this.saveAlbumToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.logoutToolStripMenuItem.Text = "Log out";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // albumListToolStripMenuItem
            // 
            this.albumListToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.albumListToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.albumListToolStripMenuItem.Name = "albumListToolStripMenuItem";
            this.albumListToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.albumListToolStripMenuItem.Text = "AlbumList";
            this.albumListToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.albumListToolStripMenuItem_DropDownItemClicked);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.albumListToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Margin = new System.Windows.Forms.Padding(5, 10, 0, 10);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1365, 38);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // UserNameInfoLabel
            // 
            this.UserNameInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserNameInfoLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UserNameInfoLabel.Location = new System.Drawing.Point(0, 38);
            this.UserNameInfoLabel.Name = "UserNameInfoLabel";
            this.UserNameInfoLabel.Size = new System.Drawing.Size(1365, 23);
            this.UserNameInfoLabel.TabIndex = 2;
            this.UserNameInfoLabel.Text = "Hello ";
            this.UserNameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlbumInfoLabel
            // 
            this.AlbumInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlbumInfoLabel.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AlbumInfoLabel.Location = new System.Drawing.Point(0, 61);
            this.AlbumInfoLabel.Name = "AlbumInfoLabel";
            this.AlbumInfoLabel.Size = new System.Drawing.Size(1365, 23);
            this.AlbumInfoLabel.TabIndex = 3;
            this.AlbumInfoLabel.Text = "You do not have photo albums.";
            this.AlbumInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageMenuStrip
            // 
            this.ImageMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ImageMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delateToolStripMenuItem});
            this.ImageMenuStrip.Name = "ImageMenuStrip";
            this.ImageMenuStrip.Size = new System.Drawing.Size(123, 28);
            // 
            // delateToolStripMenuItem
            // 
            this.delateToolStripMenuItem.Name = "delateToolStripMenuItem";
            this.delateToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.delateToolStripMenuItem.Text = "Delate";
            this.delateToolStripMenuItem.Click += new System.EventHandler(this.delateToolStripMenuItem_Click);
            // 
            // AlbumDescriptionLabel
            // 
            this.AlbumDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlbumDescriptionLabel.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AlbumDescriptionLabel.Location = new System.Drawing.Point(0, 84);
            this.AlbumDescriptionLabel.Name = "AlbumDescriptionLabel";
            this.AlbumDescriptionLabel.Size = new System.Drawing.Size(1365, 23);
            this.AlbumDescriptionLabel.TabIndex = 4;
            this.AlbumDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 792);
            this.Controls.Add(this.AlbumDescriptionLabel);
            this.Controls.Add(this.AlbumInfoLabel);
            this.Controls.Add(this.UserNameInfoLabel);
            this.Controls.Add(this.imgListView);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photo Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ImageMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ImageList imageListMin;
		private System.Windows.Forms.ListView imgListView;
        private System.Windows.Forms.ImageList imageListNormal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewAlbumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem albumListToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveAlbumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label UserNameInfoLabel;
        private System.Windows.Forms.Label AlbumInfoLabel;
        private System.Windows.Forms.ContextMenuStrip ImageMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem delateToolStripMenuItem;
        private System.Windows.Forms.Label AlbumDescriptionLabel;
    }
}

