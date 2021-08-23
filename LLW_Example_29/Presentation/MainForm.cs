using DataAccessLayer;
using DataAccessLayer.AccessLayers;
using Domain.Models;
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

namespace Presentation
{
    public partial class MainForm : Form
    {
        private AccessLayer accessLayer;
        private Article article;
        private Article SelectedArticle
        {
            get => this.article;
            set
            {
                this.article = value;
                //disable the edit/delete buttons when no article was selected
                ChangeDeleteEditButtonsStatus(this.article is not null);
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //add closing event to dispose the access layer properly
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            //choose between different access layers
            //this.accessLayer = new ListAccessLayer();
            this.accessLayer = new SqliteAccessLayer($"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "database.db")}");

            //to disable the edit/delete buttons when the list is empty at the start
            this.SelectedArticle = null;

            RefreshDataGridBindings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.accessLayer is not null)
                this.accessLayer.Dispose();
        }

        private void DGArticles_SelectionChanged(object sender, EventArgs e)
        {
            //check if the selected article is in range of the list
            //to avoid the error that occur when deleting an article
            if (DGArticles.CurrentRow.Index < this.accessLayer.Get().Count)
                this.SelectedArticle = DGArticles.CurrentRow.DataBoundItem as Article;
            else
                this.SelectedArticle = null;
        }

        private void DGArticles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                //display context menu on the mouse right click location
                contextMenuStrip.Show(this, e.Location);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //not passing article in the constructor to enter add mode
            ModifyForm modifyForm = new ModifyForm(this.accessLayer);
            modifyForm.ShowDialog();

            RefreshDataGridBindings();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //passing article in the constructor to enter edit mode
            ModifyForm modifyForm = new ModifyForm(this.accessLayer, this.SelectedArticle);
            modifyForm.ShowDialog();

            RefreshDataGridBindings();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this article?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //making sure the user wants to delte the article and its not just a missclick
            if (dialogResult == DialogResult.No)
                return;

            this.accessLayer.Delete(this.SelectedArticle);

            RefreshDataGridBindings();
        }

        private void ChangeDeleteEditButtonsStatus(bool enabled)
        {
            BtnEdit.Enabled = enabled;
            BtnDelete.Enabled = enabled;
            //context menu edit/delete buttons
            contextMenuStrip.Items[1].Enabled = enabled;
            contextMenuStrip.Items[2].Enabled = enabled;
        }

        private void RefreshDataGridBindings()
        {
            //recreating the bindings is easier than clearing, reffiling and refreshing the data grid
            DGArticles.DataSource = new BindingSource(new BindingList<Article>(this.accessLayer.Get()), null);
        }
    }
}
