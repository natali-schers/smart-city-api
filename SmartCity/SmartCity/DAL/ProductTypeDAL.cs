using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SmartCity.Models;

public class ProductTypeDAL
{
    private readonly string _connectionString = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build().GetConnectionString("SmartCity");

    public IList<ProductType> GetAll()
    {
        IList<ProductType> productTypes = new List<ProductType>();

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM ProductType WITH(NOLOCK);";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductType type = new ProductType();
                    type.Id = Convert.ToInt32(reader["Id"]);
                    type.Description = reader["Description"].ToString() ?? "";
                    type.IsCommercialized = Convert.ToBoolean(reader["IsCommercialized"]);

                    productTypes.Add(type);
                }

                connection.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }

        return productTypes;
    }

    public ProductType GetById(int id)
    {
        ProductType productType = new ProductType();

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * 
                                     FROM ProductType WITH(NOLOCK)
                                     WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productType.Id = Convert.ToInt32(reader["Id"]);
                    productType.Description = reader["Description"].ToString() ?? "";
                    productType.IsCommercialized = Convert.ToBoolean(reader["IsCommercialized"]);
                }

                connection.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }

        return productType;
    }

    public ProductType Create(ProductType productType)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO ProductType ([Description], IsCommercialized)
                    VALUES (@Description, @IsCommercialized);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Description", productType.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("IsCommercialized", productType.IsCommercialized);

                connection.Open();

                productType.Id = (int)command.ExecuteScalar();

                connection.Close();

                return productType;

            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(int id, ProductType productType)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE ProductType
                    SET [Description] = @Description,
                        IsCommercialized = @IsCommercialized
                    WHERE Id = @Id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("Description", productType.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("IsCommercialized", productType.IsCommercialized);

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
                string query = @"DELETE FROM ProductType WHERE Id = @Id;";

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
