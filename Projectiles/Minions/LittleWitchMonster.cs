using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace AlchemistNPC.Projectiles.Minions
{
	public class LittleWitchMonster : Minion
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(391);
			projectile.minionSlots = 1;
            Main.projFrames[projectile.type] = 11;
			projectile.aiStyle = 26;
            aiType = 391;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("LittleWitchMonster");
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) 
		{ 
		fallThrough = false; 
		return true; 
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.dead || !modPlayer.LaetitiaGift)
			{
				modPlayer.lwm = false;
				projectile.Kill();
			}
			if (!player.HasBuff(mod.BuffType("LittleWitchMonster")))
			{
				modPlayer.lwm = false;
				projectile.Kill();
			}
			if (!modPlayer.LaetitiaSet && !modPlayer.ParadiseLost)
			{
				modPlayer.lwm = false;
				projectile.Kill();
			}
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
			damage *= 4;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.ShadowFlame, 600);
			target.AddBuff(BuffID.Ichor, 600);
			target.immune[projectile.owner] = 5;
			Player player = Main.player[projectile.owner];
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
			damage *= 4;
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
		
	}
}
