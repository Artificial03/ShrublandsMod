using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShrublandsMod.Content.Tiles.Plants
{
	public class JarrahTreeLeaf : ModGore
	{
		public override string Texture => "ShrublandsMod/Content/Tiles/Plants/JarrahTree_Leaf";

		public override void SetStaticDefaults() {
			
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}
