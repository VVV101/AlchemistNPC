using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class IlluminatiGift : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Illuminati Gift");
			Tooltip.SetDefault("Increases all items reach and quantity of dropped coins"
				+ "\nStated above would work if accessory is visible"
				+ "\nMost traders provide discounts"
				+ "\nParalyzes all enemies on screen after being hit"
				+ "\nIf you HP reaches 10% or less, activates special regeneration"
				+ "\nThis ability has 2 minute cooldown"
				+ "\nIf damage taken would have killed you, you will survive"
				+ "\nWould only work if cooldown is not active"
				+ "\nAllows to inflict Midas Touch debuff by any attack");
				DisplayName.AddTranslation(GameCulture.Russian, "Дар Иллюминатов");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт все эффекты Кольца Жадности\nУвеличивает радиус подбора предметов, если акссесуар виден\nПри получении урона все враги на экране будут парализованы\nЕсли ХП опускается ниже 10%, то включается специальная регенерация\nСпособность имеет двухминутный откат\nУдар не убьёт вас, пока не активен откат\nЛюбые атаки накладывают Касание Мидаса на противников");
            DisplayName.AddTranslation(GameCulture.Chinese, "光照会礼物");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加物品拾取范围, 增加钱币掉落\n上述效果在饰品为可见时启用\n大部分商人都会打折\n被攻击后麻痹屏幕内所有敌人\n生命值低于10%时, 开启特殊回复\n该能力有两分钟冷却时间\n避免致死伤害\n只有在非冷却时启用\n所有攻击造成点金术效果");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 34;
			item.height = 34;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
			item.defense = 4;
			item.expert = true;
		}

		public bool CalamityModRevengeance
		{
        get { return CalamityMod.World.CalamityWorld.revenge; }
        }
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Illuminati = true;
			if (!hideVisual)
			{
				player.goldRing = true;
				player.coins = true;
				for (int number = 0; number < 400; ++number)
				{
					if (Main.item[number].active && Main.item[number].noGrabDelay == 0)
					{
						int num1 = Player.defaultItemGrabRange*10;
						if (new Microsoft.Xna.Framework.Rectangle((int)player.position.X - num1, (int)player.position.Y - num1, player.width + num1 * 2, player.height + num1 * 2).Intersects(new Microsoft.Xna.Framework.Rectangle((int)Main.item[number].position.X, (int)Main.item[number].position.Y, Main.item[number].width, Main.item[number].height)) && player.ItemSpace(Main.item[number]))
						{
							Main.item[number].beingGrabbed = true;
							float num2 = 12f;
							Vector2 vector2 = new Vector2(Main.item[number].position.X + (float)(Main.item[number].width / 2), Main.item[number].position.Y + (float)(Main.item[number].height / 2));
							float num3 = player.Center.X - vector2.X;
							float num4 = player.Center.Y - vector2.Y;
							float num5 = (float)Math.Sqrt((double)num3 * (double)num3 + (double)num4 * (double)num4);
							float num6 = num2 / num5;
							float num7 = num3 * num6;
							float num8 = num4 * num6;
							int num9 = 5;
							Main.item[number].velocity.X = (Main.item[number].velocity.X * (float)(num9 - 1) + num7) / (float)num9;
							Main.item[number].velocity.Y = (Main.item[number].velocity.Y * (float)(num9 - 1) + num8) / (float)num9;
						}
					}
				}
			}
			player.discount = true;
			if (player.statLife <= player.statLifeMax2/10 && !player.HasBuff(mod.BuffType("IlluminatiHeal")) && !player.HasBuff(mod.BuffType("IlluminatiCooldown")))
			{
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (CalamityModRevengeance)
					{
					player.AddBuff(mod.BuffType("IlluminatiHeal"), 1800);
					player.AddBuff(mod.BuffType("IlluminatiCooldown"), 3600);
					}
					else
					{
					player.AddBuff(mod.BuffType("IlluminatiHeal"), 3600);
					player.AddBuff(mod.BuffType("IlluminatiCooldown"), 7200);
					}
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
				player.AddBuff(mod.BuffType("IlluminatiHeal"), 3600);
				player.AddBuff(mod.BuffType("IlluminatiCooldown"), 7200);
				}
			}
		}
	}
}