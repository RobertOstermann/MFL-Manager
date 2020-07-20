using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFL_Manager.Repositories.Implementation;
using MFL_Manager.Repositories.Interface;

namespace MFL_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PlayerDatabase database = new PlayerDatabase();
            FileRepository fileRepository = new FileRepository();
            RestApiRepository restApiRepository = new RestApiRepository();
            MFLRepository repository = new MFLRepository(restApiRepository, fileRepository);
            MFLController controller = new MFLController(repository, database);
            Manager manager = new Manager(controller);
            controller.Manager = manager;

            Application.Run(manager);

        }
    }
}
