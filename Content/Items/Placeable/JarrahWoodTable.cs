using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShrublandsMod.Content.Items.Placeable
{
    public class JarrahWoodTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.JarrahWoodTable>());
            Item.value = 200;
            Item.maxStack = 99;
            Item.width = 38;
            Item.height = 24;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<JarrahWood>(8)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
