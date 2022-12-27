using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ShrublandsMod.Content.Walls
{
    public class JarrahWoodWall :ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;

            DustType = DustID.RichMahogany;
            ItemDrop = ModContent.ItemType<Items.Placeable.JarrahWoodWall>();

            AddMapEntry(new Color(215, 78, 52));
        }
    }
}
