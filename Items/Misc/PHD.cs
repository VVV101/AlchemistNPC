using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class PHD : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PhD Degree Diploma");
			Tooltip.SetDefault("Use to permanently upgrade your Nurse"
			+"\nOpens up healing interface after respawn"
			+"\nThis effect is global for all players in this world"
			+"\nWould work only if Nurse is alive");
			DisplayName.AddTranslation(GameCulture.Russian, "Диплом Врача");
            Tooltip.AddTranslation(GameCulture.Russian, "Примените для постоянного улучшения Медсестры\nОткрывает интерфейс лечения после возрождения\nЭффект глобален для всех игроков этого мира\nРаботает только в том случае, если Медсестра жива");
			DisplayName.AddTranslation(GameCulture.Chinese, "博士学位证书");
			Tooltip.AddTranslation(GameCulture.Chinese, "使用来永久升级你的护士\n重生后打开治疗界面\n该效果作用于本世界所有玩家\n只有在护士活着时起作用");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 500000;
			item.rare = 5;
			item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 4;
			item.UseSound = SoundID.Item4;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (AlchemistNPCWorld.foundPHD)
			{
				return false;
			}
			return true;
		}
		
		public override bool UseItem(Player player)
        {
			AlchemistNPCWorld.foundPHD = true;
			return true;
		}
	}
}
