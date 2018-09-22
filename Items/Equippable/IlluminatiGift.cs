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
			Tooltip.SetDefault("Increases coins reach and quantity of dropped coins"
				+ "\nMost traders provide discounts"
				+ "\nParalizes all enemies on screen after being hit"
				+ "\nIf you HP reaches 10% or less, activates special regeneration"
				+ "\nThis ability has 2 minute cooldown"
				+ "\nIf hit was supposed to kill you, you will survive"
				+ "\nWould only work if cooldown is not active"
				+ "\nAllows to inflict Midas Touch debuff by any attack");
				DisplayName.AddTranslation(GameCulture.Russian, "Дар Иллюминатов");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт все эффекты Кольца Жадности\nПри получении урона все враги на экране будут парализованы\nЕсли ХП опускается ниже 10%, то включается специальная регенерация\nСпособность имеет двухминутный откат\nУдар не убьёт вас, пока не активен откат\nЛюбые атаки накладывают Касание Мидаса на противников");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 26;
			item.height = 26;
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
            player.discount = true;
			}
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