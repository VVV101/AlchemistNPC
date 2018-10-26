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
	public class CursedMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Mirror");
			Tooltip.SetDefault("Broken Mirror\nAll your projectiles would be reflected");
			DisplayName.AddTranslation(GameCulture.Russian, "Проклятое Зеркало");
            Tooltip.AddTranslation(GameCulture.Russian, "Разбитое Зеркало\nВсе ваши снаряды будут отражены");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 0;
			item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).CursedMirror = true;
		}
	}
}
