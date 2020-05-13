using Terraria.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPC.Interface;
using AlchemistNPC;
using Terraria.UI;

namespace AlchemistNPC.Items
{
	public class AlchemistGlobalItem : GlobalItem
	{	
		public static bool on = false;
		public static bool stop = false;
		public static bool Luck = false;
		public static bool Luck2 = false;
		public static bool Menacing = false;
		public static bool Lucky = false;
		public static bool Violent = false;
		public static bool Warding = false;
		public static bool PerfectionToken = false;
		
		public override void HoldItem(Item item, Player player)
		{
			if (item.type == 2272 && NPC.AnyNPCs(mod.NPCType("Knuckles")))
			{
				item.damage = 1;
			}
			for (int j = 0; j < player.inventory.Length; j++)
			{
				if (player.inventory[j].type == mod.ItemType("DimensionalCasket"))
				{
					if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
					{
						Main.soundVolume = 1f; 
						DimensionalCasketUI.k = -1;
						DimensionalCasketUI.forcetalk = false;
					}
					if (DimensionalCasketUI.forcetalk == true)
					{
						Main.soundVolume = 0f; 
						Main.player[Main.myPlayer].talkNPC = DimensionalCasketUI.k;
					}
				}
			}
		}
		
		public override void UpdateInventory(Item item, Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BoomBox)
			{
				if (player.inventory[49].createTile != -1 && player.inventory[49].accessory)
				{
					bool r = false;
					player.VanillaUpdateAccessory(player.whoAmI, player.inventory[49], false, ref r, ref r, ref r);
				}
			}
			if (player.accCritterGuide && AlchemistNPC.modConfiguration.LifeformAnalyzer)
			{
				if(Main.GameUpdateCount % 60 == 0) 
				{
					for (int v = 0; v < 200; ++v)
					{
						NPC npc = Main.npc[v];
						if (npc.active && npc.rarity >= 1)
						{
							float num102 = 6f;
							float num103 = npc.Center.X + npc.width * 0.5f - player.Center.X;
							float num104 = npc.Center.Y + npc.height * 0.5f - player.Center.Y;
							float num105 = (float)Math.Sqrt((double)(num103 * num103 + num104 * num104));
							num105 = num102 / num105;
							num103 *= num105;
							num104 *= num105;
							Projectile.NewProjectile(player.Center.X, player.Center.Y, num103, num104, mod.ProjectileType("LocatorProjectile"), 0, 0f, player.whoAmI, v, 0f);
						}
					}
				}
			}
			if (item.type == mod.ItemType("LuckCharm"))
			{
				Luck = true;
			}
			if (item.type == mod.ItemType("LuckCharmT2"))
			{
				Luck = true;
				Luck2 = true;
			}
			if (item.type == mod.ItemType("PerfectionToken"))
			{
				PerfectionToken = true;
			}
			if (item.type == mod.ItemType("MenacingToken"))
			{
				Menacing = true;
			}
			if (item.type == mod.ItemType("LuckyToken"))
			{
				Lucky = true;
			}
			if (item.type == mod.ItemType("ViolentToken"))
			{
				Violent = true;
			}
			if (item.type == mod.ItemType("WardingToken"))
			{
				Warding = true;
			}
			Mod ALIB = ModLoader.GetMod("AchievementLib");
			if(ALIB != null)
			{
				if (item.type == mod.ItemType("Wellcheers"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Well, cheers!");
				}
				if (item.type == mod.ItemType("SpearofJustice"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Spear of Justice");
				}
				if (item.type == mod.ItemType("EyeOfJudgement"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "if you keep going the way you are now...");
				}
				if (item.type == mod.ItemType("EyeOfJudgementP"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "you're gonna have a bad time.");
				}
				if (item.type == mod.ItemType("MagicWand"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Don't worry, mom, I can handle it...");
				}
				if (item.type == mod.ItemType("DarkMagicWand"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Dip down!");
				}
				if (item.type == mod.ItemType("MarcoMagicWand"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Forbidden magic");
				}
				if (item.type == mod.ItemType("PandoraPF422"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Pandora's Box");
				}
				if (item.type == mod.ItemType("PortalGun"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Now you're thinking...");
				}
				if (item.type == mod.ItemType("TurretStaff"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Artificial unintelligence");
				}
				if (item.type == mod.ItemType("Akumu"))
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "The only thing to FEAR");
				}
			}
		}
		
		public override int ChoosePrefix(Item item, UnifiedRandom rand)
		{
			if (Luck == true && PerfectionToken == false)
			{
				if (item.melee)
				{
					if (Main.rand.Next(10) == 0)
					return 59;
				
					if (Main.rand.Next(20) == 0)
					return 81;
				}
				if (item.ranged && !item.consumable)
				{
					if (Main.rand.Next(10) == 0)
					return 20;
				
					if (Main.rand.Next(20) == 0)
					return 82;
				}
				if (item.magic)
				{
					if (Main.rand.Next(10) == 0)
					return 28;
				
					if (Main.rand.Next(20) == 0)
					return 83;
				}
				if (item.summon)
				{
					if (Main.rand.Next(10) == 0)
					return 57;
				
					if (Main.rand.Next(20) == 0)
					return 83;
				}
				if (item.thrown && !item.consumable)
				{
					if (Main.rand.Next(10) == 0)
					return 20;
				
					if (Main.rand.Next(20) == 0)
					return 82;
				}
			}
			if (Luck2 == true && !Menacing && !Lucky && !Violent && !Warding)
			{
				if (item.accessory)
				{
					if (Main.rand.Next(10) == 0)
					return 72;
				
					else if (Main.rand.Next(10) == 0)
					return 68;
				
					else if (Main.rand.Next(10) == 0)
					return 65;
				}
			}
			if (PerfectionToken == true)
			{
				if (item.type == mod.ItemType("LastTantrum"))
				{
					return 59;
				}
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (item.type == ModLoader.GetMod("CalamityMod").ItemType("P90"))
					{
						return 57;
					}
					if (item.type == ModLoader.GetMod("CalamityMod").ItemType("ColdheartIcicle"))
					{
						return 15;
					}
					if (item.type == ModLoader.GetMod("CalamityMod").ItemType("HalibutCannon"))
					{
						return 17;
					}
				}
				if (item.damage > 3 && item.useTime <= 4 && item.useAnimation <= 4 && item.maxStack == 1)
				{
					return mod.PrefixType("Ancient");
				}
				if (item.damage > 3 && item.melee && item.maxStack == 1)
				{
					return mod.PrefixType("Primal");
				}
				if (item.damage > 3 && item.magic && item.maxStack == 1)
				{
					return mod.PrefixType("Arcana");
				}
				if (item.damage > 3 && item.summon && item.maxStack == 1)
				{
					return mod.PrefixType("Demiurgic");
				}
				if (item.damage > 3 && (item.ranged || item.thrown) && item.maxStack == 1)
				{
					return mod.PrefixType("Immortal");
				}
				if (item.damage > 3)
				{
					if (item.melee)
					{
						return 81;
					}
					if (item.ranged && !item.consumable && item.useTime <= 3)
					{
						return 59;
					}
					if (item.ranged && !item.consumable && item.knockBack <= 0)
					{
						return 60;
					}
					if (item.ranged && !item.consumable && item.knockBack > 0)
					{
						return 82;
					}
					if (item.magic && item.knockBack <= 0)
					{
						return 60;
					}
					if (item.magic && item.useTime <= 2)
					{
						return 59;
					}
					if (item.magic && item.mana <= 4)
					{
						return 59;
					}
					if (item.magic && item.knockBack > 0)
					{
						return 83;
					}
					if (item.summon)
					{
						return 83;
					}
					if (item.thrown && !item.consumable && item.useTime <= 3)
					{
						return 59;
					}
					if (item.thrown && !item.consumable)
					{
						return 82;
					}
				}
			}
			if (item.accessory)
			{
				if (Menacing)
				{
					return 72;
				}
				if (Lucky)
				{
					return 68;
				}
				if (Violent)
				{
					return 80;
				}
				if (Warding)
				{
					return 65;
				}
			}
		return -1;
		}
		
		public override bool NewPreReforge(Item item)
		{
			Player player = Main.player[Main.myPlayer];
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("PerfectionToken")) && item.damage > 3)
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("PerfectionToken"))
					{
						inventory[k].stack--;
						return true;
					}
				}
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("MenacingToken")))
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("MenacingToken"))
					{
						inventory[k].stack--;
						return true;
					}
				}
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("LuckyToken")))
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("LuckyToken"))
					{
						inventory[k].stack--;
						return true;
					}
				}
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("ViolentToken")))
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("ViolentToken"))
					{
						inventory[k].stack--;
						return true;
					}
				}
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("WardingToken")))
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("WardingToken"))
					{
						inventory[k].stack--;
						return true;
					}
				}
			}	
			return base.NewPreReforge(item);
		}
		
		public override bool ConsumeItem(Item item, Player player)	
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier4 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
			{
				Mod Calamity = ModLoader.GetMod("CalamityMod");
				if (Calamity != null)
				{
					if ((bool)Calamity.Call("Downed", "supreme calamitas"))
					{
						return false;
					}
				}
				if (Main.rand.NextFloat() >= .25f)
				{
					return false;
				}
			}
			
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier3 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
			{
				if (Main.rand.Next(2) == 0)
				return false;
			}
			
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier2 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
			{
				if (Main.rand.Next(4) == 0)
				return false;
			}
			
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier1 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
			{
				if (Main.rand.Next(10) == 0)
				return false;
			}
			return true;
		}
		
		public override bool ConsumeAmmo(Item item, Player player)
		{
			if (player.HasBuff(mod.BuffType("DemonSlayer")))
			{
				return Main.rand.NextFloat() >= .25f;
			}
			return true;
		}
		
		public override float UseTimeMultiplier(Item item, Player player)	
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).GolemBooster == 1 && item.useTime > 3)
			{
				return 1.1f;
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Symbiote == true && item.useTime > 3)
			{
				if (!Main.hardMode)
				{
					return 1.1f;
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
					return 1.15f;
				}
				if (NPC.downedMoonlord)
				{
					return 1.2f;
				}
			}
			return base.UseTimeMultiplier(item, player);
		}
		
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.HasBuff(mod.BuffType("DemonSlayer")) && item.thrown && Main.rand.Next(3) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y-12, speedX, speedY, type, damage, knockBack, player.whoAmI);
			}
			if (modPlayer.Rampage == true && type == 14)
			{
				type = mod.ProjectileType("Chloroshard");
			}
			if (modPlayer.Rampage == true && type == 1)
			{
				type = mod.ProjectileType("ChloroshardArrow");
			}
			if (modPlayer.DeltaRune && item.melee && Main.rand.NextBool(20))
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("RedWave"), 1111, 1f, player.whoAmI);
			}
			if (modPlayer.DeltaRune && item.magic && Main.rand.NextBool(30))
			{
				float numberProjectiles = 9;
				float rotation = MathHelper.ToRadians(8);
				Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .5f;
					Projectile.NewProjectile(vector.X, vector.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("MM"), 1337, knockBack, player.whoAmI);
				}
			}
			if (modPlayer.Barrage)
			{
				Main.PlaySound(SoundID.Item91.WithVolume(.6f), player.position);
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
				int p = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("EnergyBall"), item.damage/5, 1f, player.whoAmI);
				if (item.useTime > 10)
				{
					Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
					Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, mod.ProjectileType("EnergyBall"), item.damage/4, 1f, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed3.X, perturbedSpeed3.Y, mod.ProjectileType("EnergyBall"), item.damage/4, 1f, player.whoAmI);
				}
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		
		public override bool UseItem(Item item, Player player)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (modPlayer.Barrage && item.damage > 0 && Main.GameUpdateCount % 6 == 0)
			{
				Main.PlaySound(SoundID.Item91.WithVolume(.6f), player.position);
				float num1 = 9f;
				Vector2 vector2 = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
				float f1 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float f2 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				if ((double)player.gravDir == -1.0)
					f2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
				float num4 = (float)Math.Sqrt((double)f1 * (double)f1 + (double)f2 * (double)f2);
				float num5;
				if (float.IsNaN(f1) && float.IsNaN(f2) || (double)f1 == 0.0 && (double)f2 == 0.0)
				{
					f1 = (float)player.direction;
					f2 = 0.0f;
					num5 = num1;
				}
				else
					num5 = num1 / num4;
				float SpeedX = f1 * num5;
				float SpeedY = f2 * num5;
				Vector2 perturbedSpeed = new Vector2(SpeedX, SpeedY).RotatedByRandom(MathHelper.ToRadians(5));
				Projectile.NewProjectile(vector2.X, vector2.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("EnergyBall"), item.damage/5, 1f, player.whoAmI);
			}
			if (item.type == 1991 || item.type == 3183)
			{
				for (int v = 0; v < 200; ++v)
				{
					NPC npc = Main.npc[v];
					if (npc.active && npc.townNPC)
					{
						if (AlchemistNPC.modConfiguration.CatchNPC)
						{
							if (npc.type == mod.NPCType("Alchemist"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("AlchemistHorcrux");
							}
							if (npc.type == mod.NPCType("Brewer"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("BrewerHorcrux");
							}
							if (npc.type == mod.NPCType("Architect"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("ArchitectHorcrux");
							}
							if (npc.type == mod.NPCType("Jeweler"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("JewelerHorcrux");
							}
							if (npc.type == mod.NPCType("Operator"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("APMC");
							}
							if (npc.type == mod.NPCType("OtherworldlyPortal"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("NotesBook");
							}
							if (npc.type == mod.NPCType("Explorer"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("RealityPiercer");
							}
							if (npc.type == mod.NPCType("Musician"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("MusicianHorcrux");
							}
							if (npc.type == mod.NPCType("Tinkerer"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("TinkererHorcrux");
							}
						}
						if (!AlchemistNPC.modConfiguration.CatchNPC)
						{
							if (npc.type == mod.NPCType("Alchemist"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Brewer"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Architect"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Jeweler"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Operator"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("OtherworldlyPortal"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Explorer"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Musician"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Tinkerer"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
						}
					}
				}
			}
			if (modPlayer.DeltaRune && item.melee && Main.rand.NextBool(100))
			{
				float num1 = 9f;
				Vector2 vector2 = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
				float f1 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float f2 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				if ((double)player.gravDir == -1.0)
					f2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
				float num4 = (float)Math.Sqrt((double)f1 * (double)f1 + (double)f2 * (double)f2);
				float num5;
				if (float.IsNaN(f1) && float.IsNaN(f2) || (double)f1 == 0.0 && (double)f2 == 0.0)
				{
					f1 = (float)player.direction;
					f2 = 0.0f;
					num5 = num1;
				}
				else
					num5 = num1 / num4;
				float SpeedX = f1 * num5;
				float SpeedY = f2 * num5;
				Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, mod.ProjectileType("RedWave"), 1111, 1f, player.whoAmI);
			}
			if (modPlayer.KeepBuffs == 1 && (item.buffTime > 0))
			{
				if (modPlayer.AlchemistCharmTier4)
				{
					player.AddBuff(item.buffType, item.buffTime*2 + ((item.buffTime*2)/2), true);
				}
				else if (modPlayer.AlchemistCharmTier3)
				{
					player.AddBuff(item.buffType, item.buffTime*2 + (((item.buffTime*2)/20)*7), true);
				}
				else if (modPlayer.AlchemistCharmTier2)
				{
					player.AddBuff(item.buffType, item.buffTime*2 + ((item.buffTime*2)/4), true);
				}
				else if (modPlayer.AlchemistCharmTier1)
				{
					player.AddBuff(item.buffType, item.buffTime*2 + ((item.buffTime*2)/10), true);
				}
				else player.AddBuff(item.buffType, item.buffTime*2, true);
			}
			if (modPlayer.KeepBuffs == 0 && (item.buffTime > 0))
			{
				if (modPlayer.AlchemistCharmTier4)
				{
					player.AddBuff(item.buffType, item.buffTime + (item.buffTime/2), true);
				}
				else if (modPlayer.AlchemistCharmTier3)
				{
					player.AddBuff(item.buffType, item.buffTime + ((item.buffTime/20)*7), true);
				}
				else if (modPlayer.AlchemistCharmTier2)
				{
					player.AddBuff(item.buffType, item.buffTime + (item.buffTime/4), true);
				}
				else if (modPlayer.AlchemistCharmTier1)
				{
					player.AddBuff(item.buffType, item.buffTime + (item.buffTime/10), true);
				}
			}
			return base.UseItem(item, player);
		}
		
		public override void PickAmmo(Item weapon, Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet && player.GetModPlayer<AlchemistNPCPlayer>().Rampage)
			{
				type = mod.ProjectileType("Chloroshard");
			}
			if (type == 1 && player.GetModPlayer<AlchemistNPCPlayer>().Rampage)
			{
				type = mod.ProjectileType("ChloroshardArrow");
			}
		}
		
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			string BillCipher = Language.GetTextValue("Mods.AlchemistNPC.BillCipher");
			string Knuckles = Language.GetTextValue("Mods.AlchemistNPC.Knuckles");
            //SBMW:Vanilla
            string KingSlime = Language.GetTextValue("Mods.AlchemistNPC.KingSlime");
            string EyeofCthulhu = Language.GetTextValue("Mods.AlchemistNPC.EyeofCthulhu");
            string EaterOfWorlds = Language.GetTextValue("Mods.AlchemistNPC.EaterOfWorlds");
            string BrainOfCthulhu = Language.GetTextValue("Mods.AlchemistNPC.BrainOfCthulhu");
            string QueenBee = Language.GetTextValue("Mods.AlchemistNPC.QueenBee");
            string Skeletron = Language.GetTextValue("Mods.AlchemistNPC.Skeletron");
            string WallOfFlesh = Language.GetTextValue("Mods.AlchemistNPC.WallOfFlesh");
            string Destroyer = Language.GetTextValue("Mods.AlchemistNPC.Destroyer");
            string Twins = Language.GetTextValue("Mods.AlchemistNPC.Twins");
            string SkeletronPrime = Language.GetTextValue("Mods.AlchemistNPC.SkeletronPrime");
            string Plantera = Language.GetTextValue("Mods.AlchemistNPC.Plantera");
            string Golem = Language.GetTextValue("Mods.AlchemistNPC.Golem");
			string Betsy = Language.GetTextValue("Mods.AlchemistNPC.Betsy");
            string DukeFishron = Language.GetTextValue("Mods.AlchemistNPC.DukeFishron");
            string MoonLord = Language.GetTextValue("Mods.AlchemistNPC.MoonLord");

            //SBMW:CalamityMod
            string DesertScourge = Language.GetTextValue("Mods.AlchemistNPC.DesertScourge");
            string Crabulon = Language.GetTextValue("Mods.AlchemistNPC.Crabulon");
            string HiveMind = Language.GetTextValue("Mods.AlchemistNPC.HiveMind");
            string Perforator = Language.GetTextValue("Mods.AlchemistNPC.Perforator");
            string SlimeGod = Language.GetTextValue("Mods.AlchemistNPC.SlimeGod");
            string Cryogen = Language.GetTextValue("Mods.AlchemistNPC.Cryogen");
            string BrimstoneElemental = Language.GetTextValue("Mods.AlchemistNPC.BrimstoneElemental");
            string AquaticScourge = Language.GetTextValue("Mods.AlchemistNPC.AquaticScourge");
            string Calamitas = Language.GetTextValue("Mods.AlchemistNPC.Calamitas");
            string AstrageldonSlime = Language.GetTextValue("Mods.AlchemistNPC.AstrageldonSlime");
            string AstrumDeus = Language.GetTextValue("Mods.AlchemistNPC.AstrumDeus");
            string Leviathan = Language.GetTextValue("Mods.AlchemistNPC.Leviathan");
            string PlaguebringerGoliath = Language.GetTextValue("Mods.AlchemistNPC.PlaguebringerGoliath");
            string Ravager = Language.GetTextValue("Mods.AlchemistNPC.Ravager");
            string Providence = Language.GetTextValue("Mods.AlchemistNPC.Providence");
            string Polterghast = Language.GetTextValue("Mods.AlchemistNPC.Polterghast");
			string OldDuke = Language.GetTextValue("Mods.AlchemistNPC.OldDuke");
            string DevourerofGods = Language.GetTextValue("Mods.AlchemistNPC.DevourerofGods");
            string Bumblebirb = Language.GetTextValue("Mods.AlchemistNPC.Bumblebirb");
            string Yharon = Language.GetTextValue("Mods.AlchemistNPC.Yharon");

            //SBMW:ThoriumMod
			string DarkMage = Language.GetTextValue("Mods.AlchemistNPC.DarkMage");
			string Ogre = Language.GetTextValue("Mods.AlchemistNPC.Ogre");
            string ThunderBird = Language.GetTextValue("Mods.AlchemistNPC.ThunderBird");
            string QueenJellyfish = Language.GetTextValue("Mods.AlchemistNPC.QueenJellyfish");
			string CountEcho = Language.GetTextValue("Mods.AlchemistNPC.CountEcho");
            string GraniteEnergyStorm = Language.GetTextValue("Mods.AlchemistNPC.GraniteEnergyStorm");
            string TheBuriedChampion = Language.GetTextValue("Mods.AlchemistNPC.TheBuriedChampion");
            string TheStarScouter = Language.GetTextValue("Mods.AlchemistNPC.TheStarScouter");
            string BoreanStrider = Language.GetTextValue("Mods.AlchemistNPC.BoreanStrider");
            string CoznixTheFallenBeholder = Language.GetTextValue("Mods.AlchemistNPC.CoznixTheFallenBeholder");
            string TheLich = Language.GetTextValue("Mods.AlchemistNPC.TheLich");
            string AbyssionTheForgottenOne = Language.GetTextValue("Mods.AlchemistNPC.AbyssionTheForgottenOne");
            string TheRagnarok = Language.GetTextValue("Mods.AlchemistNPC.TheRagnarok");
			
			//ElementsAwoken
			string Wasteland = Language.GetTextValue("Mods.AlchemistNPC.Wasteland");
			string Infernace = Language.GetTextValue("Mods.AlchemistNPC.Infernace");
			string ScourgeFighter = Language.GetTextValue("Mods.AlchemistNPC.ScourgeFighter");
			string Regaroth = Language.GetTextValue("Mods.AlchemistNPC.Regaroth");
			string TheCelestials = Language.GetTextValue("Mods.AlchemistNPC.TheCelestials");
			string Permafrost = Language.GetTextValue("Mods.AlchemistNPC.Permafrost");
			string Obsidious = Language.GetTextValue("Mods.AlchemistNPC.Obsidious");
			string Aqueous = Language.GetTextValue("Mods.AlchemistNPC.Aqueous");
			string TempleKeepers = Language.GetTextValue("Mods.AlchemistNPC.TempleKeepers");
			string Guardian = Language.GetTextValue("Mods.AlchemistNPC.Guardian");
			string Volcanox = Language.GetTextValue("Mods.AlchemistNPC.Volcanox");
			string VoidLevi = Language.GetTextValue("Mods.AlchemistNPC.VoidLevi");
			string Azana = Language.GetTextValue("Mods.AlchemistNPC.Azana");
			string Ancients = Language.GetTextValue("Mods.AlchemistNPC.Ancients");
			
			//Redemption
			string KingChicken = Language.GetTextValue("Mods.AlchemistNPC.KingChicken");
			string ThornBane = Language.GetTextValue("Mods.AlchemistNPC.ThornBane");
			string TheKeeper = Language.GetTextValue("Mods.AlchemistNPC.TheKeeper");
			string XenoCrystal = Language.GetTextValue("Mods.AlchemistNPC.XenoCrystal");
			string IEye = Language.GetTextValue("Mods.AlchemistNPC.IEye");
			string KingSlayer = Language.GetTextValue("Mods.AlchemistNPC.KingSlayer");
			string V1 = Language.GetTextValue("Mods.AlchemistNPC.V1");
			string V2 = Language.GetTextValue("Mods.AlchemistNPC.V2");
			string V3 = Language.GetTextValue("Mods.AlchemistNPC.V3");
			string PZ = Language.GetTextValue("Mods.AlchemistNPC.PZ");
			string ThornRematch = Language.GetTextValue("Mods.AlchemistNPC.ThornRematch");
			string Nebuleus = Language.GetTextValue("Mods.AlchemistNPC.Nebuleus");
			
			//SacredTools
			string Decree = Language.GetTextValue("Mods.AlchemistNPC.Decree");
			string FlamingPumpkin = Language.GetTextValue("Mods.AlchemistNPC.FlamingPumpkin");
            string Jensen = Language.GetTextValue("Mods.AlchemistNPC.Jensen");
			string Araneas = Language.GetTextValue("Mods.AlchemistNPC.Araneas");
			string Raynare = Language.GetTextValue("Mods.AlchemistNPC.Raynare");
			string Primordia = Language.GetTextValue("Mods.AlchemistNPC.Primordia");
            string Abaddon = Language.GetTextValue("Mods.AlchemistNPC.Abaddon");
            string Araghur = Language.GetTextValue("Mods.AlchemistNPC.Araghur");
            string Lunarians = Language.GetTextValue("Mods.AlchemistNPC.Lunarians");
            string Challenger = Language.GetTextValue("Mods.AlchemistNPC.Challenger");
			string Spookboi = Language.GetTextValue("Mods.AlchemistNPC.Spookboi");
			
			//SpiritMod
			string Scarabeus = Language.GetTextValue("Mods.AlchemistNPC.Scarabeus");
            string Bane = Language.GetTextValue("Mods.AlchemistNPC.Bane");
			string Flier = Language.GetTextValue("Mods.AlchemistNPC.Flier");
            string Raider = Language.GetTextValue("Mods.AlchemistNPC.Raider");
            string Infernon = Language.GetTextValue("Mods.AlchemistNPC.Infernon");
            string Dusking = Language.GetTextValue("Mods.AlchemistNPC.Dusking");
            string EtherialUmbra = Language.GetTextValue("Mods.AlchemistNPC.EtherialUmbra");
			string IlluminantMaster = Language.GetTextValue("Mods.AlchemistNPC.IlluminantMaster");
			string Atlas = Language.GetTextValue("Mods.AlchemistNPC.Atlas");
			string Overseer = Language.GetTextValue("Mods.AlchemistNPC.Overseer");
			
			//Enigma
			string Sharkron = Language.GetTextValue("Mods.AlchemistNPC.Sharkron");
            string Hypothema = Language.GetTextValue("Mods.AlchemistNPC.Hypothema");
			string Ragnar = Language.GetTextValue("Mods.AlchemistNPC.Ragnar");
            string AnDio = Language.GetTextValue("Mods.AlchemistNPC.AnDio");
            string Annihilator = Language.GetTextValue("Mods.AlchemistNPC.Annihilator");
            string Slybertron = Language.GetTextValue("Mods.AlchemistNPC.Slybertron");
            string SteamTrain = Language.GetTextValue("Mods.AlchemistNPC.SteamTrain");
			
			//pinky
			string SunlightTrader = Language.GetTextValue("Mods.AlchemistNPC.SunlightTrader");
            string THOFC = Language.GetTextValue("Mods.AlchemistNPC.THOFC");
			string MythrilSlime = Language.GetTextValue("Mods.AlchemistNPC.MythrilSlime");
            string Valdaris = Language.GetTextValue("Mods.AlchemistNPC.Valdaris");
            string Gatekeeper = Language.GetTextValue("Mods.AlchemistNPC.Gatekeeper");
			
			//AAMod
			string Monarch = Language.GetTextValue("Mods.AlchemistNPC.Monarch");
            string Grips = Language.GetTextValue("Mods.AlchemistNPC.Grips");
			string Broodmother = Language.GetTextValue("Mods.AlchemistNPC.Broodmother");
            string Hydra = Language.GetTextValue("Mods.AlchemistNPC.Hydra");
			string Serpent = Language.GetTextValue("Mods.AlchemistNPC.Serpent");
            string Djinn = Language.GetTextValue("Mods.AlchemistNPC.Djinn");
			string Retriever = Language.GetTextValue("Mods.AlchemistNPC.Retriever");
			string RaiderU = Language.GetTextValue("Mods.AlchemistNPC.RaiderU");
			string Orthrus = Language.GetTextValue("Mods.AlchemistNPC.Orthrus");
			string EFish = Language.GetTextValue("Mods.AlchemistNPC.EFish");
			string Nightcrawler = Language.GetTextValue("Mods.AlchemistNPC.Nightcrawler");
			string Daybringer = Language.GetTextValue("Mods.AlchemistNPC.Daybringer");
			string Yamata = Language.GetTextValue("Mods.AlchemistNPC.Yamata");
			string Akuma = Language.GetTextValue("Mods.AlchemistNPC.Akuma");
			string Zero = Language.GetTextValue("Mods.AlchemistNPC.Zero");
			string Shen = Language.GetTextValue("Mods.AlchemistNPC.Shen");
			string ShenGrips = Language.GetTextValue("Mods.AlchemistNPC.ShenGrips");
			
			
			if (item.type == mod.ItemType("KnucklesBag"))
			{
				TooltipLine line = new TooltipLine(mod, "Knuckles", Knuckles);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == mod.ItemType("BillCipherBag"))
			{
				TooltipLine line = new TooltipLine(mod, "BillCipher", BillCipher);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
            if (item.type == ItemID.KingSlimeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "KingSlime", KingSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.EyeOfCthulhuBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "EyeofCthulhu", EyeofCthulhu);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.EaterOfWorldsBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "EaterOfWorlds", EaterOfWorlds);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.BrainOfCthulhuBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "BrainOfCthulhu", BrainOfCthulhu);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.QueenBeeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "QueenBeeBossBag", QueenBee);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.SkeletronBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Skeletron", Skeletron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.WallOfFleshBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "WallOfFleshBoss", WallOfFlesh);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.DestroyerBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Destroyer", Destroyer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.TwinsBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Twins", Twins);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.SkeletronPrimeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "SkeletronPrime", SkeletronPrime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.PlanteraBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Plantera", Plantera);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.GolemBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Golem", Golem);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.BossBagBetsy)
			{
				TooltipLine line = new TooltipLine(mod, "Betsy", Betsy);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.FishronBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "DukeFishron", DukeFishron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.MoonLordBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "MoonLord", MoonLord);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DesertScourge", DesertScourge);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Crabulon", Crabulon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag")))
				{
				TooltipLine line = new TooltipLine(mod, "HiveMind", HiveMind);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Perforator", Perforator);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SlimeGod", SlimeGod);

                line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Cryogen", Cryogen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag")))
				{
				TooltipLine line = new TooltipLine(mod, "BrimstoneElemental", BrimstoneElemental);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AquaticScourge", AquaticScourge);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Calamitas", Calamitas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AstrageldonSlime", AstrageldonSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AstrumDeus", AstrumDeus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Leviathan", Leviathan);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag")))
				{
				TooltipLine line = new TooltipLine(mod, "PlaguebringerGoliath", PlaguebringerGoliath);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ravager", Ravager);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Providence", Providence);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Polterghast", Polterghast);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("OldDukeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "OldDuke", OldDuke);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DevourerofGods", DevourerofGods);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Bumblebirb", Bumblebirb);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("YharonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Yharon", Yharon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DarkMage", DarkMage);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ogre", Ogre);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ThunderBird", ThunderBird);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag")))
				{
				TooltipLine line = new TooltipLine(mod, "QueenJellyfish", QueenJellyfish);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("CountBag")))
				{
				TooltipLine line = new TooltipLine(mod, "CountEcho", CountEcho);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag")))
				{
				TooltipLine line = new TooltipLine(mod, "GraniteEnergyStorm", GraniteEnergyStorm);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheBuriedChampion", TheBuriedChampion);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheStarScouter", TheStarScouter);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "BoreanStrider", BoreanStrider);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "CoznixTheFallenBeholder", CoznixTheFallenBeholder);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("LichBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheLich", TheLich);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AbyssionTheForgottenOne", AbyssionTheForgottenOne);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("RagBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheRagnarok", TheRagnarok);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("AAMod") != null)
			{
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("MonarchBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Monarch", Monarch);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Grips", Grips);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("BroodBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Broodmother", Broodmother);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("HydraBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Hydra", Hydra);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("SerpentBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Serpent", Serpent);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("DjinnBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Djinn", Djinn);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("RetrieverBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Retriever", Retriever);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("RaiderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "RaiderU", RaiderU);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("OrthrusBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Orthrus", Orthrus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("EFishBag")))
				{
				TooltipLine line = new TooltipLine(mod, "EFish", EFish);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("DBBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Daybringer", Daybringer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("NCBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Nightcrawler", Nightcrawler);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("YamataBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Yamata", Yamata);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("AkumaBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Akuma", Akuma);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("ZeroBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Zero", Zero);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("ShenCache")))
				{
				TooltipLine line = new TooltipLine(mod, "Shen", Shen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripSBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ShenGrips", ShenGrips);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("ElementsAwoken") != null)
			{
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Wasteland", Wasteland);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Infernace", Infernace);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ScourgeFighter", ScourgeFighter);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Regaroth", Regaroth);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("TheCelestialBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheCelestials", TheCelestials);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Permafrost", Permafrost);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Obsidious", Obsidious);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Aqueous", Aqueous);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TempleKeepers", TempleKeepers);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Guardian", Guardian);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("VolcanoxBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Volcanox", Volcanox);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "VoidLevi", VoidLevi);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Azana", Azana);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ancients", Ancients);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("KingChickenBag")))
				{
				TooltipLine line = new TooltipLine(mod, "KingChicken", KingChicken);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("ThornBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ThornBane", ThornBane);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("TheKeeperBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheKeeper", TheKeeper);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag")))
				{
				TooltipLine line = new TooltipLine(mod, "XenoCrystal", XenoCrystal);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("InfectedEyeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "IEye", IEye);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("SlayerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "KingSlayer", KingSlayer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("VlitchCleaverBag")))
				{
				TooltipLine line = new TooltipLine(mod, "V1", V1);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("VlitchGigipedeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "V2", V2);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("OmegaOblitBag")))
				{
				TooltipLine line = new TooltipLine(mod, "V3", V3);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("PZBag")))
				{
				TooltipLine line = new TooltipLine(mod, "PZ", PZ);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("ThornPZBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ThornRematch", ThornRematch);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("NebBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Nebuleus", Nebuleus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("SacredTools") != null)
			{
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("DecreeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Decree", Decree);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag")))
				{
				TooltipLine line = new TooltipLine(mod, "FlamingPumpkin", FlamingPumpkin);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Jensen", Jensen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("AraneasBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Araneas", Araneas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2")))
				{
				TooltipLine line = new TooltipLine(mod, "Raynare", Raynare);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PrimordiaBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Primordia", Primordia);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("OblivionBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Abaddon", Abaddon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SerpentBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Araghur", Araghur);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("LunarBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Lunarians", Lunarians);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Challenger", Challenger);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SpookboiBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Spookboi", Spookboi);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("SpiritMod") != null)
			{
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs")))
				{
				TooltipLine line = new TooltipLine(mod, "Scarabeus", Scarabeus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Bane", Bane);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Flier", Flier);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Raider", Raider);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Infernon", Infernon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Dusking", Dusking);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag")))
				{
				TooltipLine line = new TooltipLine(mod, "EqualityComparer", EtherialUmbra);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag")))
				{
				TooltipLine line = new TooltipLine(mod, "IlluminantMaster", IlluminantMaster);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Atlas", Atlas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Overseer", Overseer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("Laugicality") != null)
			{
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Sharkron", Sharkron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Hypothema", Hypothema);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ragnar", Ragnar);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AnDio", AnDio);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Annihilator", Annihilator);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Slybertron", Slybertron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SteamTrain", SteamTrain);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("pinkymod") != null)
			{
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("STBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SunlightTrader", SunlightTrader);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "THOFC", THOFC);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("MythrilBag")))
				{
				TooltipLine line = new TooltipLine(mod, "MythrilSlime", MythrilSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("Valdabag")))
				{
				TooltipLine line = new TooltipLine(mod, "Valdaris", Valdaris);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Gatekeeper", Gatekeeper);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
		}
		
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("TimeTwistBraclet"));
			}
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SuspiciousLookingScythe"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("HeartofYuiS"));
			}
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("StatsChecker"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(200) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BanHammer"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("PinkGuyHead"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyBody"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyLegs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BlackCatHead"));
				player.QuickSpawnItem(mod.ItemType("BlackCatBody"));
				player.QuickSpawnItem(mod.ItemType("BlackCatLegs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Skyline222Hair"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Body"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Legs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("somebody0214Hood"));
				player.QuickSpawnItem(mod.ItemType("somebody0214Robe"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(250) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BloodMoonCirclet"));
				player.QuickSpawnItem(mod.ItemType("BloodMoonDress"));
				player.QuickSpawnItem(mod.ItemType("BloodMoonStockings"));
			}
			if (NPC.downedMoonlord && context == "bossBag" && Main.rand.Next(300) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("StrangeTopHat"));
			}
		}
		
		public override void VerticalWingSpeeds(Item item, Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) 
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (modPlayer.BetsyBooster == 1)
			{
				maxCanAscendMultiplier += 1f;
				maxAscentMultiplier += 1f;
			}
		}
		
		public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)	
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (modPlayer.BetsyBooster == 1)
			{
				speed += 0.1f;
				acceleration += 0.1f;
			}
			if (player.HasBuff(mod.BuffType("Exhausted")))
			{
			speed *= 0.8f;
			acceleration *= 0.8f;
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime >= 390)
			{
			speed *= 0.75f;
			acceleration *= 0.75f;
			}
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime >= 210)
			{
			speed *= 0.9f;
			acceleration *= 0.9f;
			}
		}
		
		public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
	}
}
