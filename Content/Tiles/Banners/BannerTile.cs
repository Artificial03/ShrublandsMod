using Microsoft.Xna.Framework;
using ShrublandsMod.Content.Items.Banners;
using ShrublandsMod.Content.NPCs;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ShrublandsMod.Content.Tiles.Banners
{
    public class BannerTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);

            DustType = -1;


            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Banner");
            AddMapEntry(new Color(53, 26, 18), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int style = frameX / 18;
            switch (style)
            {
                case 0:
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<Items.Banners.JarrahSlimeBanner>());
                    break;
                default:
                    return;
            }
            
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.LocalPlayer;
                int style = Main.tile[i, j].TileFrameX / 18;
                switch (style)
                {
                    case 0:
                        Main.SceneMetrics.hasBanner = true;
                        Main.SceneMetrics.NPCBannerBuff[ModContent.NPCType<JarrahSlime>()] = true;
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
