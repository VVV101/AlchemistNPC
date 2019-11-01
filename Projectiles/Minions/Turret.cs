using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles.Minions
{
    public class Turret : ModProjectile
    {
		public int counter = 0;
        public override void SetDefaults()
        {
            projectile.width = 46;
            projectile.height = 48;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.ignoreWater = true;
            projectile.sentry = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GLaDOS turret");
			Main.projFrames[projectile.type] = 2;

        }
		
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.width = 32;
			projectile.velocity.Y = 0f;
			return false;
		}
		
        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.dead || !player.HasBuff(mod.BuffType("Turret")))
			{
				modPlayer.turret = false;
			}
			if (modPlayer.turret)
			{
				projectile.timeLeft = 2;
			}
            if (projectile.localAI[0] == 0f)
            {
                projectile.localAI[1] = 1f;
                projectile.localAI[0] = 1f;
                projectile.ai[0] = 120f;
                Main.PlaySound(SoundID.Item11, projectile.position);
            }
            projectile.velocity.X = 0f;
            projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            bool flag18 = false;
            float num506 = projectile.Center.X;
            float num507 = projectile.Center.Y;
            float num508 = 1000f;
            NPC ownerMinionAttackTargetNPC = projectile.OwnerMinionAttackTargetNPC;
            if (ownerMinionAttackTargetNPC != null && ownerMinionAttackTargetNPC.CanBeChasedBy(this, false))
            {
                float num509 = ownerMinionAttackTargetNPC.position.X + ownerMinionAttackTargetNPC.width / 2;
                float num510 = ownerMinionAttackTargetNPC.position.Y + ownerMinionAttackTargetNPC.height / 2;
                float num511 = Math.Abs(projectile.position.X + projectile.width / 2 - num509) + Math.Abs(projectile.position.Y + projectile.height / 2 - num510);
                if (num511 < num508 && Collision.CanHit(projectile.position, projectile.width, projectile.height, ownerMinionAttackTargetNPC.position, ownerMinionAttackTargetNPC.width, ownerMinionAttackTargetNPC.height))
                {
                    num508 = num511;
                    num506 = num509;
                    num507 = num510;
                    flag18 = true;
                }
            }
            if (!flag18)
            {
                for (int num512 = 0; num512 < 200; num512++)
                {
                    if (Main.npc[num512].CanBeChasedBy(this, false))
                    {
                        float num513 = Main.npc[num512].position.X + Main.npc[num512].width / 2;
                        float num514 = Main.npc[num512].position.Y + Main.npc[num512].height / 2;
                        float num515 = Math.Abs(projectile.position.X + projectile.width / 2 - num513) + Math.Abs(projectile.position.Y + projectile.height / 2 - num514);
                        if (num515 < num508 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num512].position, Main.npc[num512].width, Main.npc[num512].height))
                        {
                            num508 = num515;
                            num506 = num513;
                            num507 = num514;
                            flag18 = true;
                        }
                    }
                }
				projectile.frame = 1;
            }
            if (flag18)
            {
				if (counter == 60)
				{
					Main.PlaySound(2, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/ThereYouAre"));
				}
				counter++;
				if (counter == 1200)
				{
					counter = 0;
				}
                float num516 = num506;
                float num517 = num507;
                num506 -= projectile.Center.X;
                num507 -= projectile.Center.Y;
				int num518 = 0;
                if (projectile.frameCounter > 0)
                {
                    projectile.frameCounter--;
                }
                if (projectile.frameCounter <= 0)
                {
                    int num519 = projectile.spriteDirection;
                    if (num506 < 0f)
                    {
                        projectile.spriteDirection = -1;
                    }
                    else
                    {
                        projectile.spriteDirection = 1;
                    }
                    if (num507 > 0f)
                    {
                        num518 = 0;
                    }
                    else if (Math.Abs(num507) > Math.Abs(num506) * 3f)
                    {
                        num518 = 4;
                    }
                    else if (Math.Abs(num507) > Math.Abs(num506) * 2f)
                    {
                        num518 = 3;
                    }
                    else if (Math.Abs(num506) > Math.Abs(num507) * 3f)
                    {
                        num518 = 0;
                    }
                    else if (Math.Abs(num506) > Math.Abs(num507) * 2f)
                    {
                        num518 = 1;
                    }
                    else
                    {
                        num518 = 2;
                    }
                    projectile.frame = 1;
                    projectile.frameCounter = 8;
					if (projectile.ai[0] <= 0f)
					{
						projectile.frameCounter = 4;
					}
                }
                if (projectile.ai[0] <= 0f)
                {
                    projectile.localAI[1] = 0f;
                    projectile.ai[0] = 3f;
                    if (Main.myPlayer == projectile.owner)
                    {
                        float num521 = 6f;
                        int num522 = 242;
                        Vector2 vector37 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                        if (num518 == 0)
                        {
                            vector37.X += 24 * projectile.spriteDirection;
                        }
                        else if (num518 == 1)
                        {
                            vector37.X += 24 * projectile.spriteDirection;
                        }
                        else if (num518 == 2)
                        {
                            vector37.X += 24 * projectile.spriteDirection;
                        }
                        else if (num518 == 3)
                        {
                            vector37.X += 14 * projectile.spriteDirection;
                        }
                        else if (num518 == 4)
                        {
                            vector37.X += 2 * projectile.spriteDirection;
                        }
                        if (projectile.spriteDirection < 0)
                        {
                            vector37.X += 10f;
                        }
                        float num523 = num516 - vector37.X;
                        float num524 = num517 - vector37.Y;
                        float num525 = (float)Math.Sqrt(num523 * num523 + num524 * num524);
                        num525 = num521 / num525;
                        num523 *= num525;
                        num524 *= num525;
                        int num526 = projectile.damage;
                        Projectile.NewProjectile(vector37.X, vector37.Y, num523, num524, num522, num526, projectile.knockBack, Main.myPlayer, 0f, 0f);
                    }
                }
            }
            else if (projectile.ai[0] <= 60f && (projectile.frame == 1 || projectile.frame == 3 || projectile.frame == 5 || projectile.frame == 7 || projectile.frame == 9))
            {
                projectile.frame = 0;
            }
            if (projectile.ai[0] > 0f)
            {
                projectile.ai[0] -= 1f;
                return;
            }
        }
    }
}