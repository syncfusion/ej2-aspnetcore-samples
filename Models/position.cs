using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class Position
    {
        public string Value { get; set; }
        public List<Position> Positions()
        {
            List<Position> position = new List<Position>();
            position.Add(new Position { Value = "Top Left" });
            position.Add(new Position { Value = "Top Right" });
            position.Add(new Position { Value = "Top Center" });
            position.Add(new Position { Value = "Top Full Width" });
            position.Add(new Position { Value = "Bottom Left" });
            position.Add(new Position { Value = "Bottom Right" });
            position.Add(new Position { Value = "Bottom Center" });
            position.Add(new Position { Value = "Bottom Full Width" });
            return position;
        }
    }

}
