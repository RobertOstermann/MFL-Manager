﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.ApiResponses.Salary;
using MFL_Manager.Models.CustomResponeses;
using MFL_Manager.Repositories.Interface;
using Newtonsoft.Json;

namespace MFL_Manager.Repositories.Implementation
{
    public class MFLRepository : IMFLRepository
    {
        private readonly IRestApiRepository _restApiRepository;
        public MFLRepository(IRestApiRepository restApiRepository)
        {
            _restApiRepository = restApiRepository;
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

        public IEnumerable<PlayerDto> GetPlayerDtosFromApiData(IEnumerable<Player> players, IEnumerable<Salary> salaries)
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

            return playerDtos;
        }

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

        #region Api Requests

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

        public IEnumerable<Salary> GetRostersFromApi(Uri uri)
        {
            if (uri == null)
                throw new ArgumentException("Player request null in MFL Repository");

            var response = _restApiRepository.GetRequest(uri);

            if (string.IsNullOrWhiteSpace(response))
                return null;

            throw new NotImplementedException();
        }

        #endregion
    }
}
