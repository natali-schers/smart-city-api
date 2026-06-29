using System;
using Microsoft.Data.SqlClient;
using SmartCity.Models;

public class ProductDAL
{
    private readonly string _connectionString = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build().GetConnectionString("SmartCity");

    public IList<Product> GetAll()
    {
        IList<Product> products = new List<Product>();

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM Product WITH(NOLOCK);";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();

                    product.Id = Convert.ToInt32(reader["Id"]);
                    product.ProductName = reader["ProductName"].ToString() ?? "";
                    product.Characteristics = reader["Characteristics"].ToString() ?? "";
                    product.AveragePrice = Convert.ToDecimal(reader["AveragePrice"]);
                    product.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    product.LogoUrl = reader["LogoUrl"].ToString() ?? "";
                    product.ProductTypeId = Convert.ToInt32(reader["ProductTypeId"]);

                    products.Add(product);
                }

                connection.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }

        return products;
    }

    public Product GetById(int id)
    {
        Product product = new Product();

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * 
                                     FROM Product WITH(NOLOCK)
                                     WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product.Id = Convert.ToInt32(reader["Id"]);
                    product.ProductName = reader["ProductName"].ToString() ?? "";
                    product.Characteristics = reader["Characteristics"].ToString() ?? "";
                    product.AveragePrice = Convert.ToDecimal(reader["AveragePrice"]);
                    product.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    product.LogoUrl = reader["LogoUrl"].ToString() ?? ""; 
                    product.ProductTypeId = Convert.ToInt32(reader["ProductTypeId"]);
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

        return product;
    }

    public Product Create(Product product)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO Product (ProductName, Characteristics, AveragePrice, LogoUrl, IsActive, ProductTypeId)
                    VALUES (@ProductName, @Characteristics, @AveragePrice, @LogoUrl, @IsActive, @ProductTypeId);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("ProductName", product.ProductName ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("Characteristics", product.Characteristics ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("AveragePrice", product.AveragePrice.HasValue ? (object)product.AveragePrice.Value : DBNull.Value);
                command.Parameters.AddWithValue("LogoUrl", product.LogoUrl ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("IsActive", product.IsActive);
                command.Parameters.AddWithValue("ProductTypeId", product.ProductTypeId);

                connection.Open();

                product.Id = (int)command.ExecuteScalar();

                connection.Close();

                return product;

            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(int id, Product product)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE Product
                    SET ProductName = @ProductName,
                        Characteristics = @Characteristics,
                        AveragePrice = @AveragePrice,
                        LogoUrl = @LogoUrl,
                        IsActive = @IsActive,
                        ProductTypeId = @ProductTypeId
                    WHERE Id = @Id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("ProductName", product.ProductName ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("Characteristics", product.Characteristics ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("AveragePrice", product.AveragePrice.HasValue ? (object)product.AveragePrice.Value : DBNull.Value);
                command.Parameters.AddWithValue("LogoUrl", product.LogoUrl ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("IsActive", product.IsActive);
                command.Parameters.AddWithValue("ProductTypeId", product.ProductTypeId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"DELETE FROM Product WHERE Id = @Id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}