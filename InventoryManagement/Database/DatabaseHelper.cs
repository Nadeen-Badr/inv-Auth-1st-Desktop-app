using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace InventoryManagement.Database
{
    public class DatabaseHelper
    {
        private static string connectionString = "Server=WIN-K6SNPMUG74Q;Database=InventoryDB;Integrated Security=True;";
        public static void LogAudit(string actionType, int productId, string username, string oldValues, string newValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO AuditLogs (ActionType, ProductID, Username, OldValues, NewValues) VALUES (@action, @productId, @username, @oldValues, @newValues)", conn))
                {
                    cmd.Parameters.AddWithValue("@action", actionType);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@oldValues", oldValues ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@newValues", newValues ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static string GetUserRole(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Role FROM Users WHERE Username=@username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var role = cmd.ExecuteScalar()?.ToString();
                    return role ?? "Viewer"; // Default to Viewer if no role is found
                }
            }
        }

        // Hash password before storing it
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Register a new user
        public static void RegisterUser(string username, string password, string role)
        {
            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, PasswordHash, Role) VALUES (@username, @passwordHash, @role)", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@passwordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Validate login
        public static bool ValidateLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT PasswordHash FROM Users WHERE Username=@username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var storedHash = cmd.ExecuteScalar()?.ToString();

                    return storedHash != null && HashPassword(password) == storedHash;
                }
            }
        }

        // Add a new product
  public static void AddProduct(string productName, string category, string description, int quantity, decimal price, string supplier, string username)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName, ProductCategory, Description, QuantityInStock, Price, SupplierName) VALUES (@name, @category, @desc, @quantity, @price, @supplier); SELECT SCOPE_IDENTITY();", conn))
                {
                    cmd.Parameters.AddWithValue("@name", productName);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@supplier", supplier);

                    int productId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Log the creation
                    LogAudit("INSERT", productId, username, null, $"Name: {productName}, Category: {category}, Quantity: {quantity}, Price: {price}");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint violation
                {
                    throw new Exception("A product with this name already exists. Please choose a different name.");
                }
                else
                {
                    throw new Exception("An error occurred while adding the product.");
                }
            }
        }
    }
        // Get all products
        public static DataTable GetProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE IsDeleted = 0", conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }


        // Soft delete a product
        public static void SoftDeleteProduct(int productId, string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmdGetOld = new SqlCommand("SELECT ProductName FROM Products WHERE ProductID=@id", conn))
                {
                    cmdGetOld.Parameters.AddWithValue("@id", productId);
                    string oldValues = cmdGetOld.ExecuteScalar()?.ToString();

                    using (SqlCommand cmd = new SqlCommand("UPDATE Products SET IsDeleted = 1 WHERE ProductID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        cmd.ExecuteNonQuery();

                        LogAudit("DELETE", productId, username, oldValues, null);
                    }
                }
            }
        }
       // Update an existing product
     public static bool  UpdateProduct(int productId, string productName, string category, string description, int quantity, decimal price, string supplier, string username)
        {
            string oldValues = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmdGetOld = new SqlCommand("SELECT * FROM Products WHERE ProductID=@id", conn))
                {
                    cmdGetOld.Parameters.AddWithValue("@id", productId);
                    using (SqlDataReader reader = cmdGetOld.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            oldValues = $"Name: {reader["ProductName"]}, Category: {reader["ProductCategory"]}, Quantity: {reader["QuantityInStock"]}, Price: {reader["Price"]}";
                        }
                    }
                }

            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Products SET ProductName=@name, ProductCategory=@category, Description=@desc, QuantityInStock=@quantity, Price=@price, SupplierName=@supplier WHERE ProductID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.Parameters.AddWithValue("@name", productName);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@supplier", supplier);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Duplicate key error
                {
                    MessageBox.Show("A product with this name already exists.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    throw;
                }
            }
                    string newValues = $"Name: {productName}, Category: {category}, Quantity: {quantity}, Price: {price}";
                    LogAudit("UPDATE", productId, username, oldValues, newValues);
                    return true;
                }
         }
        
         public static DataTable GetFilteredProducts(string productName = "", string category = "", string stockStatus = "")
        {
            DataTable products = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetFilteredProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(productName) ? (object)DBNull.Value : productName);
                    cmd.Parameters.AddWithValue("@Category", string.IsNullOrEmpty(category) || category == "All" ? (object)DBNull.Value : category);
                    cmd.Parameters.AddWithValue("@StockStatus", string.IsNullOrEmpty(stockStatus) || stockStatus == "All" ? (object)DBNull.Value : stockStatus);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(products);
                    }
                }
            }
            return products;
        }
        public static List<string> GetDistinctCategories()
        {
            List<string> categories = new List<string>();
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT ProductCategory FROM Products WHERE IsDeleted = 0", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader.GetString(0));
                        }
                    }
                }
            }
            
            return categories;
        }

        public static DataTable GetAuditLogs()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT LogID, ActionType, ProductID, Username, ActionDate, OldValues, NewValues FROM AuditLogs ORDER BY ActionDate DESC", conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }


    }
}
