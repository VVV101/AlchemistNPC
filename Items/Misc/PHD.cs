using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
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
