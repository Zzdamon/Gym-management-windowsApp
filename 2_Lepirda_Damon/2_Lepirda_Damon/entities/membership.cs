using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Lepirda_Damon.entities
{
    [Serializable]
    public class Membership : IComparable<Membership>
    {
        private string _name;
        private string _type;
        private double _price;

        public Membership(string name, string type,double price)
        {
            _name = name;
            _type = type;
            _price = Price;
        }

        public Membership()
        {

        }

        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public double Price { get => _price; set => _price = value; }

        public int CompareTo(Membership other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
