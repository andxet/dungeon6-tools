using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeon6tools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine(GeneralData.GetGameNameAndVersion());
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            GameManager gm = new GameManager();

            //for (int i = 0; i < 20; i++)
            //    Console.WriteLine(gm.RollDice6());

            //for (int i = 0; i < 20; i++)
            //    Console.WriteLine(gm.GenerateName());

            Character wizard = new Character(gm, PGClasses.WIZARD);
            wizard.AddExp(135);
            Character warrior = new Character(gm, PGClasses.WARRIOR);
        }
    }
}
