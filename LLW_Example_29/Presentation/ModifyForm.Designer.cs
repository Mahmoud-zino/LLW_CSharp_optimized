
namespace Presentation
{
    partial class ModifyForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbId = new System.Windows.Forms.TextBox();
            this.TbTitle = new System.Windows.Forms.TextBox();
            this.TbDesc = new System.Windows.Forms.TextBox();
            this.TbPrice = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Price:";
            // 
            // TbId
            // 
            this.TbId.Location = new System.Drawing.Point(114, 13);
            this.TbId.Name = "TbId";
            this.TbId.Size = new System.Drawing.Size(353, 27);
            this.TbId.TabIndex = 4;
            this.TbId.TextChanged += new System.EventHandler(this.Tb_TextChanged);
            // 
            // TbTitle
            // 
            this.TbTitle.Location = new System.Drawing.Point(114, 46);
            this.TbTitle.Name = "TbTitle";
            this.TbTitle.Size = new System.Drawing.Size(353, 27);
            this.TbTitle.TabIndex = 5;
            this.TbTitle.TextChanged += new System.EventHandler(this.Tb_TextChanged);
            // 
            // TbDesc
            // 
            this.TbDesc.Location = new System.Drawing.Point(114, 79);
            this.TbDesc.Name = "TbDesc";
            this.TbDesc.Size = new System.Drawing.Size(353, 27);
            this.TbDesc.TabIndex = 6;
            this.TbDesc.TextChanged += new System.EventHandler(this.Tb_TextChanged);
            // 
            // TbPrice
            // 
            this.TbPrice.Location = new System.Drawing.Point(114, 112);
            this.TbPrice.Name = "TbPrice";
            this.TbPrice.Size = new System.Drawing.Size(353, 27);
            this.TbPrice.TabIndex = 7;
            this.TbPrice.TextChanged += new System.EventHandler(this.Tb_TextChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(300, 146);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(166, 29);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(114, 146);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(166, 29);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 185);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TbPrice);
            this.Controls.Add(this.TbDesc);
            this.Controls.Add(this.TbTitle);
            this.Controls.Add(this.TbId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(514, 232);
            this.MinimumSize = new System.Drawing.Size(514, 232);
            this.Name = "ModifyForm";
            this.Text = "ModifyForm";
            this.Load += new System.EventHandler(this.ModifyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbId;
        private System.Windows.Forms.TextBox TbTitle;
        private System.Windows.Forms.TextBox TbDesc;
        private System.Windows.Forms.TextBox TbPrice;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}