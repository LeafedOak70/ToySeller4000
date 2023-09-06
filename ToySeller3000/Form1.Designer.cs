namespace ToySeller3000
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.login_button = new System.Windows.Forms.Button();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.addBox = new System.Windows.Forms.TextBox();
            this.addInv = new System.Windows.Forms.Button();
            this.removeInv = new System.Windows.Forms.Button();
            this.invResult = new System.Windows.Forms.Label();
            this.inv_table = new System.Windows.Forms.DataGridView();
            this.addNum = new System.Windows.Forms.NumericUpDown();
            this.tableLabel = new System.Windows.Forms.Label();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.productButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.history_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inv_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addNum)).BeginInit();
            this.SuspendLayout();
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(12, 428);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(94, 29);
            this.login_button.TabIndex = 0;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(12, 328);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(125, 27);
            this.userNameBox.TabIndex = 2;
            this.userNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordBox_KeyDown);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(12, 378);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(125, 27);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordBox_KeyDown);
            // 
            // addBox
            // 
            this.addBox.Enabled = false;
            this.addBox.Location = new System.Drawing.Point(190, 328);
            this.addBox.Name = "addBox";
            this.addBox.Size = new System.Drawing.Size(133, 27);
            this.addBox.TabIndex = 4;
            // 
            // addInv
            // 
            this.addInv.Enabled = false;
            this.addInv.Location = new System.Drawing.Point(190, 378);
            this.addInv.Name = "addInv";
            this.addInv.Size = new System.Drawing.Size(94, 29);
            this.addInv.TabIndex = 5;
            this.addInv.Text = "Add";
            this.addInv.UseVisualStyleBackColor = true;
            this.addInv.Click += new System.EventHandler(this.addInv_Click);
            // 
            // removeInv
            // 
            this.removeInv.Enabled = false;
            this.removeInv.Location = new System.Drawing.Point(290, 378);
            this.removeInv.Name = "removeInv";
            this.removeInv.Size = new System.Drawing.Size(94, 29);
            this.removeInv.TabIndex = 6;
            this.removeInv.Text = "Remove";
            this.removeInv.UseVisualStyleBackColor = true;
            this.removeInv.Click += new System.EventHandler(this.removeInv_Click);
            // 
            // invResult
            // 
            this.invResult.AutoSize = true;
            this.invResult.Location = new System.Drawing.Point(190, 428);
            this.invResult.Name = "invResult";
            this.invResult.Size = new System.Drawing.Size(0, 20);
            this.invResult.TabIndex = 7;
            // 
            // inv_table
            // 
            this.inv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inv_table.Location = new System.Drawing.Point(12, 47);
            this.inv_table.Name = "inv_table";
            this.inv_table.RowHeadersWidth = 51;
            this.inv_table.RowTemplate.Height = 29;
            this.inv_table.Size = new System.Drawing.Size(1026, 261);
            this.inv_table.TabIndex = 8;
            // 
            // addNum
            // 
            this.addNum.Location = new System.Drawing.Point(329, 328);
            this.addNum.Name = "addNum";
            this.addNum.Size = new System.Drawing.Size(55, 27);
            this.addNum.TabIndex = 9;
            // 
            // tableLabel
            // 
            this.tableLabel.AutoSize = true;
            this.tableLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tableLabel.Location = new System.Drawing.Point(12, 9);
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.Size = new System.Drawing.Size(0, 25);
            this.tableLabel.TabIndex = 10;
            // 
            // inventoryButton
            // 
            this.inventoryButton.Enabled = false;
            this.inventoryButton.Location = new System.Drawing.Point(12, 497);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(94, 29);
            this.inventoryButton.TabIndex = 12;
            this.inventoryButton.Text = "Inventory";
            this.inventoryButton.UseVisualStyleBackColor = true;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
            // 
            // productButton
            // 
            this.productButton.Enabled = false;
            this.productButton.Location = new System.Drawing.Point(112, 497);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(94, 29);
            this.productButton.TabIndex = 13;
            this.productButton.Text = "Products";
            this.productButton.UseVisualStyleBackColor = true;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Enabled = false;
            this.addProductButton.Location = new System.Drawing.Point(190, 428);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(133, 29);
            this.addProductButton.TabIndex = 14;
            this.addProductButton.Text = "New Product";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // history_button
            // 
            this.history_button.Enabled = false;
            this.history_button.Location = new System.Drawing.Point(212, 497);
            this.history_button.Name = "history_button";
            this.history_button.Size = new System.Drawing.Size(94, 29);
            this.history_button.TabIndex = 15;
            this.history_button.Text = "History";
            this.history_button.UseVisualStyleBackColor = true;
            this.history_button.Click += new System.EventHandler(this.history_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 570);
            this.Controls.Add(this.history_button);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.productButton);
            this.Controls.Add(this.inventoryButton);
            this.Controls.Add(this.tableLabel);
            this.Controls.Add(this.addNum);
            this.Controls.Add(this.inv_table);
            this.Controls.Add(this.invResult);
            this.Controls.Add(this.removeInv);
            this.Controls.Add(this.addInv);
            this.Controls.Add(this.addBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.login_button);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inv_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button login_button;
        private TextBox userNameBox;
        private TextBox passwordBox;
        private TextBox addBox;
        private Button addInv;
        private Button removeInv;
        private Label invResult;
        private DataGridView inv_table;
        private NumericUpDown addNum;
        private Label tableLabel;
        private Button inventoryButton;
        private Button productButton;
        private Button addProductButton;
        private Button history_button;
    }
}