using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Data;

namespace ToySeller3000
{
    
    public partial class Form1 : Form
    {
        private DataTable table;
        private MongoClient dbClient;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> logins;
        private IMongoCollection<DbStructureInventory> inventory_database;
        private IMongoCollection<DbStructureProducts> products_database;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = userNameBox.Text;
            string password = passwordBox.Text;

            ConnectToDatabase();
            
            var filter = new BsonDocument();
            var login_result = logins.Find(filter).ToList();
            var foundUser = 0;
            //Sift through the login table to find matching credentials
            foreach (var document in login_result)
            {
                if (document.GetValue("username").AsString == username && document.GetValue("password").AsString == password)
                {
                    //login found enable everything else
                    foundUser++;
                    addBox.Enabled = true;
                    addInv.Enabled = true;
                    removeInv.Enabled = true;
                    //Fill table with inventory
                    Fill_Inventory();
                    break;
                }
            }
            //if it's still 0 by the end, it was never found
            if(foundUser == 0)
            {
                MessageBox.Show("Login either not found or there was an error");
            }
            
     

        }
        private void ConnectToDatabase()
        {
            dbClient = new MongoClient("mongodb://localhost:27017");
            database = dbClient.GetDatabase("ToysRUs");
            logins = database.GetCollection<BsonDocument>("login_credentials");
            inventory_database = database.GetCollection<DbStructureInventory>("inventory");
            products_database = database.GetCollection<DbStructureProducts>("products");
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
        private void addInv_Click(object sender, EventArgs e)
        {
            var filter_prod = Builders<DbStructureProducts>.Filter.Eq("ProductId", addBox.Text);
            var filter_inv = Builders<DbStructureInventory>.Filter.Eq("ProductId", addBox.Text);
            var product = products_database.Find(filter_prod).FirstOrDefault();
            //Find matching id from Products
            if(product != null)
            {
                //Check if it is already in the inventory
                var product_inv = inventory_database.Find(filter_inv).FirstOrDefault();
                if(product_inv != null)
                {
                    //if it exists just ++ to quantity and update
                    int currentQuantity = product_inv.Quantity + Int32.Parse(addNum.Text);
                    var update = Builders<DbStructureInventory>.Update.Set("Quantity", currentQuantity);
                    inventory_database.UpdateOne(filter_inv, update);
                }
                else
                {
                    //if it doesn't exist in the inventory create new field 
                    var newInvItem = new DbStructureInventory {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        Quantity = 1
                    };
                    inventory_database.InsertOne(newInvItem);
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
            
            var filter_inv = Builders<DbStructureInventory>.Filter.Eq("ProductId", addBox.Text);
            var inv_item = inventory_database.Find(filter_inv).FirstOrDefault();
            if(inv_item != null)
            {
                //If exists within inventory remove quantity by 1 if it goes to 0 completely remove from table
                int currentQuantity = inv_item.Quantity - 1;
                if(currentQuantity > 0)
                {
                    var update = Builders<DbStructureInventory>.Update.Set("Quantity", currentQuantity);
                    inventory_database.UpdateOne(filter_inv, update);
                }
                else
                {
                    inventory_database.DeleteOne(filter_inv); 
                }

            }
            else
            {
                MessageBox.Show("Item does not exist within Inventory");
            }
            //Reset Inventory
            Fill_Inventory();
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            Fill_Inventory();
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            Fill_Product();
        }
    }
    public class DbStructureInventory
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("product_name")]
        public string ProductName { get; set; }
        [BsonElement("product_price")]
        public int ProductPrice { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("product_id")]
        public int ProductId { get; set; }
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
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        
    }
}