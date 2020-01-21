using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPC;
using AlchemistNPC.NPCs;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadBossHead]
	class Knuckles : ModNPC
	{
		public override void SetDefaults()
		{
			npc.boss = true;
			npc.width = 96;
			npc.height = 76;
			npc.damage = 666666;
			npc.defense = 666666;
			npc.lifeMax = 333333;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 333f;
			npc.knockBackResist = -1f;
			music = MusicID.Boss2;
			npc.noTileCollide = true;
			bossBag = mod.ItemType("KnucklesBag");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ugandan Knuckles");
		}
		
		public override void BossHeadRotation(ref float rotation)
        {
            rotation = npc.rotation;
        }
		
		public override void AI()
		{
			if (Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].dead)
				{
					npc.timeLeft = 0;
				}
			}
			if (!Main.player[npc.target].dead)
			{
				npc.rotation += (float)npc.direction * 0.3f;
				Vector2 vector21 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num177 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector21.X;
				float num178 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector21.Y;
				float num179 = (float)Math.Sqrt((double)(num177 * num177 + num178 * num178));
				num179 = 12f / num179;
				npc.velocity.X = num177 * num179;
				npc.velocity.Y = num178 * num179;
			}
			
			int damage1 = 200;
			int damage2 = 300;
			int damage3 = 350;
			npc.buffImmune[mod.BuffType("ArmorDestruction")] = true;
			npc.buffImmune[mod.BuffType("Twilight")] = true;
			npc.buffImmune[mod.BuffType("Electrocute")] = true;
			npc.buffImmune[mod.BuffType("Patience")] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[69] = true;
			npc.buffImmune[203] = true;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				npc.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("AParalyzed")] = true;
				npc.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("Paralyzed")] = true;
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("SilvaStun")] = true;
				npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("GlacialState")] = true;
				npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("ExoFreeze")] = true;
				npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("MarkedforDeath")] = true;
				npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("HolyInferno")] = true;
				npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("HolyFlames")] = true;
			}
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					if (ModLoader.GetMod("ThoriumMod") != null)
					{
						player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("AbyssalShell")] = true;
					}
					if (ModGlobalNPC.ks == true)
					{
						if (player.GetModPlayer<AlchemistNPCPlayer>().MemersRiposte)
						{
							damage1 = 100;
							damage2 = 150;
							damage3 = 175;
						}
					}
				}
			}
			if (!Main.expertMode && ModGlobalNPC.ks)
			{
				if (npc.life > 166666)
				{
					if (Main.rand.Next(20) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
					}
				}
				else
				{
					if (Main.rand.Next(25) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 449, damage2, 0, Main.myPlayer);
					}
					if (Main.rand.Next(60) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 448, damage2, 0, Main.myPlayer);
					}
				}
			}
			if (Main.expertMode && ModGlobalNPC.ks)
			{
				if (npc.life > 333333)
				{
					if (Main.rand.Next(20) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 8f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, mod.ProjectileType("DeadlyLaser"), damage1, 0, Main.myPlayer);
					}
				}
				if (npc.life > 166666 && npc.life < 333333)
				{
					if (Main.rand.Next(25) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 449, damage2, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 9f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 449, damage2, 0, Main.myPlayer);
					}
					if (Main.rand.Next(60) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 448, damage2, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 448, damage2, 0, Main.myPlayer);
					}
				}
				if (npc.life < 166666)
				{
					if (Main.rand.Next(20) == 0)
					{
						Vector2 vel = new Vector2(-1, -1);
						vel *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel2 = new Vector2(1, 1);
						vel2 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel3 = new Vector2(1, -1);
						vel3 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel4 = new Vector2(-1, 1);
						vel4 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel5 = new Vector2(0, -1);
						vel5 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel6 = new Vector2(0, 1);
						vel6 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel7 = new Vector2(1, 0);
						vel7 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 449, damage3, 0, Main.myPlayer);
						Vector2 vel8 = new Vector2(-1, 0);
						vel8 *= 12f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 449, damage3, 0, Main.myPlayer);
					}
				if (Main.rand.Next(50) == 0)
				{
					Vector2 vel = new Vector2(-1, -1);
					vel *= 14f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel2 = new Vector2(1, 1);
					vel2 *= 14f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel2.X, vel2.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel3 = new Vector2(1, -1);
					vel3 *= 14f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel3.X, vel3.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel4 = new Vector2(-1, 1);
					vel4 *= 14f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel4.X, vel4.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel5 = new Vector2(0, -1);
					vel5 *= 14f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel5.X, vel5.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel6 = new Vector2(0, 1);
					vel6 *= 14f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel6.X, vel6.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel7 = new Vector2(1, 0);
					vel7 *= 14f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel7.X, vel7.Y, 448, damage3, 0, Main.myPlayer);
					Vector2 vel8 = new Vector2(-1, 0);
					vel8 *= 14f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel8.X, vel8.Y, 448, damage3, 0, Main.myPlayer);
					}
				}
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return -1f;
		}
		
		public override void ModifyHitPlayer(Player player, ref int damage, ref bool crit)
		{
			player.AddBuff(mod.BuffType("TrueUganda"), 1200);
			damage = 666666;
		}
		
		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int	hitDirection)	
		{
			if (projectile.type == 358)
			{
				npc.life = 1;
				damage = 999999999;
			}
		}
		
		public override void NPCLoot()
		{
			Mod ALIB = ModLoader.GetMod("AchievementLib");
			if(ALIB != null)
			{
				ALIB.Call("UnlockGlobal", "AlchemistNPC", "Da wae is clear, to the queen!");
			}
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EdgeOfChaos"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LastTantrum"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BreathOfTheVoid"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosBomb"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UgandanTotem"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlatinumCoin, 20);
			}
		}
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.SuperHealingPotion;
		}
	}
}