using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int StylistId { get; set; }

        public Client(string name, string gender, int id = 0, int stylistId = 0)
        {
            Name = name;
            Gender = gender;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client)otherClient;
                bool nameEquality = (this.Name == newClient.Name);
                bool genderEquality = (this.Gender == newClient.Gender);
                bool stylistIdEquality = (this.StylistId == newClient.StylistId);
                return (nameEquality && genderEquality && stylistIdEquality);
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>() { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string gender = rdr.GetString(2);
                int stylistId = rdr.GetInt32(3);
                Client newClient = new Client(name, gender, id, stylistId);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"DELETE FROM clients;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (name, gender, stylist_id) VALUES (@Name, @Gender, @StylistId);";
            cmd.Parameters.AddWithValue("@Name", this.Name);
            cmd.Parameters.AddWithValue("@StylistId", this.StylistId);
            cmd.Parameters.AddWithValue("@Gender", this.Gender);

            cmd.ExecuteNonQuery();
            this.Id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        
        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = @searchId;";
            cmd.Parameters.AddWithValue("@searchId", id);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int clientId = 0;
            string name = "";
            string gender = "";
            int stylistId = 0;

            while (rdr.Read())
            {
                 clientId = rdr.GetInt32(0);
                 name = rdr.GetString(1);
                 gender = rdr.GetString(2);
                 stylistId = rdr.GetInt32(3);
            }

            Client foundClient = new Client(name, gender, clientId, stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundClient;
        }

    }
}