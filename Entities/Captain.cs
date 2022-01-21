using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubApp.Entities
{
    public class Captain : Player
    {
        public Captain()
        {
            IsCaptain = true;
        }
        public override string ToString() => base.ToString() + " (Team Captain)";
    }
}
