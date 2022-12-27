using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace ShrublandsMod.Content.Items.Placeable
{
    public class JarrahWood : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.JarrahWood>();
        }

        public override void AddRecipes()
        {
            CreateRecipe() // Add multiple recipes set to one Item.
                .AddIngredient<JarrahWoodWall>(4)
                .AddTile(TileID.WorkBenches)
                .Register();

            CreateRecipe()
                .AddIngredient<JarrahWoodPlatform>(2)
                .Register();
        }
    }
}
