using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class CrackedCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cracked Crown");
			Tooltip.SetDefault("Summons the soul hunting entity");
			DisplayName.AddTranslation(GameCulture.Russian, "Треснувшая Корона");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает сущность, охотящуюся за душами");
            DisplayName.AddTranslation(GameCulture.Chinese, "破碎王冠");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤狩猎灵魂的实体");
        }    
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.width = 34;
			item.height = 34;
			item.value = 15000000;
			item.shoot = mod.ProjectileType("Snatcher");
			item.buffType = mod.BuffType("Snatcher");
			item.expert = true;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
