using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Data;

namespace ToySeller3000
{
    
    public partial class Form1 : Form
    {
        
        private DataTable table;
        private DataTable table2;//This table is Add Product table
        private MongoClient dbClient;
        private IMongoDatabase database;
        private IMongoCollection<DbStructureLogins> logins;
        private IMongoCollection<DbStructureInventory> inventory_database;
        private IMongoCollection<DbStructureProducts> products_database;
        private IMongoCollection<DbStructureProfit> history_database;
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(this);
            inv_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEmpty("login"))
                {
                    login_button.PerformClick();
                }
            }
        }
        //This just makes sure boxes aren't left empty when you submit info for login and adding to inventory
        private bool checkEmpty(string currEvent)
        {
            if(currEvent == "login")
            {
                if(passwordBox.Text == "" || userNameBox.Text == "")
                {
                    MessageBox.Show("Don't leave username or password empty");
                    return false;
                }
            }
            if(currEvent == "addInv")
            {
                if(addBox.Text == "")
                {
                    MessageBox.Show("Don't leave things empty");
                    return false;
                }
            }

            //not empty
            return true;
        }
        //login button
        private void button1_Click(object sender, EventArgs e)
        {
            string username = userNameBox.Text;
            string password = passwordBox.Text;

            ConnectToDatabase();
            var filter = Builders<DbStructureLogins>.Filter.Eq("Username", username);
            var login_result = logins.Find(filter).FirstOrDefault();
            //Sift through the login table to find matching credentials
            if(login_result != null)
            {
                if (login_result.Username == username && login_result.Password == password)
                {
                    //login found enable everything else
                    addProductButton.Enabled = true;
                    addBox.Enabled = true;
                    addInv.Enabled = true;
                    removeInv.Enabled = true;
                    inventoryButton.Enabled = true;
                    productButton.Enabled = true;
                    history_button.Enabled = true;
                    //Fill table with inventory
                    Fill_Inventory();
                }
            }
            else
            {
                MessageBox.Show("Login either not found or there was an error");
            }
        }
        private void ConnectToDatabase()
        {
            dbClient = new MongoClient("mongodb://localhost:27017");
            database = dbClient.GetDatabase("ToysRUs");
            logins = database.GetCollection<DbStructureLogins>("login_credentials");
            inventory_database = database.GetCollection<DbStructureInventory>("inventory");
            products_database = database.GetCollection<DbStructureProducts>("products");
            history_database = database.GetCollection<DbStructureProfit>("transaction_history");
        }
        //This will either fill the inventory for the first time or reset it when changed are made
        private void Fill_Inventory()
        {
            tableLabel.Text = "Inventory";
            createInventoryTable();
            var filter = new BsonDocument();
            var inv_result = inventory_database.Find(filter).ToList();
            foreach (var inv_var in inv_result)
            {
                int inv_id = inv_var.ProductId;
                string inv_name = inv_var.ProductName;
                int inv_price = inv_var.ProductPrice;
                int inv_quantity = inv_var.Quantity;
                table.Rows.Add(inv_id, inv_name, inv_price, inv_quantity);
            }
        }
        private void Fill_Product()
        {
            tableLabel.Text = "Products on Sale";
            createProductTable();
            var filter = new BsonDocument();
            var prod_result = products_database.Find(filter).ToList();
            foreach (var prod_var in prod_result)
            {
                int inv_id = prod_var.ProductId;
                string inv_name = prod_var.ProductName;
                int inv_price = prod_var.ProductPrice;
                table.Rows.Add(inv_id, inv_name, inv_price);
            }
        }
        private void Fill_History()
        {
            tableLabel.Text = "Transactions";
            createHistoryTable();
            var filter = new BsonDocument();
            var history_result = history_database.Find(filter).ToList();
            foreach(var hist_var in history_result)
            {
                int id = hist_var.ProductId;
                string name = hist_var.ProductName;
                int price = hist_var.ProductPrice;
                int total_sold = hist_var.total_sold;
                int total_price = hist_var.total_price;
                DateTime date = hist_var.soldDate;
                bool sold = hist_var.sellBool;
                table.Rows.Add(id, name, price, total_sold, total_price, date, sold);
            }


        }
        private void createHistoryTable()
        {
            table = new DataTable();
            inv_table.DataSource = table;
            table.Columns.Add("Id");
            table.Columns.Add("Name");
            table.Columns.Add("Price");
            table.Columns.Add("Total Sold");
            table.Columns.Add("Total Price");
            table.Columns.Add("Date");
            table.Columns.Add("Sold");
        }
        private void createProductTable()
        {
            table = new DataTable();
            inv_table.DataSource = table;
            table.Columns.Add("Id");
            table.Columns.Add("Name");
            table.Columns.Add("Price");
        }
        private void createInventoryTable()
        {
            table = new DataTable();
            inv_table.DataSource = table;
            table.Columns.Add("Id");
            table.Columns.Add("Name");
            table.Columns.Add("Price");
            table.Columns.Add("Quantity");
        }
        private void addHistory(DbStructureProducts item, int total_sold, bool soldBool)
        {
            DateTime date = DateTime.Now;
            var hist_item = new DbStructureProfit
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                ProductPrice = item.ProductPrice,
                total_sold = total_sold,
                total_price = total_sold * item.ProductPrice,
                soldDate = date,
                sellBool = soldBool
            };
            history_database.InsertOne(hist_item);
        }
        private void addInv_Click(object sender, EventArgs e)
        {
            if (checkEmpty("addInv") == false)
            {
                return;
            }
            var filter_prod = Builders<DbStructureProducts>.Filter.Eq("ProductId", addBox.Text);
            var filter_inv = Builders<DbStructureInventory>.Filter.Eq("ProductId", addBox.Text);
            var product = products_database.Find(filter_prod).FirstOrDefault();
            
            //Find matching id from Products
            if (product != null)
            {
                //Check if it is already in the inventory
                var product_inv = inventory_database.Find(filter_inv).FirstOrDefault();
                if(product_inv != null)
                {
                    //if it exists just ++ to quantity and update
                    int currentQuantity = product_inv.Quantity + Int32.Parse(addNum.Text);
                    var update = Builders<DbStructureInventory>.Update.Set("Quantity", currentQuantity);
                    inventory_database.UpdateOne(filter_inv, update);
                    //record in history
                    addHistory(product, Int32.Parse(addNum.Text), false);
                }
                else
                {
                    //if it doesn't exist in the inventory create new field 
                    var newInvItem = new DbStructureInventory {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        Quantity = Int32.Parse(addNum.Text)
                    };
                    inventory_database.InsertOne(newInvItem);
                    //record to history
                    addHistory(newInvItem, Int32.Parse(addNum.Text), false);
                } 
            }
            else
            {
                MessageBox.Show("Found no Id match");
            }
            //Reset Inventory
            Fill_Inventory();
        }

        private void removeInv_Click(object sender, EventArgs e)
        {
            if (checkEmpty("addInv") == false)
            {
                return;
            }
            var filter_inv = Builders<DbStructureInventory>.Filter.Eq("ProductId", addBox.Text);
            var inv_item = inventory_database.Find(filter_inv).FirstOrDefault();
            if(inv_item != null)
            {
                //If exists within inventory remove quantity if it goes to 0 completely remove from table
                int currentQuantity = inv_item.Quantity - Int32.Parse(addNum.Text);
                if(currentQuantity > 0)
                {
                    var update = Builders<DbStructureInventory>.Update.Set("Quantity", currentQuantity);
                    inventory_database.UpdateOne(filter_inv, update);
                    addHistory(inv_item, Int32.Parse(addNum.Text), true);
                }
                else
                {
                    inventory_database.DeleteOne(filter_inv);
                    addHistory(inv_item, inv_item.Quantity, true);
                }

            }
            else
            {
                MessageBox.Show("Item does not exist within Inventory");
            }
            //Reset Inventory
            Fill_Inventory();
        }
        
        private void history_button_Click(object sender, EventArgs e)
        {
            Fill_History();
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            Fill_Inventory();
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            Fill_Product();
        }
        private void createForm2Table()
        {
            table2 = new DataTable();
            form2.prodTable = table2;
            table2.Columns.Add("Id");
            table2.Columns.Add("Name");
            table2.Columns.Add("Price");
            table2.Columns.Add("Quantity");


            var filter = new BsonDocument();
            var prod_result = products_database.Find(filter).ToList();
            foreach (var prod_var in prod_result)
            {
                int inv_id = prod_var.ProductId;
                string inv_name = prod_var.ProductName;
                int inv_price = prod_var.ProductPrice;
                table2.Rows.Add(inv_id, inv_name, inv_price);
            }
        }
        private void addProductButton_Click(object sender, EventArgs e)
        {        
            createForm2Table();
            //open form 2
            form2.ShowDialog();
        }
        //This function will get id, name and price from form 2
        //and add a new product to the database of products
        public void addNewProduct(int id, string name, int price)
        {
            var filter_prod = Builders<DbStructureProducts>.Filter.Eq("ProductId", id);
            var product = products_database.Find(filter_prod).FirstOrDefault();
            //Find matching id from Products
            if (product == null)
            {
                var newProduct = new DbStructureProducts
                {
                    ProductId = id,
                    ProductName = name,
                    ProductPrice = price,
                };
                products_database.InsertOne(newProduct);
            }
            else
            {
                MessageBox.Show("Id matches with existing product");
            }
                createForm2Table();    
        }

        
    }
    public class DbStructureInventory : DbStructureProducts
    {
        [BsonElement("quantity")]
        public int Quantity { get; set; }
 
    }

    public class DbStructureLogins
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("userid")]
        public int UserId { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
    }
    public class DbStructureProducts
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("id")]
        public int ProductId { get; set; }
        [BsonElement("product_name")]
        public string ProductName { get; set; }
        [BsonElement("product_price")]
        public int ProductPrice { get; set; }
        
    }


    public class DbStructureProfit : DbStructureProducts
    {
       

        [BsonElement("total_sold")]

        public int total_sold { get; set; }

        [BsonElement("total_price")]
        public int total_price { get; set; }

        [BsonElement("date")]

        public DateTime soldDate { get; set; }

        [BsonElement("sellBool")]

        public bool sellBool { get; set; }

    }
}