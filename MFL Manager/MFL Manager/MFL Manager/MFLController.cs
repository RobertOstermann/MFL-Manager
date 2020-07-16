using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MFLController(IMFLRepository mflRepository, PlayerDatabase database)
        {
            _mflRepository = mflRepository;
            _database = database;
        }

        public void GetApiInformation(Uri playerUri, Uri franchiseUri, Uri salaryUri)
        {
            IEnumerable<Player> players = _mflRepository.GetPlayersFromApi(playerUri);
            LeagueInformation leagueInformation = _mflRepository.GetLeagueInformationFromApi(franchiseUri);
            IEnumerable<Salary> salaries = _mflRepository.GetSalariesFromApi(salaryUri);

            IEnumerable<PlayerDto> playerDtos = _mflRepository.GetPlayerDtosFromApiData(players, salaries);
            IEnumerable<FranchiseDto> franchiseDtos = _mflRepository.GetFranchiseDtosFromApiData(leagueInformation);

            _database.Players = playerDtos.ToList();
            _database.Franchises = franchiseDtos.ToList();
        }

        public IEnumerable<Player> GetPlayersFromApi(Uri uri)
        {
            return _mflRepository.GetPlayersFromApi(uri);
        }

        public LeagueInformation GetLeagueInformationFromApi(Uri uri)
        {
            return _mflRepository.GetLeagueInformationFromApi(uri);
        }

        public IEnumerable<Salary> GetSalariesFromApi(Uri uri)
        {
            return _mflRepository.GetSalariesFromApi(uri);
        }
    }
}
