using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFL_Manager.Models.CustomResponeses;

namespace MFL_Manager.Repositories.Interface
{
    public interface IFileRepository
    {
        IEnumerable<PlayerDto> LoadPlayerInformation();

        IEnumerable<FranchiseDto> LoadFranchiseInformation();

        void SavePlayerInformation(IEnumerable<PlayerDto> players);

        void SaveFranchiseInformation(IEnumerable<FranchiseDto> franchises);
    }
}
