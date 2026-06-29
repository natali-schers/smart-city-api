using Microsoft.Data.SqlClient;
using SmartCity.Models;

public class ProductTypeDAL
{
    private readonly string _connectionString = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build().GetConnectionString("SmartCity");

    public IList<GetProductTypeDto> GetAll()
    {
        IList<GetProductTypeDto> productTypes = new List<GetProductTypeDto>();

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
                    GetProductTypeDto type = new GetProductTypeDto();
                    type.Id = Convert.ToInt32(reader["Id"]);
                    type.Description = reader["Description"].ToString() ?? "";
                    type.IsCommercialized = reader["IsCommercialized"].Equals("1");

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

    public GetProductTypeDto GetById(int id)
    {
        GetProductTypeDto productType = new GetProductTypeDto();

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
                    productType.IsCommercialized = reader["IsCommercialized"].Equals("1");
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

        return productType;
    }

    public void Create(CreateProductTypeDto productType)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO ProductType ([Description], IsCommercialized) VALUES (@Description, @IsCommercialized);";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Description", productType.Description);
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

    public void Update(int id, UpdateProductTypeDto productType)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE ProductType SET [Description] = @Description, IsCommercialized = @IsCommercialized WHERE Id = @Id;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("Description", productType.Description);
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