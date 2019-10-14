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
	public class VoodooDoll : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Voodoo Doll");
			Tooltip.SetDefault("Your very own doll\nWill make you take part of your dealt damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Кукла Вуду");
            Tooltip.AddTranslation(GameCulture.Russian, "Ваша кукла\nЗаставляет вас получать часть урона, наносимого боссу");
			DisplayName.AddTranslation(GameCulture.Chinese, "巫毒娃娃");
			Tooltip.AddTranslation(GameCulture.Chinese, "你自己的娃娃\n所造成伤害的一部分会施加给自己");
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
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Voodoo = true;
		}
	}
}
