using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class SuspiciousLookingScythe : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suspicious Looking Scythe");
			Tooltip.SetDefault("Summons your own Grim Reaper. Increases your crits moderately.");
			DisplayName.AddTranslation(GameCulture.Russian, "Подозрительно Выглядящая Коса");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает вашего собственного Жнеца. Увеличивает ваш шанс критического удара.");

            DisplayName.AddTranslation(GameCulture.Chinese, "可疑镰刀");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤你自己的死神. 适度提高你的爆击.");
        }    
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);
			item.width = 34;
			item.height = 34;
			item.value = 15000000;
			item.shoot = mod.ProjectileType("GrimReaper");
			item.buffType = mod.BuffType("GrimReaper");	//The buff added to player after used the item
			item.buffTime = 3600;
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
