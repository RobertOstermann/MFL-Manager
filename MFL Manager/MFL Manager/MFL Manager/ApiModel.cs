/* ApiModel.cs
 * Author: Robert Ostermann
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFL_Manager
{
    /// <summary>
    /// This class matches the MFL JSON data, which allows processing of information.
    /// </summary>
    public class ApiModel
    {
        /// <summary>
        /// MFL Players JSON
        /// Provides - Name, ID, Position, NFL NFLTeam
        /// </summary>
        public ApiAllPlayerObject Players { get; set; }

        public class ApiAllPlayerObject
        {
            public List<ApiPlayerObject> Player { get; set; }

            public class ApiPlayerObject
            {
                public string Name { get; set; }

                public int Id { get; set; }

                public string Position { get; set; }

                public string Team { get; set; }
            }
        }

        /// <summary>
        /// MFL Salaries JSON
        /// Provides - ID, Salary, Contract Year
        /// </summary>
        public ApiPlayerSalaryObject Salaries { get; set; }

        public class ApiPlayerSalaryObject
        {
            public ApiLeagueUnit LeagueUnit { get; set; }

            public class ApiLeagueUnit
            {
                public List<ApiLeagueUnitPlayer> Player { get; set; }

                public class ApiLeagueUnitPlayer
                {
                    public double Salary { get; set; }

                    public int Id { get; set; }

                    public string ContractYear { get; set; }
                }
            }
        }

        /// <summary>
        /// MFL League JSON
        /// Provides - Franchise Name, Franchise ID, Franchise DivisionId
        /// </summary>
        public ApiLeagueObject League { get; set; }

        public class ApiLeagueObject
        {
            public ApiAllFranchiseObject Franchises { get; set; }

            public class ApiAllFranchiseObject
            {
                public List<ApiFranchiseObject> Franchise { get; set; }

                public class ApiFranchiseObject
                {
                    public string Name { get; set; }

                    public int Id { get; set; }

                    public int Division { get; set; }
                }
            }
        }
    }
}