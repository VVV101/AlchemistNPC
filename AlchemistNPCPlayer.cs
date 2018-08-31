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
using AlchemistNPC.Items;

namespace AlchemistNPC
{
	public class AlchemistNPCPlayer : ModPlayer
	{
		public bool Luck = false;
		public bool AutoinjectorMK2 = false;
		public bool AlchemistCharmTier1 = false;
		public bool AlchemistCharmTier2 = false;
		public bool AlchemistCharmTier3 = false;
		public bool AlchemistCharmTier4 = false;
		public bool BeeHeal = false;
		public bool Pandora = false;
		public bool TS = false;
		public bool Symbiote = false;
		public bool Akumu = false;
		public bool DriedFish = false;
		public bool SolarFish = false;
		public bool NebulaFish = false;
		public bool VortexFish = false;
		public bool StardustFish = false;
		public bool MiniShark = false;
		public bool Manna = false;
		public bool Traps = false;
		public bool Yui = false;
		public bool YuiS = false;
		public bool Extractor = false;
		public bool Scroll = false;
		public bool EyeOfJudgement = false;
		public bool LaetitiaSet = false;
		public bool SFU = false;
		public bool SF = false;
		public bool PGSWear = false;
		public bool RevSet = false;
		public bool XtraT = false;
		public bool BuffsKeep = false;
		public bool MemersRiposte = false;
		public bool ModPlayer = true;
		public bool lf = false;
		public int lamp = 0;
		public bool ParadiseLost = false;
		public bool Rampage = false;
		public bool LilithEmblem = false;
		public bool trigger = true;
		public bool watchercrystal = false;
		public bool grimreaper = false;
		public bool rainbowdust = false;
		public bool sscope = false;
		public bool lwm = false;
		public bool DB = false;
		public bool MeatGrinderOnUse = false;
		public int DisasterGauge = 0;
		public int chargetime = 0;
		public int MeatGrinderUsetime = 0;
		
		private const int maxLifeElixir = 2;
		public int LifeElixir = 0;
		private const int maxFuaran = 1;
		public int Fuaran = 0;
		private const int maxKeepBuffs = 1;
		public int KeepBuffs = 0;
		private const int maxWellFed = 1;
		public int WellFed = 0;
		
		public override void ResetEffects()
		{
			Item.potionDelay = 3600;
			Luck = false;
			AlchemistGlobalItem.Luck = false;
			AlchemistNPC.BastScroll = false;
			AlchemistNPC.Stormbreaker = false;
			MeatGrinderOnUse = false;
			AlchemistCharmTier1 = false;
			AlchemistCharmTier2 = false;
			AlchemistCharmTier3 = false;
			AlchemistCharmTier4 = false;
			BeeHeal = false;
			Pandora = false;
			TS = false;
			Symbiote = false;
			DriedFish = false;
			SolarFish = false;
			NebulaFish = false;
			VortexFish = false;
			StardustFish = false;
			MiniShark = false;
			Manna = false;
			Akumu = false;
			AutoinjectorMK2 = false;
			EyeOfJudgement = false;
			LaetitiaSet = false;
			Scroll = false;
			SFU = false;
			SF = false;
			XtraT = false;
			RevSet = false;
			MemersRiposte = false;
			PGSWear = false;
			Extractor = false;
			ParadiseLost = false;
			Rampage = false;
			LilithEmblem = false;
			watchercrystal = false;
			grimreaper = false;
			rainbowdust = false;
			sscope = false;
			lwm = false;
			Yui = false;
			YuiS = false;
			Traps = false;
			
			player.statLifeMax2 += LifeElixir * 50;
			player.statManaMax2 += Fuaran * 100;
			
			if (KeepBuffs == 1)
			{
			BuffsKeep = true;
			player.pStone = true;
			}
			if (KeepBuffs == 0)
			{
			BuffsKeep = false;
			}
			if (WellFed == 1)
			{
			player.AddBuff(BuffID.WellFed, 2);
			}
		}
	
		public override bool CanBeHitByProjectile(Projectile projectile)
		{
			if (player.FindBuffIndex(mod.BuffType("Akumu")) > -1 || player.FindBuffIndex(mod.BuffType("TrueAkumu")) > -1)
			{
			return false;
			}
			return true;
		}
	
		public override void clientClone(ModPlayer clientClone)
		{
			AlchemistNPCPlayer clone = clientClone as AlchemistNPCPlayer;
		}
	
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.LifeAndManaSync);
			packet.Write((byte)player.whoAmI);
			packet.Write(LifeElixir);
			packet.Write(Fuaran);
			packet.Write(KeepBuffs);
			packet.Write(WellFed);
			packet.Send(toWho, fromWho);
		}
	
		public override void OnEnterWorld(Player player)
		{
            string enterText = Language.GetTextValue("Mods.AlchemistNPC.enterText");
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") == null && Config.StartMessage)
			{
            Main.NewText(enterText, 0, 255, 255);
			}
		}
	
		public override void SendClientChanges(ModPlayer clientPlayer)
		{
		}
	
		public override TagCompound Save()
		{
			return new TagCompound {
				{"LifeElixir", LifeElixir},
				{"Fuaran", Fuaran},
				{"KeepBuffs", KeepBuffs},
				{"WellFed", WellFed},
			};
		}
	
		public override void Load(TagCompound tag)
		{
			LifeElixir = tag.GetInt("LifeElixir");
			Fuaran = tag.GetInt("Fuaran");
			KeepBuffs = tag.GetInt("KeepBuffs");
			WellFed = tag.GetInt("WellFed");
		}
	
		public override void AnglerQuestReward(float quality, List<Item> rewardItems)
		{
			if (DriedFish)
			{
				Item vobla = new Item();
				vobla.SetDefaults(mod.ItemType("DriedFish"));
				vobla.stack = 1;
				rewardItems.Add(vobla);
			}
			if (SolarFish)
			{
				Item solar = new Item();
				solar.SetDefaults(ItemID.FragmentSolar);
				solar.stack = 25;
				rewardItems.Add(solar);
			}
			if (NebulaFish)
			{
				Item nebula = new Item();
				nebula.SetDefaults(ItemID.FragmentNebula);
				nebula.stack = 25;
				rewardItems.Add(nebula);
			}
			if (VortexFish)
			{
				Item vortex = new Item();
				vortex.SetDefaults(ItemID.FragmentVortex);
				vortex.stack = 25;
				rewardItems.Add(vortex);
			}
			if (StardustFish)
			{
				Item stardust = new Item();
				stardust.SetDefaults(ItemID.FragmentStardust);
				stardust.stack = 25;
				rewardItems.Add(stardust);
			}
			if (MiniShark)
			{
				Item minishark = new Item();
				minishark.SetDefaults(ItemID.Minishark);
				minishark.stack = 1;
				rewardItems.Add(minishark);
			}
			if (Manna)
			{
				Item manna = new Item();
				manna.SetDefaults(mod.ItemType("MannafromHeaven"));
				manna.stack = 1;
				rewardItems.Add(manna);
			}
		}

		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if (junk)
			{
				return;
			}
			if (questFish == mod.ItemType("MutantFish") && Main.rand.Next(8) == 0)
			{
				caughtType = mod.ItemType("MutantFish");
			}
			if (player.ZoneTowerSolar && questFish == mod.ItemType("SolarFish") && Main.rand.Next(5) == 0)
			{
				caughtType = mod.ItemType("SolarFish");
			}
			if (player.ZoneTowerNebula && questFish == mod.ItemType("NebulaFish") && Main.rand.Next(5) == 0)
			{
				caughtType = mod.ItemType("NebulaFish");
			}
			if (player.ZoneTowerVortex && questFish == mod.ItemType("VortexFish") && Main.rand.Next(5) == 0)
			{
				caughtType = mod.ItemType("VortexFish");
			}
			if (player.ZoneTowerStardust && questFish == mod.ItemType("StardustFish") && Main.rand.Next(5) == 0)
			{
				caughtType = mod.ItemType("StardustFish");
			}
			if (player.ZoneBeach && questFish == mod.ItemType("MiniShark") && Main.rand.Next(8) == 0)
			{
				caughtType = mod.ItemType("MiniShark");
			}
			if (player.ZoneDesert && questFish == mod.ItemType("MosesFish") && Main.rand.Next(20) == 0 && power < 55)
			{
				caughtType = mod.ItemType("MosesFish");
			}
			if (player.ZoneDesert && questFish == mod.ItemType("MosesFish") && Main.rand.Next(10) == 0 && power >= 55)
			{
				caughtType = mod.ItemType("MosesFish");
			}
		}
	
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{	
			if (target.friendly == false)
			{
			if (player.FindBuffIndex(mod.BuffType("RainbowFlaskBuff")) > -1)
				{
				target.buffImmune[BuffID.BetsysCurse] = false;
				target.buffImmune[BuffID.Ichor] = false;
				target.buffImmune[BuffID.Daybreak] = false;
				target.AddBuff(mod.BuffType("Corrosion"), 600);
				target.AddBuff(BuffID.BetsysCurse, 600);
				target.AddBuff(BuffID.Ichor, 600);
				target.AddBuff(BuffID.Daybreak, 600);
				}
			if (player.FindBuffIndex(mod.BuffType("BigBirdLamp")) > -1)
				{
				target.buffImmune[BuffID.BetsysCurse] = false;
				target.buffImmune[BuffID.Ichor] = false;
				target.AddBuff(BuffID.Ichor, 600);
				target.AddBuff(BuffID.BetsysCurse, 600);
				}
			if (Scroll)
				{
					if (target.type != mod.NPCType("Knuckles"))
					{
					target.buffImmune[mod.BuffType("ArmorDestruction")] = false;
					target.AddBuff(mod.BuffType("ArmorDestruction"), 600);
					target.defense = 0;
					}
				}
			if (player.FindBuffIndex(mod.BuffType("ExplorersBrew")) > -1)
				{
				target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
			}
		}
			
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (target.friendly == false)
			{
			if (player.FindBuffIndex(mod.BuffType("RainbowFlaskBuff")) > -1)
				{
				target.buffImmune[BuffID.BetsysCurse] = false;
				target.buffImmune[BuffID.Ichor] = false;
				target.buffImmune[BuffID.Daybreak] = false;
				target.AddBuff(mod.BuffType("Corrosion"), 600);
				target.AddBuff(BuffID.BetsysCurse, 600);
				target.AddBuff(BuffID.Ichor, 600);
				target.AddBuff(BuffID.Daybreak, 600);
				}
			if (player.FindBuffIndex(mod.BuffType("BigBirdLamp")) > -1)
				{
				target.buffImmune[BuffID.BetsysCurse] = false;
				target.buffImmune[BuffID.Ichor] = false;
				target.AddBuff(BuffID.Ichor, 600);
				target.AddBuff(BuffID.BetsysCurse, 600);
				}
			if (proj.thrown && Scroll)
				{
				if (target.type != mod.NPCType("Knuckles"))
					{
					target.buffImmune[mod.BuffType("ArmorDestruction")] = false;
					target.AddBuff(mod.BuffType("ArmorDestruction"), 600);
					}
				}
			if ((proj.type == ProjectileID.Electrosphere) && XtraT)
				{
				target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
			if (player.FindBuffIndex(mod.BuffType("ExplorersBrew")) > -1)
				{
				target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
			}
		}
		
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (player.FindBuffIndex(mod.BuffType("Uganda")) > -1)
			{
				damageSource = PlayerDeathReason.ByCustomReason(player.name + " DIDN NO DE WEI!");
			}
			if (NPC.AnyNPCs(mod.NPCType("Knuckles")))
			{
				damageSource = PlayerDeathReason.ByCustomReason(player.name + " DIDN NO DE WEI!");
			}
			return true;
		}
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (AlchemistNPC.LampLight.JustPressed)
			{
				if (lamp == 0 && trigger)
				{
				trigger = false;
				lamp++;
				lf = true;
				}
				if (lamp == 1 && !trigger && !lf)
				{
				trigger = true;
				lamp = 0;
				}
				lf = false;
			}
			if (AlchemistNPC.DiscordBuff.JustPressed)
			{
				if (Main.myPlayer == player.whoAmI && player.FindBuffIndex(mod.BuffType("DiscordBuff")) > -1)
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				player.Teleport(vector2, 1, 0);
				NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) player.whoAmI, (float) vector2.X, (float) vector2.Y, 1, 0, 0);
					if (player.chaosState)
					{
						player.statLife = player.statLife - player.statLifeMax2 / 3;
						PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
						if (Main.rand.Next(2) == 0)
						damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
						if (player.statLife <= 0)
						player.KillMe(damageSource, 1.0, 0, false);
						player.lifeRegenCount = 0;
						player.lifeRegenTime = 0;
					}
				player.AddBuff(88, 600, true);
				player.AddBuff(164, 60, true);
				}
				if (Main.myPlayer == player.whoAmI && player.FindBuffIndex(mod.BuffType("TrueDiscordBuff")) > -1)
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				player.Teleport(vector2, 1, 0);
				NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) player.whoAmI, (float) vector2.X, (float) vector2.Y, 1, 0, 0);
					if (player.chaosState)
					{
						player.statLife = player.statLife - player.statLifeMax2 / 7;
						PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
						if (Main.rand.Next(2) == 0)
						damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
						if (player.statLife <= 0)
						player.KillMe(damageSource, 1.0, 0, false);
						player.lifeRegenCount = 0;
						player.lifeRegenTime = 0;
					}
				player.AddBuff(88, 360, true);
				}
			}
		}

		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (MemersRiposte && crit)
            {
                damage *= 2;
            }
        }
		
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (MemersRiposte && crit)
            {
                damage *= 2;
            }
			if (proj.type == mod.ProjectileType("DemonicBullet") && crit && Main.rand.Next(200) == 0)
            {
                damage = 33333;
            }
		}
		
		public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit) 		
        {
            if (MemersRiposte)
            {
				for (int h = 0; h < 1; h++) 
					{
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("Returner"), damage*5, 0, player.whoAmI);
					}
			}
			if (player.FindBuffIndex(mod.BuffType("Judgement")) > -1)
				{
					if (Main.rand.Next(3) == 0)
					{
					damage = 2;
					}
				}
			if (ParadiseLost)
				{
				if (damage < 150)
				damage = 1;
				}
        }
		
		public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit) 	
        {
			if (MemersRiposte)
            {
				for (int h = 0; h < 1; h++) 
					{
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("Returner"), damage*5, 0, player.whoAmI);
					}
			}
			if (player.FindBuffIndex(mod.BuffType("Judgement")) > -1)
				{
					if (Main.rand.Next(3) == 0)
					{
					damage = 2;
					}
				}
			if (ParadiseLost)
				{
				if (damage < 150)
				damage = 1;
				}
        }
	}
}