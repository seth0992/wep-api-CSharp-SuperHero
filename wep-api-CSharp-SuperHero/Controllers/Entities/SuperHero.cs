﻿namespace wep_api_CSharp_SuperHero.Controllers.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
       
    }
}
