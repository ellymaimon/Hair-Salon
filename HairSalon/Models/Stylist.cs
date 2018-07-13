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

        public Stylist (string name, int experience, string specialty, string phone, int id = 0)
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
    }
}