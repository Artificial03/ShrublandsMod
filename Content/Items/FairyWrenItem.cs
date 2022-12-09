using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Net;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Creative;
using ShrublandsMod.Content.NPCs;

namespace ShrublandsMod.Content.Items
{
    public class FairyWrenItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fairy Wren"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("It's a fairy wren!!! :)");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.height = 20;
            Item.width = 16;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 1);
            Item.consumable = true;
            Item.makeNPC = ModContent.NPCType<FairyWren>();
        }
    }
}
