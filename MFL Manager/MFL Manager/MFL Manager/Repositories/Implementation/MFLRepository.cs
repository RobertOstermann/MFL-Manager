using System;
using System.Collections.Generic;
using MFL_Manager.Models.ApiResponses.League;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.ApiResponses.Salary;
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

        public void GetPlayersFromApiData(IEnumerable<Player> players, IEnumerable<Franchise> franchises, IEnumerable<Salary> salaries)
        {

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

        public IEnumerable<Franchise> GetFranchisesFromApi(Uri uri)
        {
            if (uri == null)
                throw new ArgumentException("Player request null in MFL Repository");

            var response = _restApiRepository.GetRequest(uri);

            if (string.IsNullOrWhiteSpace(response))
                return new List<Franchise>();

            var data = JsonConvert.DeserializeObject<LeagueRequest>(response);

            IEnumerable<Franchise> franchises = data.LeagueInformation.FranchiseInformation.Teams;

            return franchises;
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
