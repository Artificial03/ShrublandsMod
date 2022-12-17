using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShrublandsMod.Content.Tiles
{
    public class JarrahWood : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            DustType = DustID.RichMahogany;
            ItemDrop = ModContent.ItemType<Items.Placeable.JarrahWood>();

            AddMapEntry(new Color(215, 78, 52));
        }
    }
}