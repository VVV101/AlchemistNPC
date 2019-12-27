using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
			DisplayName.AddTranslation(GameCulture.Chinese, "反buff增益");
			Description.AddTranslation(GameCulture.Chinese, "");
        }
		
		public override void ModifyBuffTip (ref string tipline, ref int rare)
		{
			string tip;
			string tipch;
			
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			tip = "Active boosts:";
			tipch = "生效增益:";
			
			if (modPlayer.KingSlimeBooster == 1)
			{
				tip += "\nIncreases jump height and safe fall distance greatly";
				tipch += "\n极大提升跳跃高度和安全坠落距离";
			}
			if (modPlayer.EyeOfCthulhuBooster == 1)
			{
				tip += "\nProvides creatures, treasures and traps detection";
				tipch += "\n提供生物，宝藏和陷阱的探测能力";
				
			}
			if (modPlayer.CustomBooster1 == 1)
			{
				tip += "\nGives Shine and Nightvision effects";
				tipch += "\n给予发光和夜视效果";
			}
			if (modPlayer.EaterOfWorldsBooster == 1)
			{
				tip += "\nIncreases melee speed by 5%, movement and mining speed by 25%";
				tipch += "\n增加5%近战速度，增加25%移动和挖掘速度";
			}
			if (modPlayer.BrainOfCthulhuBooster == 1)
			{
				tip += "\nIncreases max amount of minions by 1, Heartreach effect";
				tipch += "\n增加1召唤物上限，获得心之彼端效果";
			}
			if (modPlayer.QueenBeeBooster == 1)
			{
				tip += "\nHostile bees do less damage and your regeneration is increased by 6, immunity to poisons";
				tipch += "\n敌方蜜蜂的伤害降低并且你的生命再生速度增加6，免疫中毒";
			}
			if (modPlayer.SkeletronBooster == 1)
			{
				tip += "\nSkeletons contact damage is reduced, all damages/critical strike chances are increased by 10%";
				tipch += "\n骷髅的接触伤害降低，所有伤害和暴击率提升10%";
			}
			if (modPlayer.CustomBooster2 == 1)
			{
				tip += "\nProvides immunity to fire blocks, Obsidian Skin, Gills and Flipper effects";
				tipch += "\n给予免疫火块，黑曜石皮肤，鱼鳃，脚蹼药剂效果";
			}
			if (modPlayer.WoFBooster == 1)
			{
				tip += "\nIncreases max amount of minions/sentries by 1, defense and DR by 10/10%";
				tipch += "\n增加1召唤物和哨兵炮台上限，10防御力和10%伤害减免";
			}
			if (modPlayer.GSummonerBooster == 1)
			{
				tip += "\nMakes your attacks inflict Shadowflame and makes you immune to it";
				tipch += "\n让你的攻击能造成暗影炎，你免疫暗影炎";
			}
			if (modPlayer.DarkMageBooster == 1)
			{
				tip += "\nIncreases magic damage by 25%, max mana by 50 and mana regeneration greatly";
				tipch += "\n提升25%魔法伤害，增加50魔法上限并极大提升魔力再生速度";
			}
			if (modPlayer.IceGolemBooster == 1)
			{
				tip += "\nProvides immunity to Chilled, Frozen and Frostburn debuffs";
				tipch += "\n免疫寒冷，冻结和霜火";
			}
			if (modPlayer.PigronBooster == 1)
			{
				tip += "\nProvides Well Fed";
				tipch += "\n吃得饱!";
			}
			if (modPlayer.DestroyerBooster == 1)
			{
				tip += "\nIncreases mining speed by 33% and increases max life by 25%";
				tipch += "\n增加33%挖掘速度并提升25%生命上限";
			}
			if (modPlayer.PrimeBooster == 1)
			{
				tip += "\nIncreases armor penetration and melee speed by 15/15%, gives 200% thorns effect";
				tipch += "\n提升15点护甲穿透和15%的近战速度，给予200%的荆棘药剂效果";
			}
			if (modPlayer.TwinsBooster == 1)
			{
				tip += "\nArchery and Ammo Reservation effects, immunity to Cursed Flames and Ichor";
				tipch += "\n箭术和弹药储备药剂效果，免疫咒焰和脓血";
			}
			if (modPlayer.OgreBooster == 1)
			{
				tip += "\nIncreases defense and damage reduction by 5/5% and provides knockback immunity";
				tipch += "\n提升5防御和增加5%伤害减免并免疫击退";
			}
			if (modPlayer.PlanteraBooster == 1)
			{
				tip += "\nDamages and critical strike chances are boosted while you are moving, Philosopher's stone effect";
				tipch += "\n移动时增加伤害和暴击率，获得炼金石效果(减药水cd)";
			}
			if (modPlayer.GolemBooster == 1)
			{
				tip += "\nIncreases attack speed by 10% and increases melee knockback";
				tipch += "\n增加10%攻击速度，提升近战击退力";
			}
			if (modPlayer.BetsyBooster == 1)
			{
				tip += "\nYour attacks inflict Daybroken, flight abilities are increased";
				tipch += "\n你的攻击造成破晓，飞行能力提升";
			}
			if (modPlayer.FishronBooster == 1)
			{
				tip += "\nAll stats up while on surface";
				tipch += "\n表面上的所有属性增加";
			}
			if (modPlayer.MartianSaucerBooster == 1)
			{
				tip += "\nProvides immunity to Electrified and Distorted debuffs";
				tipch += "\n免疫电击和重力扭曲";
			}
			if (modPlayer.CultistBooster == 1)
			{
				tip += "\nReduces damage taken from Pillars enemies, mobs may drop lunar fragments";
				tipch += "\n减少受到月柱敌人造成的伤害，小怪可能掉落月柱碎片";
			}
			if (modPlayer.MoonLordBooster == 1)
			{
				tip += "\nYou emit aura which weakens enemies around";
				tipch += "\n你产生能弱化周围敌人的光环";
			}

			
			if(Language.ActiveCulture == GameCulture.Chinese)
			{
				tipline = tipch;
			}
			else 
			{
				tipline = tip;
			}
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
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
			if (modPlayer.CustomBooster1 == 1)
			{
				Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
				player.nightVision = true;
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
				player.allDamage += 0.1f;
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
				Mod Calamity = ModLoader.GetMod("CalamityMod");
				if(Calamity != null)
				{
					Calamity.Call("AddRogueCrit", player, 10);
				}
			}
			if (modPlayer.CustomBooster2 == 1)
			{
				player.ignoreWater = true;
				player.accFlipper = true;
				player.gills = true;
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
					player.allDamage += 0.05f;
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
					Mod Calamity = ModLoader.GetMod("CalamityMod");
					if(Calamity != null)
					{
						Calamity.Call("AddRogueCrit", player, 5);
					}
				}
			}
			if (modPlayer.GolemBooster == 1)
			{
				player.kbBuff = true;
			}
			if (modPlayer.FishronBooster == 1)
			{
				if (player.ZoneOverworldHeight)
				{
					player.statDefense += 4;
					player.moveSpeed += 0.1f;
					player.endurance += 0.04f;
					player.allDamage += 0.04f;
					player.meleeCrit += 4;
					player.rangedCrit += 4;
					player.magicCrit += 4;
					player.thrownCrit += 4;
					if (ModLoader.GetMod("ThoriumMod") != null)
					{
						ThoriumBoosts(player, 2);
					}
					if (ModLoader.GetMod("Redemption") != null)
					{
						RedemptionBoost(player, 2);
					}
					Mod Calamity = ModLoader.GetMod("CalamityMod");
					if(Calamity != null)
					{
						Calamity.Call("AddRogueCrit", player, 4);
					}
				}
			}
			if (modPlayer.MartianSaucerBooster == 1)
			{
				player.buffImmune[164] = true;
				player.buffImmune[144] = true;
			}
		}
		
		private void RedemptionBoost(Player player, int c)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
			if (c == 0)
			{
				RedemptionPlayer.druidCrit += 10;
			}
			if (c == 1)
			{
				RedemptionPlayer.druidCrit += 5;
			}
			if (c == 2)
			{
				RedemptionPlayer.druidCrit += 4;
			}
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player, int c)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
			if (c == 0)
			{
				ThoriumPlayer.symphonicCrit += 10;
				ThoriumPlayer.radiantCrit += 10;
			}
			if (c == 1)
			{
				ThoriumPlayer.symphonicCrit += 5;
				ThoriumPlayer.radiantCrit += 5;
			}
			if (c == 1)
			{
				ThoriumPlayer.symphonicCrit += 4;
				ThoriumPlayer.radiantCrit += 4;
			}
        }
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}