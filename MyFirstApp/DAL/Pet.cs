using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFirstApp.DAL
{
    public class Pet
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["connPet"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddPet(Models.Pet pet) {
            connection();
            SqlCommand cmd = new SqlCommand("SPAddPet", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", pet.Name);
            cmd.Parameters.AddWithValue("@age", pet.Age);
            cmd.Parameters.AddWithValue("@description", pet.Description);
            cmd.Parameters.AddWithValue("@email", pet.Email);
            cmd.Parameters.AddWithValue("@isAdopted", 0);

            con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Models.Pet> GetPets()
        {
            connection();
            List<Models.Pet> pets = new List<Models.Pet>();
            SqlCommand cmd = new SqlCommand("GetPet", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                pets.Add(
                    new Models.Pet
                    {
                        Name = Convert.ToString(dr["name"]),
                        Age = Convert.ToString(dr["age"]),
                        Description = Convert.ToString(dr["description"]),
                        Email = Convert.ToString(dr["email"]),
                        IsAdopted = Convert.ToBoolean(dr["isAdopted"])
                    }
                );
            }

            return pets;
        }
    }
}