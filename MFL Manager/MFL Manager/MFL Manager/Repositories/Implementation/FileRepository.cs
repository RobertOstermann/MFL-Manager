using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using MFL_Manager.Models.CustomResponeses;
using MFL_Manager.Repositories.Interface;

namespace MFL_Manager.Repositories.Implementation
{
    public class FileRepository : IFileRepository
    {
        private readonly string _filePath = @"..\\..\\..\\..\\MFLData\";

        public IEnumerable<PlayerDto> LoadPlayerInformation()
        {
            if (string.IsNullOrWhiteSpace(_filePath))
                return new List<PlayerDto>();

            string path = _filePath + "PlayerInformation.txt";

            var fileData = LoadInformation<PlayerDto>(path);
            
            return fileData;
        }

        public IEnumerable<FranchiseDto> LoadFranchiseInformation()
        {
            if (string.IsNullOrWhiteSpace(_filePath))
                return new List<FranchiseDto>();

            string path = _filePath + "FranchiseInformation.txt";

            var fileData = LoadInformation<FranchiseDto>(path);

            return fileData;
        }

        public IEnumerable<DivisionDto> LoaDivisionInformation()
        {
            if (string.IsNullOrWhiteSpace(_filePath))
                return new List<DivisionDto>();

            string path = _filePath + "DivisionInformation.txt";

            var fileData = LoadInformation<DivisionDto>(path);

            return fileData;
        }

        private IEnumerable<T> LoadInformation<T>(string path)
        {
            var fileData = new List<T>();

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    fileData.Add(csv.GetRecord<T>());
                }
            }

            return fileData;
        }

        public void SavePlayerInformation(IEnumerable<PlayerDto> players)
        {
            string path = _filePath + "PlayerInformation.txt";

            SaveInformation(path, players);
        }

        public void SaveFranchiseInformation(IEnumerable<FranchiseDto> franchises)
        {
            string path = _filePath + "FranchiseInformation.txt";

            SaveInformation(path, franchises);
        }

        public void SaveDivisionInformation(IEnumerable<DivisionDto> divisions)
        {
            string path = _filePath + "DivisionInformation.txt";

            SaveInformation(path, divisions);
        }

        private void SaveInformation<T>(string path, IEnumerable<T> information)
        {
            using (StreamWriter writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(information);
            }
        }
    }
}
