using Microsoft.Xna.Framework;
using ShrublandsMod.Content.Biomes;
using ShrublandsMod.Content.NPCs;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShrublandsMod.Common.GlobalNPCs
{
    public class IncreaseSpawnRates : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.InModBiome(ModContent.GetInstance<ShrublandsBiome>()))
                {
                    spawnRate = spawnRate/3;
                    maxSpawns = maxSpawns * 3; 
                }
        }
    }
}
