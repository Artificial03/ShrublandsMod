using IL.Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ItemRarityID = Terraria.ID.ItemRarityID;
using Terraria.DataStructures;
using Terraria;
using IL.Terraria;
using On.Terraria;
using ShrublandsMod.Content.Tiles.Banners;

namespace ShrublandsMod.Content.Items.Banners
{
    public class JarrahSlimeBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = Terraria.ID.ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = 100;
            Item.createTile = ModContent.TileType<BannerTile>();
            Item.placeStyle = 0;

        }
    }
}
