using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace ShrublandsMod.Content.Items.Plants
{
    public class ShrublandsGrassSeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Can be placed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.rare = ItemRarityID.Blue;
            Item.useTime = 15;
            Item.maxStack = 999;
            Item.placeStyle = 0;
            Item.width = 22;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 0, 5, 0);
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode == NetmodeID.Server)
                return false;

            Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
            if (tile.HasTile && (tile.TileType == TileID.Dirt || tile.TileType == TileID.Grass) && player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY))
            {
                WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, ModContent.TileType<Tiles.ShrublandsGrass>(), forced: true);
                player.inventory[player.selectedItem].stack--;
            }

            return true;
        }
    }
}
