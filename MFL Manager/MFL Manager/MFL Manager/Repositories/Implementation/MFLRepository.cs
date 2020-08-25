using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.ApiResponses.Players.Player_Profile;
using MFL_Manager.Models.ApiResponses.Roster;
using MFL_Manager.Models.ApiResponses.Salary;
using MFL_Manager.Models.CustomResponeses;
using MFL_Manager.Repositories.Interface;
using Newtonsoft.Json;

namespace MFL_Manager.Repositories.Implementation
{
    public class MFLRepository : IMFLRepository
    {
        private readonly IRestApiRepository _restApiRepository;

        private readonly IFileRepository _fileRepository;

        public MFLRepository(IRestApiRepository restApiRepository, IFileRepository fileRepository)
        {
            _restApiRepository = restApiRepository;
            _fileRepository = fileRepository;
        }

        public IEnumerable<FranchiseDto> GetFranchiseDtosFromApiData(LeagueInformation leagueInformation)
        {
            List<FranchiseDto> franchiseDtos = new List<FranchiseDto>();

            var franchiseInformation = leagueInformation.FranchiseInformation.Teams.Select(f => new FranchiseDto()
            {
                Name = f.TeamName,
                DivisionId = Convert.ToInt32(f.Division),
                Id = Convert.ToInt32(f.TeamId)
            }).ToList();

            franchiseDtos.AddRange(franchiseInformation);

            foreach (var franchise in franchiseDtos)
            {
                foreach (var division in leagueInformation.DivisionInformation.Division.Where(division => franchise.DivisionId == Convert.ToInt32(division.DivisionId)))
                {
                    franchise.Division = division.DivisionName;
                }
            }

            return franchiseDtos;
        }

        public IEnumerable<PlayerDto> GetPlayerDtosFromApiData(IEnumerable<Player> players, IEnumerable<Salary> salaries, IEnumerable<PlayerProfile> playerProfiles)
        {
            List<PlayerDto> playerDtos = new List<PlayerDto>();

            var playerInformation = players.Select(p => new PlayerDto()
            {
                Name = p.PlayerName,
                NFLTeam = p.NFLTeam,
                Id = Convert.ToInt32(p.PlayerId),
                Position = GetPlayerPosition(p.Position)
            }).Where(p => p.Position != "Invalid").ToList();

            playerDtos.AddRange(playerInformation);

            salaries = salaries.ToList();

            foreach (var player in playerDtos)
            {
                foreach (var salary in salaries)
                {
                    if (player.Id == Convert.ToInt32(salary.PlayerId))
                    {
                        player.Salary = Convert.ToDouble(salary.PlayerSalary);
                        player.ContractYear = salary.ContractYear;
                    }
                }
            }

            playerProfiles = playerProfiles.ToList();

            foreach (var player in playerDtos)
            {
                foreach (var playerProfile in playerProfiles)
                {
                    if (player.Id == Convert.ToInt32(playerProfile.PlayerId))
                    {
                        player.ADP = playerProfile.Player.ADP;
                        player.Age = Convert.ToInt32(playerProfile.Player.Age);
                        player.Height = playerProfile.Player.Height;
                        player.Weight = playerProfile.Player.Weight;
                    }
                }
            }

            return playerDtos;
        }

        public IEnumerable<DivisionDto> GetDivisionDtosFromApiData(IEnumerable<Division> divisions)
        {
            List<DivisionDto> divisionDtos = new List<DivisionDto>();

            var divisionInformation = divisions.Select(d => new DivisionDto()
            {
                Name = d.DivisionName,
                Id = Convert.ToInt32(d.DivisionId)
            });

            divisionDtos.AddRange(divisionInformation);

            return divisionDtos;
        }

        public double GetSalaryCapFromApiData(LeagueInformation leagueInformation)
        {
            double salaryCap = 125.00;
            try
            {
                salaryCap = Convert.ToDouble(leagueInformation.SalaryCap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return salaryCap;
        }

        #region Api Requests

        public LeagueInformation GetLeagueInformationFromApi(Uri uri)
        {
            if (uri == null)
                throw new ArgumentException("Player request null in MFL Repository");

            var response = _restApiRepository.GetRequest(uri);

            if (string.IsNullOrWhiteSpace(response))
                throw new ArgumentException("League Request response returned null");

            var data = JsonConvert.DeserializeObject<LeagueRequest>(response);

            LeagueInformation leagueInformation = data.LeagueInformation;

            return leagueInformation;
        }

        public IEnumerable<Player> GetPlayersFromApi(Uri uri)
        {
            if (uri == null)
                throw new ArgumentException("Player request null in MFL Repository");

            var response = _restApiRepository.GetRequest(uri);

            if (string.IsNullOrWhiteSpace(response))
                return new List<Player>();

            var data = JsonConvert.DeserializeObject<PlayerRequest>(response);

            IEnumerable<Player> players = data.PlayerInformation.Players;

            return players;
        }

        public IEnumerable<PlayerProfile> GetPlayerProfilesFromApi(Uri uri, IEnumerable<string> playerIds)
        {
            if (uri == null)
                throw new ArgumentException("Player Profile request null in MFL Repository");

            string playerIdString = string.Join(",", playerIds);

            Uri playerProfileUri = new Uri($"{uri}&P={playerIdString}&JSON=1");

            var response = _restApiRepository.GetRequest(playerProfileUri);

            if (string.IsNullOrWhiteSpace(response))
                return new List<PlayerProfile>();

            var data = JsonConvert.DeserializeObject<PlayerProfileRequest>(response);

            IEnumerable<PlayerProfile> playerProfiles = data.PlayerProfileObject.PlayerProfiles;

            return playerProfiles;
        }

        public IEnumerable<Salary> GetSalariesFromApi(Uri uri)
        {
            if (uri == null)
                throw new ArgumentException("Player request null in MFL Repository");

            var response = _restApiRepository.GetRequest(uri);

            if (string.IsNullOrWhiteSpace(response))
                return new List<Salary>();

            var data = JsonConvert.DeserializeObject<SalaryRequest>(response);

            IEnumerable<Salary> salaries = data.League.SalaryInformation.PlayerSalaries;

            return salaries;
        }

        public IEnumerable<RosterFranchise> GetRostersFromApi(Uri uri)
        {
            if (uri == null)
                throw new ArgumentException("Player request null in MFL Repository");

            var response = _restApiRepository.GetRequest(uri);

            if (string.IsNullOrWhiteSpace(response))
                return null;

            var data = JsonConvert.DeserializeObject<RosterRequest>(response);

            IEnumerable<RosterFranchise> rosters = data.Roster.Franchise;

            return rosters;
        }

        #endregion

        #region Local Requests

        public IEnumerable<PlayerDto> GetPlayersFromFile()
        {
            return _fileRepository.LoadPlayerInformation();
        }

        public IEnumerable<FranchiseDto> GetFranchisesFromFile()
        {
            return _fileRepository.LoadFranchiseInformation();
        }

        public IEnumerable<DivisionDto> GetDivisionsFromFile()
        {
            return _fileRepository.LoaDivisionInformation();
        }

        public void SavePlayersToFile(IEnumerable<PlayerDto> players)
        {
            _fileRepository.SavePlayerInformation(players);
        }

        public void SaveFranchisesToFile(IEnumerable<FranchiseDto> franchises)
        {
            _fileRepository.SaveFranchiseInformation(franchises);
        }

        public void SaveDivisionsToFile(IEnumerable<DivisionDto> divisions)
        {
            _fileRepository.SaveDivisionInformation(divisions);
        }

        #endregion

        private string GetPlayerPosition(string position)
        {
            switch (position)
            {
                case "QB":
                    return "Quarterback";
                case "RB":
                    return "Running Back";
                case "WR":
                    return "Wide Receiver";
                case "TE":
                    return "Tight End";
                case "PK":
                    return "Kicker";
                case "Def":
                    return "Defense";
                default:
                    return "Invalid";
            }
        }
    }
}
