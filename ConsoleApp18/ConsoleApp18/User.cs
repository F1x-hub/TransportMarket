using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int Money { get; set; }
        public int TranportId { get; set; }
        public List<Transport> Transport { get; set; } = new List<Transport>();
        public List<Transport> SoldTranport { get; set; } = new List<Transport>();
        public List<Transport> FavoriteTransport { get; set; } = new List<Transport>();

        public override string ToString()
        {
            return base.ToString() + $"Name: {Name} - Email: {Email} - Password: {Password} - UserName: {UserName} - Money: {Money}";
        }
        
    }
}
