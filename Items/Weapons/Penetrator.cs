using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class Penetrator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Penetrator");
			Tooltip.SetDefault("Pretty slow, unpleasent looking rifle"
			+ "\n[c/00FF00:Legendary Weapon]"
			+ "\nCritical hits damage varies from 3x to 5x"
			+ "\nUses health instead of ammo"
			+"\n[c/00FF00:Stats are growing up through progression]"
			+"\nBoosted stats will be shown after the first use");
			DisplayName.AddTranslation(GameCulture.Russian, "Пронзатель");
            Tooltip.AddTranslation(GameCulture.Russian, "Довольно медленная, неприятно выглядящая винтовка\n[c/00FF00:Легендарное Оружие]\nПробивает значительное количество противников одним выстрелом\nКритические попадания наносят четырёхкратный урон\nОтнимает по 2 очка здоровья за выстрел\n[c/00FF00:Показатели увеличивается по мере прохождения]");
			DisplayName.AddTranslation(GameCulture.Chinese, "洞察者");
			Tooltip.AddTranslation(GameCulture.Chinese, "非常缓慢, 看起来让人不愉快的步枪"
			+"\n[c/00FF00:传奇武器]"
			+"\n暴击伤害从3倍到5倍浮动"
			+"\n消耗生命而不是弹药"
			+"\n[c/00FF00:属性随进程成长]"
			+"\n提升过后的属性将会在使用后显示");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SniperRifle);
			item.damage = 15;
			item.crit = 35;
			item.autoReuse = true;
			item.useTime = 65;
			item.useAnimation = 65;
			item.ammo = 0;
			item.useAmmo = 0;
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 82;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (NPC.downedSlimeKing)
			{
				item.damage = 25;
			}
			if (NPC.downedBoss1)
			{
				item.damage = 30;
			}
			if (NPC.downedBoss2)
			{
				item.damage = 35;
			}
			if (NPC.downedQueenBee)
			{
				item.damage = 40;
			}
			if (NPC.downedBoss3)
			{
				item.damage = 45;
			}
			if (Main.hardMode)
			{
				item.damage = 50;
			}
			if (NPC.downedMechBossAny)
			{
				item.damage = 60;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				item.damage = 75;
			}
			if (NPC.downedPlantBoss)
			{
				item.damage = 100;
			}
			if (NPC.downedGolemBoss)
			{
				item.damage = 125;
			}
			if (NPC.downedFishron)
			{
				item.damage = 175;
			}
			if (NPC.downedAncientCultist)
			{
				item.damage = 250;
			}
			if (NPC.downedMoonlord)
			{
				item.damage = 500;
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (CalamityModDownedGuardian)
				{
					item.damage = 600;
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (ThoriumModDownedRagnarok)
				{
					item.damage = 750;
				}
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (CalamityModDownedProvidence)
				{
					item.damage = 1000;
				}
				if (CalamityModDownedPolter)
				{
					item.damage = 1350;
				}
				if (CalamityModDownedDOG)
				{
					item.damage = 3000;
				}
				if (CalamityModDownedYharon)
				{
					item.damage = 5000;
				}
				if (CalamityModDownedSCal)
				{
					item.damage = 10000;
				}
			}
			return true;
		}
		
		
		public bool CalamityModDownedGuardian
		{
		get { return CalamityMod.CalamityWorld.downedGuardians; }
		}
		public bool CalamityModDownedBirb
		{
		get { return CalamityMod.CalamityWorld.downedBumble; }
		}
		public bool CalamityModDownedPolter
		{
		get { return CalamityMod.CalamityWorld.downedPolterghast; }
		}
		public bool CalamityModDownedDOG
		{
		get { return CalamityMod.CalamityWorld.downedDoG; }
		}
		public bool CalamityModDownedYharon
		{
		get { return CalamityMod.CalamityWorld.downedYharon; }
		}
		public bool CalamityModDownedSCal
		{
		get { return CalamityMod.CalamityWorld.downedSCal; }
		}
		public bool CalamityModDownedProvidence
        {
        get { return CalamityMod.CalamityWorld.downedProvidence; }
        }
        public bool ThoriumModDownedRagnarok
        {
        get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.statLife -= 2;
			type = 638;
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}