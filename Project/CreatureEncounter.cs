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
                    Enemy e = new Enemy(
                                creatureData[0],                //Name
                                Int32.Parse(creatureData[1]),   //Hit points
                                Int32.Parse(creatureData[2]),   //Attack Strength
                                Int32.Parse(creatureData[3]),   //Armour Class
                                float.Parse(creatureData[4]),   //Attack Modifier 
                                Int32.Parse(creatureData[5]),   //Min Xp
                                Int32.Parse(creatureData[6]),   //Max XP
                                Int32.Parse(creatureData[7]),   //Min Gold
                                Int32.Parse(creatureData[8])    //Max Gold
                                );
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
