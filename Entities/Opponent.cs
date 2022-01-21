using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubApp.Entities
{
    public class Opponent : EntityBase
    {
        public string? TeamName { get; set; }
        public Competition Competition { get; set; }
        public override string ToString() => $"Id: {Id}, TeamName: {TeamName}, Competition: {Competition}";
    }
}

