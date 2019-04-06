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
			Tooltip.SetDefault("Upgrades your Nurse while in your inventory"
			+"\nOpens up healing interface after respawn"
			+"\nWould work only if Nurse is alive");
			DisplayName.AddTranslation(GameCulture.Russian, "Диплом Врача");
            Tooltip.AddTranslation(GameCulture.Russian, "Улучшает медсестру, если находится в вашем инвентаре\nОткрывает интерфейс лечения после возрождения\nРаботает только в том случае, если Медсестра жива");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 500000;
			item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).PHD = true;
		}
	}
}
