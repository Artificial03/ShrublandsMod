using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ShrublandsMod.Content.Items.Placeable;

namespace ShrublandsMod.Content.Items.Weapons
{
    public class JarrahWoodSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("JarrahWoodSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("This is a basic modded sword.");

        }

        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 300;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            //testing git, ^ false now
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<JarrahWood>(7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}