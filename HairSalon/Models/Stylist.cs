using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }

        public Stylist(string name, int experience, string specialty, string phone, int id = 0)
        {
            Name = name;
            Experience = experience;
            Specialty = specialty;
            Phone = phone;
            Id = id;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist)otherStylist;
                bool nameEquality = (this.Name == newStylist.Name);
                bool experienceEquality = (this.Experience == newStylist.Experience);
                bool specialtyEquality = (this.Specialty == newStylist.Specialty);
                bool phoneEquality = (this.Phone == newStylist.Phone);
                return (nameEquality && experienceEquality && specialtyEquality && phoneEquality);
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist>() { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int experience = rdr.GetInt32(2);
                string specialty = rdr.GetString(3);
                string phone = rdr.GetString(4);
                Stylist newStylist = new Stylist(name, experience, specialty, phone, id);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();

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
            cmd.CommandText = @"INSERT INTO stylists (name, experience, specialty, phone) VALUES (@Name, @Experience, @Specialty, @Phone);";
            cmd.Parameters.AddWithValue("@Name", this.Name);
            cmd.Parameters.AddWithValue("@Experience", this.Experience);
            cmd.Parameters.AddWithValue("@Specialty", this.Specialty);
            cmd.Parameters.AddWithValue("@Phone", this.Phone);
            cmd.ExecuteNonQuery();
            this.Id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}