﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.ApiResponses.Players.Player_Profile;
using MFL_Manager.Models.ApiResponses.Roster;
using MFL_Manager.Models.ApiResponses.Salary;
using MFL_Manager.Models.CustomResponeses;
using MFL_Manager.Repositories.Implementation;
using MFL_Manager.Repositories.Interface;

namespace MFL_Manager
{
    public class MFLController
    {
        public Manager Manager;

        private readonly IMFLRepository _mflRepository;
        private readonly PlayerDatabase _database;

        public MFLController(IMFLRepository mflRepository, PlayerDatabase database)
        {
            _mflRepository = mflRepository;
            _database = database;
        }

        #region Franchises

        public IEnumerable<FranchiseDto> GetFranchiseInformation()
        {
            return _database.Franchises.Values;
        }

        public FranchiseDto GetFranchiseInformation(int id)
        {
            return (from franchise in _database.Franchises where franchise.Key == id select franchise.Value).FirstOrDefault();
        }

        public IEnumerable<DivisionDto> GetDivisionInformation()
        {
            return _database.Divisions.Values;
        }

        public double GetCapInformation()
        {
            return _database.CapRoom;
        }

        public void SetCapInformation(double capRoom)
        {
            _database.CapRoom = capRoom;
        }

        #endregion

        #region Players

        public IEnumerable<PlayerDto> GetPlayerInformation()
        {
            return _database.Players.Values;
        }

        public void AddPlayer(PlayerDto player)
        {
            if (!_database.Players.ContainsKey(player.Id))
            {
                _database.Players.Add(player.Id, player);
            }
            MessageBox.Show($@"Player with Id {player.Id} already exists");
        }

        public void AddPlayerToTeam(PlayerDto player)
        {
            if (_database.Franchises.TryGetValue(player.MFLTeamID, out FranchiseDto franchise))
            {
                franchise.AddPlayer(player);
            }
        }

        public void RemovePlayer(PlayerDto player)
        {
            _database.Players.Remove(player.Id);
            RemovePlayerFromTeam(player);
        }

        public void RemovePlayerFromTeam(PlayerDto player)
        {
            if (_database.Franchises.TryGetValue(player.MFLTeamID, out FranchiseDto franchise))
            {
                franchise.RemovePlayer(player);
            }
        }

        #endregion

        #region Information Operations

        public void GetApiInformation(Uri playerUri, Uri franchiseUri, Uri salaryUri, Uri rosterUri, Uri playerProfileUri)
        {
            IEnumerable<Player> players = _mflRepository.GetPlayersFromApi(playerUri).ToList();
            IEnumerable<Salary> salaries = _mflRepository.GetSalariesFromApi(salaryUri);
            IEnumerable<RosterFranchise> rosters = _mflRepository.GetRostersFromApi(rosterUri);
            LeagueInformation leagueInformation = _mflRepository.GetLeagueInformationFromApi(franchiseUri);

            // Takes a long time to execute. 
            IEnumerable<PlayerProfile> playerProfiles = GetPlayerProfileApiInformation(playerProfileUri, players);

            List<PlayerDto> playerDtos = _mflRepository.GetPlayerDtosFromApiData(players, salaries, playerProfiles).ToList();
            List<FranchiseDto> franchiseDtos = _mflRepository.GetFranchiseDtosFromApiData(leagueInformation).ToList();
            List<DivisionDto> divisionDtos = _mflRepository.GetDivisionDtosFromApiData(leagueInformation.DivisionInformation.Division).ToList();

            foreach (var franchise in rosters)
            {
                foreach (var player in franchise.Players)
                {
                    PlayerDto playerDto = playerDtos.FirstOrDefault(p => p.Id == Convert.ToInt32(player.PlayerId));

                    if (playerDto != null)
                    {
                        playerDto.MFLTeamID = Convert.ToInt32(franchise.TeamId);
                    }
                }
            }

            StoreInformationInDatabase(playerDtos, franchiseDtos, divisionDtos);

            _database.CapRoom = _mflRepository.GetSalaryCapFromApiData(leagueInformation);
        }

        private IEnumerable<PlayerProfile> GetPlayerProfileApiInformation(Uri playerProfileUri, IEnumerable<Player> players)
        {
            List<string> playerIds = players.Select(player => player.PlayerId).ToList();
            List<PlayerProfile> profiles = new List<PlayerProfile>();
            int numIterations = (int)Math.Ceiling(playerIds.Count() / 500.0);

            for (int i = 0; i < numIterations; i++)
            {
                System.Threading.Thread.Sleep(250);
                int startingIndex = i * 500;
                IEnumerable<string> playerIdSubset = playerIds.Skip(startingIndex).Take(500);
                IEnumerable<PlayerProfile> profileSubset =
                    _mflRepository.GetPlayerProfilesFromApi(playerProfileUri, playerIdSubset);
                profiles.AddRange(profileSubset);
            }

            return profiles;
        }

        public void GetLocalInformation()
        {
            List<PlayerDto> playerDtos = _mflRepository.GetPlayersFromFile().ToList();
            List<FranchiseDto> franchiseDtos = _mflRepository.GetFranchisesFromFile().ToList();
            List<DivisionDto> divisionDtos = _mflRepository.GetDivisionsFromFile().ToList();

            StoreInformationInDatabase(playerDtos, franchiseDtos, divisionDtos);

            _database.CapRoom = 125.00;
        }

        public void SaveInformation()
        {
            _mflRepository.SavePlayersToFile(_database.Players.Values);
            _mflRepository.SaveFranchisesToFile(_database.Franchises.Values);
            _mflRepository.SaveDivisionsToFile(_database.Divisions.Values);
        }

        private void StoreInformationInDatabase(IEnumerable<PlayerDto> playerDtos, IEnumerable<FranchiseDto> franchiseDtos, IEnumerable<DivisionDto> divisionDtos)
        {
            _database.Players = new Dictionary<int, PlayerDto>();
            _database.Franchises = new Dictionary<int, FranchiseDto>();
            _database.Divisions = new Dictionary<int, DivisionDto>();

            foreach (var franchise in franchiseDtos)
            {
                _database.Franchises.Add(franchise.Id, franchise);
            }

            foreach (var division in divisionDtos)
            {
                _database.Divisions.Add(division.Id, division);
            }

            foreach (var player in playerDtos)
            {
                _database.Players.Add(player.Id, player);
                AddPlayerToTeam(player);
            }
        }

        #endregion
    }
}
