using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToySeller3000
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            prod_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public object prodTable
        {
            get { return prod_table.DataSource; }
            set { prod_table.DataSource = value; }
        }
        private void prod_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void submitProduct_Click(object sender, EventArgs e)
        {
            form1.addNewProduct(Int32.Parse(newIdBox.Text), newNameBox.Text, Int32.Parse(newPriceBox.Text));
        }
    }
}
