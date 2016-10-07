namespace WebApplication2.Models.User
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class UserInfo
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string EmailAddress { get; set; }

        public List<Priviledge> Priviledges { get; set; }
    }
}