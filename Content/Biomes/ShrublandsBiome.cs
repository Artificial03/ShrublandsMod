using ShrublandsMod.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ModLoader;

namespace ShrublandsMod.Content.Biomes
{
	// Shows setting up two basic biomes. For a more complicated example, please request.
	public class ShrublandsBiome : ModBiome
	{
		// Select all the scenery
		public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("ShrublandsMod/ShrublandsWaterStyle"); // Sets a water style for when inside this biome
		public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("ShrublandsMod/ShrublandsBackgroundStyle");
		public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Jungle;

		// Select Music
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/Shrublands");

		// Populate the Bestiary Filter
		public override string BestiaryIcon => base.BestiaryIcon;
		public override string BackgroundPath => base.BackgroundPath;
		public override Color? BackgroundColor => base.BackgroundColor;
		public override string MapBackground => BackgroundPath; // Re-uses Bestiary Background for Map Background

		// Use SetStaticDefaults to assign the display name
		public override void SetStaticDefaults() {
			// This translation is set in localization files
			// DisplayName.SetDefault("Example Surface");
		}

		// Calculate when the biome is active.
		public override bool IsBiomeActive(Player player) {
			// First, we will use the exampleBlockCount from our added ModSystem for our first custom condition
			bool b1 = ModContent.GetInstance<ShrublandsBiomeTileCount>().ShrublandsBlockCount >= 25;

			// Finally, we will limit the height at which this biome can be active to above ground (ie sky and surface). Most (if not all) surface biomes will use this condition.
			bool b2 = player.ZoneSkyHeight || player.ZoneOverworldHeight;
			return b1 && b2;
		}
	}
}
