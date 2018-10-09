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
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Illuminati Gift");
			Tooltip.SetDefault("Increases all items reach and quantity of dropped coins"
				+ "\nStated above would work if accessory is visible"
				+ "\nMost traders provide discounts"
				+ "\nParalizes all enemies on screen after being hit"
				+ "\nIf you HP reaches 10% or less, activates special regeneration"
				+ "\nThis ability has 2 minute cooldown"
				+ "\nIf hit was supposed to kill you, you will survive"
				+ "\nWould only work if cooldown is not active"
				+ "\nAllows to inflict Midas Touch debuff by any attack");
				DisplayName.AddTranslation(GameCulture.Russian, "Дар Иллюминатов");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт все эффекты Кольца Жадности\nУвеличивает радиус подбора предметов, если акссесуар виден\nПри получении урона все враги на экране будут парализованы\nЕсли ХП опускается ниже 10%, то включается специальная регенерация\nСпособность имеет двухминутный откат\nУдар не убьёт вас, пока не активен откат\nЛюбые атаки накладывают Касание Мидаса на противников");
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
        get { return CalamityMod.CalamityWorld.revenge; }
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
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
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
				if (!ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
				player.AddBuff(mod.BuffType("IlluminatiHeal"), 3600);
				player.AddBuff(mod.BuffType("IlluminatiCooldown"), 7200);
				}
			}
		}
	}
}