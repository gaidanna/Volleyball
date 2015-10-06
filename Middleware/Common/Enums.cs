using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public enum TablesNames
    {
        Players ,
        Teams ,
        Games ,
        PlayerInGames ,
        PlayerInTeams ,
    }

    public enum Gender
    {
        Male ,
        Female ,
        NotSpecified
    }

    public enum PlayersInfo
    { 
        BestPlayer,
        YellowCard,
        RedCard
    }
}
