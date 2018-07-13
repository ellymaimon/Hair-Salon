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
        public string ImageName { get; set; }
        public int StylistId { get; set; }
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
            return (nameEquality);
        }
    }
}