using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CounterMatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Counter Matter");
			Tooltip.SetDefault("Globe 199"
			+"\n[c/00FF00:Legendary Weapon]"
			+"\nDestroys nearby enemy projectiles"
			+"\nAfter blocking the projectile, your next strike would be 100% critical"
			+"\n[c/00FF00:Stats are growing through progression]");
			DisplayName.AddTranslation(GameCulture.Russian, "Противодействующая Материя");
            Tooltip.AddTranslation(GameCulture.Russian, "Шар 199\n[c/00FF00:Легендарное Оружие]\nУничтожает снаряды противника поблизости\nПосле блокирования снаряда ваша следуящая атака гарантированно будет критом\n[c/00FF00:Статы улучшаются по мере прохождения]");
        }
		
		public override void SetDefaults()
		{
			item.mana = 100;
			item.width = 48;
			item.height = 48;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.noMelee = true;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.buffType = mod.BuffType("ProjCounter");
			item.scale = 0.5f;
		}
		
		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 2, true);
			}
		}
	}
}
