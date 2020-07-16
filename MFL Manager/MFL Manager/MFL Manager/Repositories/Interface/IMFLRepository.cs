using System;
using System.Collections.Generic;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.ApiResponses.Salary;

namespace MFL_Manager.Repositories.Interface
{
    public interface IMFLRepository
    {
        IEnumerable<Player> GetPlayersFromApi(Uri uri);

        IEnumerable<Franchise> GetFranchisesFromApi(Uri uri);

        IEnumerable<Salary> GetSalariesFromApi(Uri uri);

        IEnumerable<Salary> GetRostersFromApi(Uri uri);
    }
}
