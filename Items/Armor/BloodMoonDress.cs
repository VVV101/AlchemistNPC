using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BloodMoonDress : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Moon Dress");
			DisplayName.AddTranslation(GameCulture.Russian, "Платье Кровавой Луны");
			Tooltip.SetDefault("Changes player's gender to female");
            Tooltip.AddTranslation(GameCulture.Russian, "Меняет пол игрока на женский");
            DisplayName.AddTranslation(GameCulture.Chinese, "血月裙子");
            Tooltip.AddTranslation(GameCulture.Chinese, "将玩家性别变为女性");
        }

		public override void UpdateVanity(Player player, EquipType type)
		{
			player.Male = false;
		}
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}