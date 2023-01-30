using ShrublandsMod.Content.Dusts;
using ShrublandsMod.Content.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using ShrublandsMod.Content.Items.Placeable;

namespace ShrublandsMod.Content.Tiles.Plants
{
	public class JarrahTree : ModTree
	{
		// This is a blind copy-paste from Vanilla's PurityPalmTree settings.
		//TODO: This needs some explanations
		public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings {
			UseSpecialGroups = true,
			SpecialGroupMinimalHueValue = 11f / 72f,
			SpecialGroupMaximumHueValue = 0.25f,
			SpecialGroupMinimumSaturationValue = 0.88f,
			SpecialGroupMaximumSaturationValue = 1f
		};

		public override void SetStaticDefaults() {
			// Makes Example Tree grow on ExampleBlock
			GrowsOnTileId = new int[1] { ModContent.TileType<ShrublandsGrass>() };
		}

		// This is the primary texture for the trunk. Branches and foliage use different settings.
		public override Asset<Texture2D> GetTexture() {
			return ModContent.Request<Texture2D>("ShrublandsMod/Content/Tiles/Plants/JarrahTree");
		}

		public override int SaplingGrowthType(ref int style) {
			style = 0;
			return ModContent.TileType<JarrahSapling>();
		}

		public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight) {
			// This is where fancy code could go, but let's save that for an advanced example
		}

		// Branch Textures
		public override Asset<Texture2D> GetBranchTextures() {
			return ModContent.Request<Texture2D>("ShrublandsMod/Content/Tiles/Plants/JarrahTree_Branches");
		}

		// Top Textures
		public override Asset<Texture2D> GetTopTextures() {
			return ModContent.Request<Texture2D>("ShrublandsMod/Content/Tiles/Plants/JarrahTree_Tops");
		}

		public override int DropWood() {
			return ModContent.ItemType<Items.Placeable.JarrahWood>();
		}

		public override bool Shake(int x, int y, ref bool createLeaves) {
			Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, ModContent.ItemType<Items.Placeable.JarrahWood>());
			return false;
		}

		public override int TreeLeaf() {
			return ModContent.GoreType<JarrahTreeLeaf>();
		}
	}
}