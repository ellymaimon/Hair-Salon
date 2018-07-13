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
        public string ImageName { get; set; }
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
            return (nameEquality);
        }
    }
}