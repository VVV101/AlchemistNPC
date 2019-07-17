using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class AntiBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Anti Buff boosts");
			Description.SetDefault("");
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Анти Бафф усиления");
			Description.AddTranslation(GameCulture.Russian, "");
        }
		
		public override void ModifyBuffTip (ref string tip, ref int rare)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			tip = "Active boosts:";
			if (modPlayer.KingSlimeBooster == 1)
			{
				tip += "\nIncreases jump height and safe fall distance greatly";
			}
			if (modPlayer.EyeOfCthulhuBooster == 1)
			{
				tip += "\nProvides creatures, treasures and traps detection";
			}
			if (modPlayer.EaterOfWorldsBooster == 1)
			{
				tip += "\nIncreases melee speed by 5%, movement and mining speed by 25%";
			}
			if (modPlayer.BrainOfCthulhuBooster == 1)
			{
				tip += "\nIncreases max amount of minions/sentries by 1, Heartreach effect";
			}
			if (modPlayer.QueenBeeBooster == 1)
			{
				tip += "\nHostile bees do less damage and your regeneration is increased by 6, immunity to poisons";
			}
			if (modPlayer.SkeletronBooster == 1)
			{
				tip += "\nSkeletons contact damage is reduced, all damages/critical strike chances are increased by 10%";
			}
			if (modPlayer.CustomBooster1 == 1)
			{
				tip += "\nProvides immunity to fire blocks, Obsidian Skin and Gills effects";
			}
			if (modPlayer.WoFBooster == 1)
			{
				tip += "\nIncreases max amount of minions/sentries by 1, defense and DR by 10/10%";
			}
			if (modPlayer.GSummonerBooster == 1)
			{
				tip += "\nMakes your attacks inflict Shadowflame and makes you immune to it";
			}
			if (modPlayer.DarkMageBooster == 1)
			{
				tip += "\nIncreases magic damage by 25%, max mana by 50 and mana regeneration greatly";
			}
			if (modPlayer.IceGolemBooster == 1)
			{
				tip += "\nProvides immunity to Chilled, Frozen and Frostburn debuffs";
			}
			if (modPlayer.PigronBooster == 1)
			{
				tip += "\nProvides Well Fed";
			}
			if (modPlayer.DestroyerBooster == 1)
			{
				tip += "\nIncreases mining speed by 33% and increases max life by 25%";
			}
			if (modPlayer.PrimeBooster == 1)
			{
				tip += "\nIncreases armor penetration and melee speed by 15/15%, gives 200% thorns effect";
			}
			if (modPlayer.TwinsBooster == 1)
			{
				tip += "\nShine, Nightvision, Archery and Ammo Reservation effects, immunity to Cursed Flames and Ichor";
			}
			if (modPlayer.OgreBooster == 1)
			{
				tip += "\nIncreases defense and damage reduction by 5/5% and provides knockback immunity";
			}
			if (modPlayer.PlanteraBooster == 1)
			{
				tip += "\nDamages and critical strike chances are boosted while you are moving, Philosopher's stone effect";
			}
			if (modPlayer.GolemBooster == 1)
			{
				tip += "\nIncreases attack speed by 10% and increases melee knockback";
			}
			if (modPlayer.BetsyBooster == 1)
			{
				tip += "\nYour attacks inflict Daybroken, flight abilities are increased";
			}
			if (modPlayer.FishronBooster == 1)
			{
				tip += "\nGives ability to dash, all stats up while on surface";
			}
			if (modPlayer.MartianSaucerBooster == 1)
			{
				tip += "\nProvides immunity to Electrified and Distorted debuffs";
			}
			if (modPlayer.CultistBooster == 1)
			{
				tip += "\nReduces damage taken from Pillars enemies, mobs may drop lunar fragments";
			}
			if (modPlayer.MoonLordBooster == 1)
			{
				tip += "\nYou emit aura which weakens enemies around";
			}
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (modPlayer.KingSlimeBooster == 1)
			{
				player.autoJump = true;
				player.jumpSpeedBoost += 2.4f;
				player.extraFall += 30;
			}
			if (modPlayer.EyeOfCthulhuBooster == 1)
			{
				player.findTreasure = true;
				player.detectCreature = true;
				player.dangerSense = true;
			}
			if (modPlayer.EaterOfWorldsBooster == 1)
			{
				player.meleeSpeed += 0.05f;
				player.pickSpeed -= 0.25f;
				player.moveSpeed += 0.25f;
			}
			if (modPlayer.BrainOfCthulhuBooster == 1)
			{
				player.maxMinions += 1;
				player.maxTurrets += 1;
				player.lifeMagnet = true;
			}
			if (modPlayer.QueenBeeBooster == 1)
			{
				player.lifeRegen += 6;
				player.buffImmune[20] = true;
				player.buffImmune[70] = true;
			}
			if (modPlayer.SkeletronBooster == 1)
			{
				player.meleeDamage += 0.1f;
				player.rangedDamage += 0.1f;
				player.magicDamage += 0.1f;
				player.minionDamage += 0.1f;
				player.thrownDamage += 0.1f;
				player.meleeCrit += 10;
				player.rangedCrit += 10;
				player.magicCrit += 10;
				player.thrownCrit += 10;
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
					ThoriumBoosts(player, 0);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
					RedemptionBoost(player, 0);
				}
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					CalamityBoost(player, 0);
				}
			}
			if (modPlayer.CustomBooster1 == 1)
			{
				player.lavaImmune = true;
				player.fireWalk = true;
				player.buffImmune[24] = true;
				player.buffImmune[67] = true;
			}
			if (modPlayer.WoFBooster == 1)
			{
				player.statDefense += 10;
				player.endurance += 0.1f;
				player.maxMinions += 1;
				player.maxTurrets += 1;
			}
			if (modPlayer.GSummonerBooster == 1)
			{
				player.buffImmune[153] = true;
			}
			if (modPlayer.DarkMageBooster == 1)
			{
				player.magicDamage += 0.25f;
				player.statManaMax2 += 50;
				player.manaRegenBuff = true;
			}
			if (modPlayer.IceGolemBooster == 1)
			{
				player.buffImmune[44] = true;
				player.buffImmune[46] = true;
				player.buffImmune[46] = true;
			}
			if (modPlayer.PigronBooster == 1)
			{
				player.AddBuff(26, 2);
			}
			if (modPlayer.DestroyerBooster == 1)
			{
				player.pickSpeed -= 0.33f;
				player.statLifeMax2 += player.statLifeMax / 4;
			}
			if (modPlayer.PrimeBooster == 1)
			{
				player.armorPenetration += 15;
				player.meleeSpeed += 0.15f;
				if ((double)player.thorns < 1.0)
					player.thorns = 2f;
			}
			if (modPlayer.TwinsBooster == 1)
			{
				player.archery = true;
				player.ammoPotion = true;
				Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
				player.nightVision = true;
				player.buffImmune[39] = true;
				player.buffImmune[69] = true;
			}
			if (modPlayer.OgreBooster == 1)
			{
				player.statDefense += 5;
				player.endurance += 0.05f;
				player.noKnockback = true;
			}
			if (modPlayer.PlanteraBooster == 1)
			{
				if (player.velocity.X != 0f || player.velocity.Y != 0f)
				{
					player.pStone = true;
					player.meleeDamage += 0.05f;
					player.rangedDamage += 0.05f;
					player.magicDamage += 0.05f;
					player.minionDamage += 0.05f;
					player.thrownDamage += 0.05f;
					player.meleeCrit += 5;
					player.rangedCrit += 5;
					player.magicCrit += 5;
					player.thrownCrit += 5;
					if (ModLoader.GetMod("ThoriumMod") != null)
					{
						ThoriumBoosts(player, 1);
					}
					if (ModLoader.GetMod("Redemption") != null)
					{
						RedemptionBoost(player, 1);
					}
					if (ModLoader.GetMod("CalamityMod") != null)
					{
						CalamityBoost(player, 1);
					}
				}
			}
			if (modPlayer.GolemBooster == 1)
			{
				player.kbBuff = true;
			}
			if (modPlayer.FishronBooster == 1)
			{
				player.dash = 2;
				if (player.ZoneOverworldHeight)
				{
					player.statDefense += 3;
					player.moveSpeed += 0.1f;
					player.endurance += 0.03f;
					player.meleeDamage += 0.03f;
					player.rangedDamage += 0.03f;
					player.magicDamage += 0.03f;
					player.minionDamage += 0.03f;
					player.thrownDamage += 0.03f;
					player.meleeCrit += 3;
					player.rangedCrit += 3;
					player.magicCrit += 3;
					player.thrownCrit += 3;
					if (ModLoader.GetMod("ThoriumMod") != null)
					{
						ThoriumBoosts(player, 2);
					}
					if (ModLoader.GetMod("Redemption") != null)
					{
						RedemptionBoost(player, 2);
					}
					if (ModLoader.GetMod("CalamityMod") != null)
					{
						CalamityBoost(player, 2);
					}
				}
			}
			if (modPlayer.MartianSaucerBooster == 1)
			{
				player.buffImmune[164] = true;
				player.buffImmune[144] = true;
			}
		}
		
		private void CalamityBoost(Player player, int c)
        {
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
			if (c == 0)
			{
				CalamityPlayer.throwingDamage += 0.1f;
				CalamityPlayer.throwingCrit += 10;
			}
			if (c == 1)
			{
				CalamityPlayer.throwingDamage += 0.05f;
				CalamityPlayer.throwingCrit += 5;
			}
			if (c == 2)
			{
				CalamityPlayer.throwingDamage += 0.03f;
				CalamityPlayer.throwingCrit += 3;
			}
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player, int c)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			if (c == 0)
			{
				RedemptionPlayer.druidDamage += 0.1f;
				RedemptionPlayer.druidCrit += 10;
			}
			if (c == 1)
			{
				RedemptionPlayer.druidDamage += 0.05f;
				RedemptionPlayer.druidCrit += 5;
			}
			if (c == 2)
			{
				RedemptionPlayer.druidDamage += 0.03f;
				RedemptionPlayer.druidCrit += 3;
			}
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player, int c)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
			if (c == 0)
			{
				ThoriumPlayer.symphonicDamage += 0.1f;
				ThoriumPlayer.radiantBoost += 0.1f;
				ThoriumPlayer.symphonicCrit += 10;
				ThoriumPlayer.radiantCrit += 10;
			}
			if (c == 1)
			{
				ThoriumPlayer.symphonicDamage += 0.05f;
				ThoriumPlayer.radiantBoost += 0.05f;
				ThoriumPlayer.symphonicCrit += 5;
				ThoriumPlayer.radiantCrit += 5;
			}
			if (c == 1)
			{
				ThoriumPlayer.symphonicDamage += 0.03f;
				ThoriumPlayer.radiantBoost += 0.03f;
				ThoriumPlayer.symphonicCrit += 3;
				ThoriumPlayer.radiantCrit += 3;
			}
        }
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
