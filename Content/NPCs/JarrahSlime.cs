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
    public class JarrahSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BlueSlime]; 

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f 
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults() 
        {
            NPC.width = 22;
            NPC.height = 18;
            NPC.aiStyle = NPCAIStyleID.Slime;
            AIType = NPCID.BlueSlime;
            NPC.damage = 18;
            NPC.defense = 5;
            NPC.lifeMax = 60;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.knockBackResist = 0.8f;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.npcSlots = 1f;
            NPC.value = 100f;
            AnimationType = NPCID.BlueSlime; 
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.JarrahSlimeBanner>();
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A slime common in the shrublands. Hardy, but not very threatening."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (spawnInfo.Player.ZoneForest && Main.dayTime && spawnInfo.Player.ZoneOverworldHeight)
            {
                return 1.5f;
            }
            else
            {
                return 0;
            }
            //if(spawnInfo.Player.GetModPlayer<ExamplePlayer>().ZoneExample) // Mod Biome
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var slimeDropRules = Main.ItemDropsDB.GetRulesForNPCID(NPCID.BlueSlime, false);
            foreach (var slimeDropRule in slimeDropRules)
                npcLoot.Add(slimeDropRule);
        }
    }
}
