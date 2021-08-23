using DataAccessLayer;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public partial class ModifyForm : Form
    {
        private enum Mode
        {
            Add,
            Edit
        }

        private readonly AccessLayer accessLayer;
        private readonly Article article;
        private readonly Mode mode;

        public ModifyForm(AccessLayer accessLayer, Article article = null)
        {
            InitializeComponent();

            this.accessLayer = accessLayer;

            //add mode
            if (article is null)
            {
                this.mode = Mode.Add;
                this.article = new();
            }
            //edit mode
            else
            {
                this.mode = Mode.Edit;
                //cloning the article so no changes takes effect when the cancel button is clicked
                this.article = article.Clone() as Article;
            }
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
            //change title of the window depending on the mode
            Text = mode == Mode.Add ? "Add Article" : "Edit Article";

            if (mode == Mode.Edit)
            {
                //user cant change the id in edit mode
                TbId.ReadOnly = true;

                TbId.Text = this.article.Id.ToString();
                TbTitle.Text = this.article.Title;
                TbDesc.Text = this.article.Description;
                TbPrice.Text = this.article.Price.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.article.Title = TbTitle.Text;
                this.article.Description = TbDesc.Text;

                if (mode == Mode.Add)
                {
                    //convert id only in add mode
                    this.article.Id = TbId.Text.ConvertStringIdToInt();
                    //converting price here so the id is checked first and then the price
                    this.article.Price = TbPrice.Text.ConvertStringPriceToDouble();
                    this.accessLayer.Add(this.article);
                }
                else
                {
                    this.article.Price = TbPrice.Text.ConvertStringPriceToDouble();
                    this.accessLayer.Update(this.article);
                }
            }
            //catching user input errors
            catch (InvalidIdException)
            {
                errorProvider.SetError(TbId, "Invalid Id!, please enter a valid Id");
                TbId.BackColor = Color.PaleVioletRed;
                return;
            }
            catch (DuplicateIdException)
            {
                errorProvider.SetError(TbId, "Duplicate Id!, please enter a different Id");
                TbId.BackColor = Color.PaleVioletRed;
                return;
            }
            catch (EmptyIdException)
            {
                errorProvider.SetError(TbId, "Empty Id!, please enter an Id");
                TbId.BackColor = Color.PaleVioletRed;
                return;
            }
            catch (EmptyTitleException)
            {
                errorProvider.SetError(TbTitle, "Empty Title!, please enter a Title");
                TbTitle.BackColor = Color.PaleVioletRed;
                return;
            }
            catch (EmptyDescriptionException)
            {
                errorProvider.SetError(TbDesc, "Empty Description!, please enter a Description");
                TbDesc.BackColor = Color.PaleVioletRed;
                return;
            }
            catch (EmptyPriceException)
            {
                errorProvider.SetError(TbPrice, "Empty Price!, please enter a Price");
                TbPrice.BackColor = Color.PaleVioletRed;
                return;
            }
            catch (InvalidPriceException)
            {
                errorProvider.SetError(TbPrice, "Invalid Price!, please enter a valid Price");
                TbPrice.BackColor = Color.PaleVioletRed;
                return;
            }
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            //clearing the error by sending an empty string to the error provider
            errorProvider.SetError(tb, "");

            if (!tb.ReadOnly)
                tb.BackColor = Color.White;
        }
    }
}
