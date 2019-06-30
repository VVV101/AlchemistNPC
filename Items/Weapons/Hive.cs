using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class Hive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive");
			Tooltip.SetDefault("''NOT THE BEES!''"
			+"\n[c/00FF00:Legendary Weapon]"
			+"\nShoots beehive, which is spreading bees around it"
			+"\nBreaks on collide, releasing even more bees"
			+"\n[c/00FF00:Stats are growing up through progression]"
			+"\nBoosted stats will be shown after the first use");
			DisplayName.AddTranslation(GameCulture.Russian, "Улей");
            Tooltip.AddTranslation(GameCulture.Russian, "''ТОЛЬКО НЕ ПЧЁЛЫ!''\n[c/00FF00:Легендарное Оружие]\nВыстреливает ульем, испускающим пчёл вокруг\nЛомается при столкновении, выпуская ещё больше пчёл\n[c/00FF00:Показатели увеличивается по мере прохождения]");
			DisplayName.AddTranslation(GameCulture.Chinese, "蜂巢");
			Tooltip.AddTranslation(GameCulture.Chinese, "''NOT THE BEES!''"
			+"\n[c/00FF00:传奇武器]"
			+"\n发射蜂巢, 在周围传播蜜蜂"
			+"\n碰撞时破坏, 释放更多蜜蜂"
			+"\n[c/00FF00:属性随进程成长]"
			+"\n提升过后的属性将会在使用后显示");
			Item.staff[item.type] = true;
        }

		public override void SetDefaults()
		{
			item.damage = 9;
			item.magic = true;
			item.mana = 15;
			item.rare = 11;
			item.width = 40;
			item.height = 40;
			item.useTime = 60;
			item.UseSound = SoundID.Item20;
			item.useStyle = 5;
			item.shootSpeed = 11f;
			item.useAnimation = 60;   
			item.knockBack = 4;
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Hive");
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 83;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (NPC.downedSlimeKing)
			{
				item.damage = 10;
			}
			if (NPC.downedBoss1)
			{
				item.damage = 12;
			}
			if (NPC.downedBoss2)
			{
				item.damage = 15;
			}
			if (NPC.downedQueenBee)
			{
				item.damage = 18;
			}
			if (NPC.downedBoss3)
			{
				item.damage = 21;
			}
			if (Main.hardMode)
			{
				item.damage = 32;
				item.useTime = 40;
				item.useAnimation = 40;
			}
			if (NPC.downedMechBossAny)
			{
				item.damage = 36;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				item.damage = 42;
			}
			if (NPC.downedPlantBoss)
			{
				item.damage = 52;
			}
			if (NPC.downedGolemBoss)
			{
				item.damage = 60;
			}
			if (NPC.downedFishron)
			{
				item.damage = 70;
			}
			if (NPC.downedAncientCultist)
			{
				item.damage = 80;
			}
			if (NPC.downedMoonlord)
			{
				item.damage = 100;
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (CalamityModDownedGuardian)
				{
					item.damage = 150;
				}
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
				if (ThoriumModDownedRagnarok)
				{
					item.damage = 200;
				}
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (CalamityModDownedProvidence)
				{
					item.damage = 200;
				}
				if (CalamityModDownedPolter)
				{
					item.damage = 350;
				}
				if (CalamityModDownedDOG)
				{
					item.damage = 1000;
				}
				if (CalamityModDownedYharon)
				{
					item.damage = 3000;
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
	}
}
