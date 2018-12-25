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
using Terraria.ModLoader.IO;
using AlchemistNPC;
using AlchemistNPC.NPCs;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadBossHead]
	class BillCipher : ModNPC
	{
		public static int introduction = 0;
		public static int counter = 0;
		public static int counter2 = 0;
		public static int counter3 = 0;
		public static int counter4 = 0;
		public static int counter5 = 0;
		
		public override void SetDefaults()
		{
			npc.boss = true;
			npc.width = 82;
			npc.height = 70;
			npc.damage = 800;
			npc.defense = 20;
			npc.lifeMax = 333333;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 333f;
			npc.knockBackResist = -1;
			npc.aiStyle = 5;
			npc.noTileCollide = true;
			npc.noGravity = true;
			aiType = 9;
			music = MusicID.Boss2;
			bossBag = mod.ItemType("BillCipherBag");
		}
		
		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Bill Cipher");
		Main.npcFrameCount[npc.type] = 6;
		}
		
		public override void BossHeadRotation(ref float rotation)
        {
            rotation = 0;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		
		public override void AI()
		{
			Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
			Main.dayTime = false;
			Main.monolithType = 3;
			Main.time = 0.0;
			counter4++;
			if (npc.life < npc.lifeMax && counter4 >= 2)
			{
				npc.life++;
				counter4 = 0;
			}
			if (npc.velocity.X < 0)
			{
				npc.rotation = 1.25f;
				npc.spriteDirection = -1;
			}
			else
			{
				npc.rotation = -1.25f;
				npc.spriteDirection = 1;
			}
			if (introduction >= 300)
			{
				counter5++;
				if (counter5 == 1)
				{
					Vector2 delta = player.Center - npc.Center;
					float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
					if (magnitude > 0)
					{
						delta *= (5f / magnitude);
					}
					else
					{
						delta = new Vector2(0f, 5f);
					}
					delta *= 2f;
					npc.velocity = delta;
				}
				if (counter5 == 60)
				{
					Vector2 delta = player.Center - npc.Center;
					float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
					if (magnitude > 0)
					{
						delta *= (5f / magnitude);
					}
					else
					{
						delta = new Vector2(0f, 5f);
					}
					delta *= 2f;
					npc.velocity = delta;
				}
				if (counter5 == 120)
				{
					Vector2 delta = player.Center - npc.Center;
					float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
					if (magnitude > 0)
					{
						delta *= (5f / magnitude);
					}
					else
					{
						delta = new Vector2(0f, 5f);
					}
					delta *= 2f;
					npc.velocity = delta;
				}
				if (counter5 == 600)
				{
				counter5 = 0;
				}
			}
			float TPX = npc.position.X + npc.width * 0.5f - player.Center.X;
            float TPY = npc.position.Y + npc.height * 0.5f - player.Center.Y;
            float distance = (float)Math.Sqrt(TPX * TPX + TPY * TPY);
			if (player.name == "Bill")
			{
				if (introduction < 1)
				{
				Main.NewText("What? Are you my namesake? Well, I don't want to fight you.", 10, 255, 10);
				Main.NewText("Here, catch my present! Bye!", 10, 255, 10);
				player.QuickSpawnItem(mod.ItemType("BillCipherBag"));
				}
				npc.boss = false;
				npc.velocity = new Vector2(0, -10);
				npc.velocity *= 3f;
				
			}
			if (distance > 2500f && introduction >= 300)
			{
				Main.NewText("Don't think that you can hide from me, mortal!", 10, 255, 10);
				switch(Main.rand.Next(2))
				{
					case 0:
					npc.Center = player.Center - new Vector2(350, 100);
					break;
					case 1:
					npc.Center = player.Center - new Vector2(-350, -100);
					break;
				}
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
				player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("AbyssalShell")] = true;
				npc.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("AParalyzed")] = true;
				npc.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("Paralyzed")] = true;
			}
			npc.buffImmune[mod.BuffType("ArmorDestruction")] = true;
			npc.buffImmune[mod.BuffType("Twilight")] = true;
			npc.buffImmune[mod.BuffType("Electrocute")] = true;
			npc.buffImmune[mod.BuffType("Patience")] = true;
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("SilvaStun")] = true;
				npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("ExoFreeze")] = true;
			}
			int damage1 = 200;
			int damage2 = 150;
			int damage3 = 250;
			if (introduction < 300)
			{
				npc.dontTakeDamage = true;
			}
			if (npc.life > npc.lifeMax/2 && !player.dead && !npc.GetGlobalNPC<ModGlobalNPC>(mod).intermission1)
			{
				introduction++;
				
				if (introduction > 300)
				{
					npc.dontTakeDamage = false;
					if (counter2 >= 10)
					{
						counter2 = 0;
						Vector2 delta = player.Center - npc.Center;
						float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
						if (magnitude > 0)
						{
							delta *= (5f / magnitude);
						}
						else
						{
							delta = new Vector2(0f, 5f);
						}
						delta *= 4f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X, delta.Y, mod.ProjectileType("DeadlyLaser"), 500, 0, Main.myPlayer);
					}
					if (counter >= 20)
					{
						counter = 0;
						Vector2 delta = player.Center - npc.Center;
						float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
						if (magnitude > 0)
						{
							delta *= 5f / magnitude;
						}
						else
						{
							delta = new Vector2(0f, 5f);
						}
						delta *= 1.8f;
						Vector2 delta2 = delta.RotatedByRandom(MathHelper.ToRadians(15));
						Vector2 delta3 = delta.RotatedByRandom(MathHelper.ToRadians(15));
						Vector2 delta4 = delta.RotatedByRandom(MathHelper.ToRadians(35));
						Vector2 delta5 = delta.RotatedByRandom(MathHelper.ToRadians(35));
						Vector2 delta6 = delta.RotatedByRandom(MathHelper.ToRadians(50));
						Vector2 delta7 = delta.RotatedByRandom(MathHelper.ToRadians(50));
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X, delta.Y, 100, damage1, 0, Main.myPlayer);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta2.X, delta2.Y, 100, damage1, 0, Main.myPlayer);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta3.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta4.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta5.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta6.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta7.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
					}
					counter++;
					counter2++;
				}
			}
			if (npc.life < npc.lifeMax/2 && npc.life > npc.lifeMax*0.15f && !player.dead && !npc.GetGlobalNPC<ModGlobalNPC>(mod).intermission2)
			{
				player.AddBuff((mod.BuffType("Madness")), 2);
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					if (CalamityModRevengeance)
					{
						counter3++;
						if (counter3 <= 900)
						{
							player.gravDir = -1f;
						}
						if (counter3 > 900 && counter3 <= 1800)
						{
							player.gravDir = 1f;
						}
						if (counter3 > 1800)
						{
							counter3 = 0;
						}
					}
				}
				if (counter >= 15)
				{
					counter = 0;
					Vector2 delta = player.Center - npc.Center;
					float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
					if (magnitude > 0)
					{
						delta *= (5f / magnitude);
					}
					else
					{
						delta = new Vector2(0f, 5f);
					}
					delta *= 2f;
					Vector2 delta2 = delta.RotatedByRandom(MathHelper.ToRadians(20));
					Vector2 delta3 = delta.RotatedByRandom(MathHelper.ToRadians(20));
					Vector2 delta4 = delta.RotatedByRandom(MathHelper.ToRadians(15));
					Vector2 delta5 = delta.RotatedByRandom(MathHelper.ToRadians(15));
					Vector2 delta6 = delta.RotatedByRandom(MathHelper.ToRadians(10));
					Vector2 delta7 = delta.RotatedByRandom(MathHelper.ToRadians(10));
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X, delta.Y, mod.ProjectileType("DeadlyLaser"), 500, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta2.X, delta2.Y, 100, damage2, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta3.X, delta3.Y, 100, damage2, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta4.X, delta4.Y, 100, damage2, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta5.X, delta5.Y, 100, damage2, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta6.X, delta7.Y, mod.ProjectileType("DeadlyLaser"), 500, 0, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta6.X, delta7.Y, mod.ProjectileType("DeadlyLaser"), 500, 0, Main.myPlayer);
				}
				counter++;
			}
			if (npc.life < npc.lifeMax*0.15f && !player.dead)
			{
				player.AddBuff((mod.BuffType("Madness")), 2);
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					if (CalamityModRevengeance)
					{
						counter3++;
						if (counter3 <= 900)
						{
							player.gravDir = -1f;
						}
						if (counter3 > 900 && counter3 <= 1800)
						{
							player.gravDir = 1f;
						}
						if (counter3 > 1800)
						{
							counter3 = 0;
						}
					}
				}
				if (counter2 >= 20)
				{
					for (int i = 0; i < 10; i++)
					{
					int dustType = Main.rand.Next(51, 54);
					int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 0.8f;
					dust.noGravity = true;
					}
				}
				if (counter2 >= 40)
				{
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 62);
					counter2 = 0;
					Vector2 delta = player.Center - npc.Center;
					float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
					if (magnitude > 0)
					{
						delta *= (5f / magnitude);
					}
					else
					{
						delta = new Vector2(0f, 5f);
					}
					delta *= 6f;
					float numberProjectiles = 15;
					float rotation = MathHelper.ToRadians(2);
					delta += Vector2.Normalize(new Vector2(delta.X, delta.Y)) * 45f;
					for (int i = 0; i < numberProjectiles; i++)
					{
						Vector2 perturbedSpeed = new Vector2(delta.X, delta.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Vaporizer"), damage3, 0, player.whoAmI);
					}
				}
				counter2++;
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (CalamityModRevengeance)
				{
					RnAReset(player);
				}
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).CursedMirror == true)
			{
				npc.reflectingProjectiles = true;
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).CursedMirror == false)
			{
				npc.reflectingProjectiles = false;
			}
		}
		
		private void RnAReset(Player player)
		{
			CalamityMod.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalamityPlayer>(Calamity);
			CalamityPlayer.stress = 0;
			CalamityPlayer.adrenaline = 0;
		}
		
		public override void ModifyHitPlayer(Player player, ref int damage, ref bool crit)
		{
		player.buffImmune[mod.BuffType("MindBurn")] = false;
		player.AddBuff(mod.BuffType("MindBurn"), 1200);
		}
		
		public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Voodoo == true)
			{
				player.statLife--;
			}
		}
		
		public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
		{
			Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Voodoo == true)
			{
				player.statLife--;
			}
		}
		
		public bool CalamityModRevengeance
		{
        get { return CalamityMod.CalamityWorld.revenge; }
        }
		
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		const int Frame_P11 = 0;
		const int Frame_P12 = 1;
		const int Frame_P13 = 2;
		const int Frame_P21 = 3;
		const int Frame_P22 = 4;
		const int Frame_P23 = 5;
		
		public override void FindFrame(int frameHeight)
		{
			if (!npc.GetGlobalNPC<ModGlobalNPC>(mod).phase2)
			{
				npc.frameCounter++;
				if (npc.frameCounter < 100)
				{
					npc.frame.Y = Frame_P11 * frameHeight;
				}
				else if (npc.frameCounter < 115)
				{
					npc.frame.Y = Frame_P12 * frameHeight;
				}
				else if (npc.frameCounter < 120)
				{
					npc.frame.Y = Frame_P13 * frameHeight;
				}
				else if (npc.frameCounter < 125)
				{
					npc.frame.Y = Frame_P12 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
			if (npc.GetGlobalNPC<ModGlobalNPC>(mod).phase2)
			{
				npc.frameCounter++;
				if (npc.frameCounter < 100)
				{
					npc.frame.Y = Frame_P21 * frameHeight;
				}
				else if (npc.frameCounter < 115)
				{
					npc.frame.Y = Frame_P22 * frameHeight;
				}
				else if (npc.frameCounter < 120)
				{
					npc.frame.Y = Frame_P23 * frameHeight;
				}
				else if (npc.frameCounter < 125)
				{
					npc.frame.Y = Frame_P22 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
		}
		
		public virtual void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit) 
		{
			if (npc.life > npc.lifeMax/10)
			{
				damage /= 10;
			}
			if (npc.life < npc.lifeMax/10)
			{
				damage /= 20;
			}
		}
		
		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int	hitDirection)	
		{
			if (npc.life > npc.lifeMax/10)
			{
				damage /= 10;
			}
			if (npc.life < npc.lifeMax/10)
			{
				damage /= 20;
			}
			if (projectile.type == mod.ProjectileType("QuantumDestabilizer"))
			{
				damage *= 5;
			}
		}
		
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GoldenKnuckles"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WrathOfTheCelestial"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LaserCannon"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GrapplingHookGunItem"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlatinumCoin, 50);
			}
			Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BillIsDowned < 1)
			{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BillIsDowned++;
			}
		}
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.SuperHealingPotion;
		}
	}
}