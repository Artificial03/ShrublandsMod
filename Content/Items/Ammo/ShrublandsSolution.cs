using Microsoft.Xna.Framework;
using System;
using ShrublandsMod.Content.Items;
using ShrublandsMod.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using ShrublandsMod.Content.Dusts;

namespace ShrublandsMod.Content.Items.Ammo
{
    public class ShrublandsSolutionItem : ModItem
    {
        public override string Texture =>  "ShrublandsMod/Assets/Textures/Projectiles/ShrublandsSolution";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow Solution");
            Tooltip.SetDefault("Used by the Clentaminator\nSpreads the Shrublands");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.shoot = ModContent.ProjectileType<ShrublandsSolutionProjectile>() - ProjectileID.PureSpray;
            Item.ammo = AmmoID.Solution;
            Item.width = 10;
            Item.height = 12;
            Item.value = Item.buyPrice(0, 0, 25);
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 999;
            Item.consumable = true;
        }
    }

    public class ShrublandsSolutionProjectile : ModProjectile
    {
        public override string Texture => "ShrublandsMod/Assets/Textures/Projectiles/ShrublandsSolution";

        public ref float Progress => ref Projectile.ai[0];

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shrublands Spray");
        }

        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 2;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            // Set the dust type to ShrublandsSolution
            int dustType = ModContent.DustType<ShrublandsSolution>();

            if (Projectile.owner == Main.myPlayer)
            {
                Convert((int)(Projectile.position.X + (Projectile.width * 0.5f)) / 16, (int)(Projectile.position.Y + (Projectile.height * 0.5f)) / 16, 2);
            }

            if (Projectile.timeLeft > 133)
            {
                Projectile.timeLeft = 133;
            }

            if (Progress > 7f)
            {
                float dustScale = 1f;

                if (Progress == 8f)
                {
                    dustScale = 0.2f;
                }
                else if (Progress == 9f)
                {
                    dustScale = 0.4f;
                }
                else if (Progress == 10f)
                {
                    dustScale = 0.6f;
                }
                else if (Progress == 11f)
                {
                    dustScale = 0.8f;
                }

                Progress += 1f;


                var dust = Dust.NewDustDirect(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustType, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);

                dust.noGravity = true;
                dust.scale *= 1.75f;
                dust.velocity.X *= 2f;
                dust.velocity.Y *= 2f;
                dust.scale *= dustScale;
            }
            else
            {
                Progress += 1f;
            }

            Projectile.rotation += 0.3f * Projectile.direction;
        }

        private static void Convert(int i, int j, int size = 4)
        {
            for (int k = i - size; k <= i + size; k++)
            {
                for (int l = j - size; l <= j + size; l++)
                {
                    if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt((size * size) + (size * size)))
                    {
                        int type = Main.tile[k, l].TileType;
                        int wall = Main.tile[k, l].WallType;

                        // If the tile is stone, convert to ExampleBlock
                        if (TileID.Sets.Conversion.Grass[type])
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<ShrublandsGrass>();
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                    }
                }
            }
        }
    }
}