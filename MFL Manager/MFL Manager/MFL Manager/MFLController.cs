using System;
using System.Collections;
using System.Collections.Generic;
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

        #endregion

        #region Players

        public void AddPlayer(PlayerDto player)
        {
            if (!_database.Players.ContainsKey(player.Id))
            {
                _database.Players.Add(player.Id, player);
                if (_database.Franchises.TryGetValue(player.MFLTeamID, out FranchiseDto franchise))
                {
                    franchise.AddPlayer(player);
                }
            }
            MessageBox.Show($@"Player with Id {player.Id} already exists");
        }

        public void RemovePlayer(PlayerDto player)
        {
            _database.Players.Remove(player.Id);
            if (_database.Franchises.TryGetValue(player.MFLTeamID, out FranchiseDto franchise))
            {
                franchise.RemovePlayer(player);
            }
        }

        #endregion

        #endregion

        #region Api Requests

        public void GetApiInformation(Uri playerUri, Uri franchiseUri, Uri salaryUri)
        {
            IEnumerable<Player> players = _mflRepository.GetPlayersFromApi(playerUri);
            _leagueInformation = _mflRepository.GetLeagueInformationFromApi(franchiseUri);
            IEnumerable<Salary> salaries = _mflRepository.GetSalariesFromApi(salaryUri);

            List<PlayerDto> playerDtos = _mflRepository.GetPlayerDtosFromApiData(players, salaries).ToList();
            List<FranchiseDto> franchiseDtos = _mflRepository.GetFranchiseDtosFromApiData(_leagueInformation).ToList();

            foreach (var player in playerDtos)
            {
                _database.Players.Add(player.Id, player);
            }

            foreach (var franchise in franchiseDtos)
            {
                _database.Franchises.Add(franchise.Id, franchise);
            }

            _database.CapRoom = _mflRepository.GetSalaryCapFromApiData(_leagueInformation);
        }

        #endregion
    }
}
