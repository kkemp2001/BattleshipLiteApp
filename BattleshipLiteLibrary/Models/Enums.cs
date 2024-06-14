using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
    public enum GridSpotStatus
    {
        // enum: 0 = empty, 1 = ship, 2 = miss, 3 = hit, 4 = sunk
        Empty,
        Ship, 
        Miss,
        Hit,
        Sunk,
    }
}
