using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
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
        private LeagueInformation _leagueInformation;

        public MFLController(IMFLRepository mflRepository, PlayerDatabase database)
        {
            _mflRepository = mflRepository;
            _database = database;
        }

        #region Database Access

        #region Franchises

        public LeagueInformation GetLeagueInformation()
        {
            return _leagueInformation;
        }

        public IEnumerable<FranchiseDto> GetFranchiseInformation()
        {
            return _database.Franchises.Values;
        }

        public FranchiseDto GetFranchiseInformation(int id)
        {
            return (from franchise in _database.Franchises where franchise.Key == id select franchise.Value).FirstOrDefault();
        }

        public double GetCapInformation()
        {
            return _database.CapRoom;
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

        #endregion

        #region Information Operations

        public void GetApiInformation(Uri playerUri, Uri franchiseUri, Uri salaryUri)
        {
            IEnumerable<Player> players = _mflRepository.GetPlayersFromApi(playerUri);
            _leagueInformation = _mflRepository.GetLeagueInformationFromApi(franchiseUri);
            IEnumerable<Salary> salaries = _mflRepository.GetSalariesFromApi(salaryUri);

            List<PlayerDto> playerDtos = _mflRepository.GetPlayerDtosFromApiData(players, salaries).ToList();
            List<FranchiseDto> franchiseDtos = _mflRepository.GetFranchiseDtosFromApiData(_leagueInformation).ToList();

            StoreInformationInDatabase(playerDtos, franchiseDtos);

            _database.CapRoom = _mflRepository.GetSalaryCapFromApiData(_leagueInformation);
        }

        public void GetLocalInformation()
        {
            List<PlayerDto> playerDtos = _mflRepository.GetPlayersFromFile().ToList();
            List<FranchiseDto> franchiseDtos = _mflRepository.GetFranchisesFromFile().ToList();

            StoreInformationInDatabase(playerDtos, franchiseDtos);

            _database.CapRoom = 125.00;
        }

        public void SaveInformation()
        {
            _mflRepository.SavePlayersToFile(_database.Players.Values);
            _mflRepository.SaveFranchisesToFile(_database.Franchises.Values);
        }

        private void StoreInformationInDatabase(IEnumerable<PlayerDto> playerDtos, IEnumerable<FranchiseDto> franchiseDtos)
        {
            _database.Players = new Dictionary<int, PlayerDto>();
            _database.Franchises = new Dictionary<int, FranchiseDto>();

            foreach (var player in playerDtos)
            {
                _database.Players.Add(player.Id, player);
            }

            foreach (var franchise in franchiseDtos)
            {
                _database.Franchises.Add(franchise.Id, franchise);
            }
        }

        #endregion
    }
}
