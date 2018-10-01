using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace AlchemistNPC.Items.Equippable
{
	class GrapplingHookGunItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grappling Hook Gun");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.AmethystHook);
			item.shootSpeed = 28f;
			item.rare = 11;
			item.shoot = mod.ProjectileType("GrapplingHookGunProjectile");
		}
	}
	class GrapplingHookGunProjectile : ModProjectile
	{
		public static int counter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grappling Hook Gun Projectile");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
			projectile.height = 22;
		}

		public override bool? CanUseGrapple(Player player)
		{
			int hooksOut = 0;
			for (int l = 0; l < 5; l++)
			{
				if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type)
				{
					hooksOut++;
				}
			}
			if (hooksOut > 0)
			{
				return false;
			}
			return true;
		}

		public override float GrappleRange()
		{
			return 900f;
		}

		public override void NumGrappleHooks(Player player, ref int numHooks)
		{
			numHooks = 1;
		}

		public override void GrappleRetreatSpeed(Player player, ref float speed)
		{
			speed = 28f;
		}

		public override void GrapplePullSpeed(Player player, ref float speed)
		{
			speed = 24;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			counter++;
			Vector2 playerCenter = Main.player[projectile.owner].MountedCenter;
			Vector2 center = projectile.Center;
			Vector2 distToProj = playerCenter - projectile.Center;
			float projRotation = distToProj.ToRotation() - 1.57f;
			float distance = distToProj.Length();
			while (distance > 20f && !float.IsNaN(distance))
			{
				distToProj.Normalize();                 //get unit vector
				distToProj *= 10f;                      //speed = 24
				center += distToProj;                   //update draw position
				distToProj = playerCenter - center;    //update distance
				distance = distToProj.Length();
			}
			return true;
		}
	}
}
