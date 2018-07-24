using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Localization;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadBossHead]
	public class Knuckles : ModNPC
	{
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DungeonGuardian);
			npc.boss = true;
			npc.width = 96;
			npc.height = 76;
			npc.damage = 666666;
			npc.defense = 666666;
			npc.lifeMax = 666666;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 999f;
			npc.knockBackResist = 999f;
			npc.aiStyle = 11;
			aiType = NPCID.DungeonGuardian;
			animationType = NPCID.DungeonGuardian;
			npc.buffImmune[mod.BuffType("ArmorDestruction")] = true;
			music = MusicID.Boss2;
		}
		
		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Ugandan Knuckles");
		}
		
		public override void AI()
		{
		npc.velocity *= 1.5f;
		if (npc.life > 333333)
			{
			if (Main.rand.Next(20) == 0)
				{
				Vector2 vel = new Vector2(-1, -1);
				vel *= 8f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 100, 200, 0, Main.myPlayer);
				Vector2 vel2 = new Vector2(1, 1);
				vel2 *= 8f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 100, 200, 0, Main.myPlayer);
				Vector2 vel3 = new Vector2(1, -1);
				vel3 *= 8f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 100, 200, 0, Main.myPlayer);
				Vector2 vel4 = new Vector2(-1, 1);
				vel4 *= 8f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 100, 200, 0, Main.myPlayer);
				Vector2 vel5 = new Vector2(0, -1);
				vel5 *= 8f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 100, 200, 0, Main.myPlayer);
				Vector2 vel6 = new Vector2(0, 1);
				vel6 *= 8f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 100, 200, 0, Main.myPlayer);
				Vector2 vel7 = new Vector2(1, 0);
				vel7 *= 8f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 100, 200, 0, Main.myPlayer);
				Vector2 vel8 = new Vector2(-1, 0);
				vel8 *= 8f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 100, 200, 0, Main.myPlayer);
				}
			}
		else
			{
			if (Main.rand.Next(25) == 0)
				{
				Vector2 vel = new Vector2(-1, -1);
				vel *= 9f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 449, 300, 0, Main.myPlayer);
				Vector2 vel2 = new Vector2(1, 1);
				vel2 *= 9f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 449, 300, 0, Main.myPlayer);
				Vector2 vel3 = new Vector2(1, -1);
				vel3 *= 9f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 449, 300, 0, Main.myPlayer);
				Vector2 vel4 = new Vector2(-1, 1);
				vel4 *= 9f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 449, 300, 0, Main.myPlayer);
				Vector2 vel5 = new Vector2(0, -1);
				vel5 *= 9f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 449, 300, 0, Main.myPlayer);
				Vector2 vel6 = new Vector2(0, 1);
				vel6 *= 9f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 449, 300, 0, Main.myPlayer);
				Vector2 vel7 = new Vector2(1, 0);
				vel7 *= 9f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 449, 300, 0, Main.myPlayer);
				Vector2 vel8 = new Vector2(-1, 0);
				vel8 *= 9f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 449, 300, 0, Main.myPlayer);
				}
			if (Main.rand.Next(50) == 0)
				{
				Vector2 vel = new Vector2(-1, -1);
				vel *= 12f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 448, 300, 0, Main.myPlayer);
				Vector2 vel2 = new Vector2(1, 1);
				vel2 *= 12f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 448, 300, 0, Main.myPlayer);
				Vector2 vel3 = new Vector2(1, -1);
				vel3 *= 12f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 448, 300, 0, Main.myPlayer);
				Vector2 vel4 = new Vector2(-1, 1);
				vel4 *= 12f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 448, 300, 0, Main.myPlayer);
				Vector2 vel5 = new Vector2(0, -1);
				vel5 *= 12f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 448, 300, 0, Main.myPlayer);
				Vector2 vel6 = new Vector2(0, 1);
				vel6 *= 12f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 448, 300, 0, Main.myPlayer);
				Vector2 vel7 = new Vector2(1, 0);
				vel7 *= 12f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 448, 300, 0, Main.myPlayer);
				Vector2 vel8 = new Vector2(-1, 0);
				vel8 *= 12f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 448, 300, 0, Main.myPlayer);
				}
			}
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
		target.AddBuff(mod.BuffType("Uganda"), 1200);
		}
		
		public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)	
		{
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AlchemistNPCPlayer>(mod).MemersRiposte == false)
			{
			damage = 1;
				if (crit)
				{
				damage = 2;
				}
			}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AlchemistNPCPlayer>(mod).MemersRiposte)
			{
			damage = 2;
				if (crit)
				{
				damage = 4;
				}
			}
		defense = 999999;
		return false;
		}
	}
}