namespace ToySeller3000
{
    partial class Form2
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
            this.newIdBox = new System.Windows.Forms.TextBox();
            this.submitProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newNameBox = new System.Windows.Forms.TextBox();
            this.newPriceBox = new System.Windows.Forms.TextBox();
            this.prod_table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.prod_table)).BeginInit();
            this.SuspendLayout();
            // 
            // newIdBox
            // 
            this.newIdBox.Location = new System.Drawing.Point(66, 50);
            this.newIdBox.Name = "newIdBox";
            this.newIdBox.Size = new System.Drawing.Size(125, 27);
            this.newIdBox.TabIndex = 0;
            // 
            // submitProduct
            // 
            this.submitProduct.Location = new System.Drawing.Point(66, 199);
            this.submitProduct.Name = "submitProduct";
            this.submitProduct.Size = new System.Drawing.Size(94, 29);
            this.submitProduct.TabIndex = 1;
            this.submitProduct.Text = "Submit";
            this.submitProduct.UseVisualStyleBackColor = true;
            this.submitProduct.Click += new System.EventHandler(this.submitProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Add New product";
            // 
            // newNameBox
            // 
            this.newNameBox.Location = new System.Drawing.Point(66, 97);
            this.newNameBox.Name = "newNameBox";
            this.newNameBox.Size = new System.Drawing.Size(125, 27);
            this.newNameBox.TabIndex = 6;
            // 
            // newPriceBox
            // 
            this.newPriceBox.Location = new System.Drawing.Point(66, 147);
            this.newPriceBox.Name = "newPriceBox";
            this.newPriceBox.Size = new System.Drawing.Size(125, 27);
            this.newPriceBox.TabIndex = 7;
            // 
            // prod_table
            // 
            this.prod_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prod_table.Location = new System.Drawing.Point(242, 50);
            this.prod_table.Name = "prod_table";
            this.prod_table.RowHeadersWidth = 51;
            this.prod_table.RowTemplate.Height = 29;
            this.prod_table.Size = new System.Drawing.Size(599, 305);
            this.prod_table.TabIndex = 8;
            this.prod_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prod_table_CellContentClick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 402);
            this.Controls.Add(this.prod_table);
            this.Controls.Add(this.newPriceBox);
            this.Controls.Add(this.newNameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitProduct);
            this.Controls.Add(this.newIdBox);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.prod_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox newIdBox;
        private Button submitProduct;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox newNameBox;
        private TextBox newPriceBox;
        private DataGridView prod_table;
    }
}