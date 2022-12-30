using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace ShrublandsMod.Content.Items.Placeable
{
    public class JarrahWoodChair : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.JarrahWoodChair>());
            Item.value = 150;
            Item.maxStack = 99;
            Item.width = 12;
            Item.height = 30;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<JarrahWood>(4)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
