using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using ShrublandsMod.Content.Items;

namespace ShrublandsMod.Content.NPCs
{
    internal class FairyWren : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from localization files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Fairy Wren");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Bird]; // The amount of frames the NPC has
            Main.npcCatchable[Type] = true; // this makes thing work???

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };


            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 13;
            NPC.height = 10;
            NPC.aiStyle = 24;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.knockBackResist = 0.8f;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.catchItem = ModContent.ItemType<FairyWrenItem>(); // may want this later
            NPC.npcSlots = 0.4f;
            NPC.friendly = true; // temporary solution, not full bird functionality
            NPC.dontTakeDamageFromHostiles = false; //may need this
            AnimationType = NPCID.Bird; // may need this. test with and without.
            //SpawnModBiomes = new int[] { ModContent.GetInstance<Shrublands>().Type }; // Associates this NPC with the ExampleSurfaceBiome in Bestiary
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A bird found in the shrublands. It's very cute"),
            });
        }
        //may be unnecssary
        //public override void OnCaughtBy(Player player, Item item, bool failed) {}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (spawnInfo.Player.ZoneForest && Main.dayTime && spawnInfo.Player.ZoneOverworldHeight)
            {
                return 0.8f;
            }
            else
            {
                return 0;
            }//if(spawnInfo.Player.GetModPlayer<ExamplePlayer>().ZoneExample) // Mod Biome
        }
    }
}
