using Terraria.ID;
using Terraria.ModLoader;

namespace ShrublandsMod.Content.Dusts
{
	public class ShrublandsBubble : ModDust
	{
		public override void SetStaticDefaults() {
			UpdateType = DustID.Water;
		}
	}
}