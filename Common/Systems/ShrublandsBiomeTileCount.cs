using System;
using ShrublandsMod.Content.Tiles;
using Terraria.ModLoader;

namespace ShrublandsMod.Common.Systems
{
	public class ShrublandsBiomeTileCount : ModSystem
	{
		public int ShrublandsBlockCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts) {
			ShrublandsBlockCount = tileCounts[ModContent.TileType<ShrublandsGrass>()];
		}
	}
}
