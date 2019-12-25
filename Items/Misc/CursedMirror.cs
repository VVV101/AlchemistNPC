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
	public class CursedMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Mirror");
			Tooltip.SetDefault("Broken Mirror\nAll your projectiles would be reflected");
			DisplayName.AddTranslation(GameCulture.Russian, "Проклятое Зеркало");
            Tooltip.AddTranslation(GameCulture.Russian, "Разбитое Зеркало\nВсе ваши снаряды будут отражены");
			DisplayName.AddTranslation(GameCulture.Chinese, "被诅咒的镜子");
			Tooltip.AddTranslation(GameCulture.Chinese, "破碎的镜子\n你的所有抛射物都会被反弹");
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
