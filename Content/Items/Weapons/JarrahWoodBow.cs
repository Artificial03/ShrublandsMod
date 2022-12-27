using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ShrublandsMod.Content.Items.Placeable;

namespace ShrublandsMod.Content.Items.Weapons
{
    public class JarrahWoodBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() 
        {
            Item.width = 12;
            Item.height = 28;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 28;
            Item.useTime = 28;
            Item.UseSound = SoundID.Item5;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useAmmo = AmmoID.Arrow;
            Item.damage = 9;
            Item.shootSpeed = 6.5f;
            Item.noMelee = true;
            Item.value = 100;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<JarrahWood>(10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
