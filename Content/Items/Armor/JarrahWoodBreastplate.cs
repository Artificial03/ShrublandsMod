using ShrublandsMod.Content.Items.Placeable;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShrublandsMod.Content.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class JarrahWoodBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = 100; // How many coins the item is worth
			Item.rare = ItemRarityID.White; // The rarity of the item
			Item.defense = 4; // The amount of defense the item will give when equipped
		}


		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient<JarrahWood>(30)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
	}
}
