using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace ShrublandsMod.Content.Items.Placeable
{
    public class JarrahWoodWall : ModItem
    {
        public override void SetStaticDefaults()
        { 
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<Walls.JarrahWoodWall>(); // The ID of the wall that this item should place when used. ModContent.WallType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets).
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient<JarrahWood>(1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
