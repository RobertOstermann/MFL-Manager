using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.ApiResponses.Salary;
using MFL_Manager.Repositories.Implementation;
using MFL_Manager.Repositories.Interface;

namespace MFL_Manager
{
    public class MFLController
    {
        private readonly IMFLRepository _mflRepository;
        private PlayerDatabase _database;

        public MFLController(IMFLRepository mflRepository, PlayerDatabase database)
        {
            _mflRepository = mflRepository;
            _database = database;
        }

        public void GetApiInformation(Uri playerUri, Uri franchiseUri, Uri salaryUri)
        {
            IEnumerable<Player> players = _mflRepository.GetPlayersFromApi(playerUri);
            IEnumerable<Franchise> franchises = _mflRepository.GetFranchisesFromApi(franchiseUri);
            IEnumerable<Salary> salaries = _mflRepository.GetSalariesFromApi(salaryUri);
        }

        public IEnumerable<Player> GetPlayersFromApi(Uri uri)
        {
            return _mflRepository.GetPlayersFromApi(uri);
        }

        public IEnumerable<Franchise> GetFranchisesFromApi(Uri uri)
        {
            return _mflRepository.GetFranchisesFromApi(uri);
        }

        public IEnumerable<Salary> GetSalariesFromApi(Uri uri)
        {
            return _mflRepository.GetSalariesFromApi(uri);
        }
    }
}
