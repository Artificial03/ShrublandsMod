using ShrublandsMod.Content.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace ShrublandsMod.Content.Biomes
{
	public class ShrublandsWaterStyle : ModWaterStyle
	{
		public override int ChooseWaterfallStyle() {
			return ModContent.Find<ModWaterfallStyle>("ExampleMod/ExampleWaterfallStyle").Slot;
		}

		public override int GetSplashDust() {
			return ModContent.DustType<ShrublandsBubble>(); //should probably put a proper thing here
		}

		public override int GetDropletGore() {
			return ModContent.Find<ModGore>("ShrublandsMod/ShrublandsWaterDroplet").Type;
		}

		public override void LightColorMultiplier(ref float r, ref float g, ref float b) {
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor() {
			return Color.GreenYellow;
		}

		public override byte GetRainVariant() {
			return (byte)Main.rand.Next(3);
		}

		public override Asset<Texture2D> GetRainTexture() {
			return ModContent.Request<Texture2D>("ShrublandsMod/Content/Biomes/ShrublandsRain");
		}
	}
}