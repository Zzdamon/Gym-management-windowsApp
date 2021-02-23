using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Lepirda_Damon.entities
{
    [Serializable]
    public class Gym
    {
        private List<Membership> _memberships;

        public List<Membership> Memberships { get => _memberships; set => _memberships = value; }

        public Gym()
        {
            _memberships = new List<Membership>();
        }

        public Gym(List<Membership> memberships)
        {
            _memberships = memberships;
        }
    }
}
