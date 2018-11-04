using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TownsGame.Models
{
    public static class Game
    {
        private static HashSet<string> allTowns = new HashSet<string>();
        private static HashSet<string> usedTowns = new HashSet<string>();

        static Game()
        {
            using (StreamReader readerTown = new StreamReader(new FileInfo("TownList.txt").OpenRead()))
            {
                while (!readerTown.EndOfStream)
                {
                    allTowns.Add(readerTown.ReadLine());
                }
            }
        }

        public static void AddStep(string Town)
        {

        }

    }
}