using System;
using System.Collections.Generic;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.ApiResponses.Players.Player_Profile;
using MFL_Manager.Models.ApiResponses.Salary;
using MFL_Manager.Models.CustomResponeses;

namespace MFL_Manager.Repositories.Interface
{
    public interface IMFLRepository
    {
        IEnumerable<FranchiseDto> GetFranchiseDtosFromApiData(LeagueInformation leagueInformation);

        IEnumerable<PlayerDto> GetPlayerDtosFromApiData(IEnumerable<Player> players, IEnumerable<Salary> salaries, IEnumerable<PlayerProfile> playerProfiles);

        IEnumerable<DivisionDto> GetDivisionDtosFromApiData(IEnumerable<Division> divisions);

        double GetSalaryCapFromApiData(LeagueInformation leagueInformation);

        LeagueInformation GetLeagueInformationFromApi(Uri uri);

        IEnumerable<Player> GetPlayersFromApi(Uri uri);

        IEnumerable<PlayerProfile> GetPlayerProfilesFromApi(Uri uri, IEnumerable<string> playerIds);

        IEnumerable<Salary> GetSalariesFromApi(Uri uri);

        IEnumerable<Salary> GetRostersFromApi(Uri uri);

        IEnumerable<PlayerDto> GetPlayersFromFile();

        IEnumerable<FranchiseDto> GetFranchisesFromFile();

        IEnumerable<DivisionDto> GetDivisionsFromFile();

        void SavePlayersToFile(IEnumerable<PlayerDto> players);

        void SaveFranchisesToFile(IEnumerable<FranchiseDto> franchises);

        void SaveDivisionsToFile(IEnumerable<DivisionDto> divisions);
    }
}
