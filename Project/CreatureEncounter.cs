using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LORD
{
    class CreatureEncounter
    {
        private List<Enemy> creatures = new List<Enemy>();
        public CreatureEncounter(int playerLevel)
        {
            if (creatures.Count > 0)
                return;

            Stream readCreatures = new FileStream($"Creatures\\Level{playerLevel.ToString()}.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(readCreatures);
            string creatureDataLine = string.Empty;

            //Skip the first line as it is a head row
            reader.ReadLine();

            while(reader.Peek() > 0)
            {
                creatureDataLine = reader.ReadLine();
                string[] creatureData = creatureDataLine.Split(':');

                for(int x = 0; x<creatureData.Length; x++)
                {
                    Enemy e = new Enemy(creatureData[0], Int32.Parse(creatureData[1]), Int32.Parse(creatureData[2]), Int32.Parse(creatureData[3]), float.Parse(creatureData[4]));
                    creatures.Add(e);
                }
            }
        }

        public Enemy GetEncounter()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return creatures[rnd.Next(0, creatures.Count)];
        }
    }
}
