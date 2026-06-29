using System;
using Microsoft.Data.SqlClient;
using SmartCity.Models;

public class ProductDAL
{
    private readonly string _connectionString = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build().GetConnectionString("SmartCity");

    public IList<GetProductDto> GetAll()
    {
        IList<GetProductDto> products = new List<GetProductDto>();

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
                    GetProductDto product = new GetProductDto();

                    product.Id = Convert.ToInt32(reader["Id"]);
                    product.ProductName = reader["ProductName"].ToString() ?? "";
                    product.Characteristics = reader["Characteristics"].ToString() ?? "";
                    product.AveragePrice = Convert.ToDecimal(reader["AveragePrice"]);
                    product.IsActive = reader["IsActive"].Equals("1");
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

    public GetProductDto GetById(int id)
    {
        GetProductDto product = new GetProductDto();

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
                    product.IsActive = reader["IsActive"].Equals("1");
                    product.LogoUrl = reader["LogoUrl"].ToString() ?? "";
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

        return product;
    }

    public void Create(CreateProductDto product)
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
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(int id, UpdateProductDto product)
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