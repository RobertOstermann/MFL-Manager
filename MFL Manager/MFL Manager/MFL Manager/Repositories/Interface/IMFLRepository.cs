using System;
using System.Collections.Generic;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.ApiResponses.Salary;
using MFL_Manager.Models.CustomResponeses;

namespace MFL_Manager.Repositories.Interface
{
    public interface IMFLRepository
    {
        IEnumerable<FranchiseDto> GetFranchiseDtosFromApiData(LeagueInformation leagueInformation);

        double GetSalaryCapFromApiData(LeagueInformation leagueInformation);

        IEnumerable<PlayerDto> GetPlayerDtosFromApiData(IEnumerable<Player> players, IEnumerable<Salary> salaries);

        IEnumerable<Player> GetPlayersFromApi(Uri uri);

        LeagueInformation GetLeagueInformationFromApi(Uri uri);

        IEnumerable<Salary> GetSalariesFromApi(Uri uri);

        IEnumerable<Salary> GetRostersFromApi(Uri uri);

        IEnumerable<PlayerDto> GetPlayersFromFile();

        IEnumerable<FranchiseDto> GetFranchisesFromFile();

        void SavePlayersToFile(IEnumerable<PlayerDto> players);

        void SaveFranchisesToFile(IEnumerable<FranchiseDto> franchises);
    }
}
