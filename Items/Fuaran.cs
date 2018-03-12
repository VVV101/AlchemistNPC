using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	class Fuaran : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fuaran");
			Tooltip.SetDefault("Permanently increases maximum mana by 100. Can only be used once.");
			DisplayName.AddTranslation(GameCulture.Russian, "Фуаран");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальную ману на 100. Может быть использован только 1 раз."); 
			
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.value = 5000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statManaMax >= 200 && player.GetModPlayer<AlchemistNPCPlayer>().Fuaran < 1;
		}

		public override bool UseItem(Player player)
		{
			player.statManaMax2 += 100;
			player.statMana += 100;
			player.GetModPlayer<AlchemistNPCPlayer>().Fuaran += 1;
			return true;
		}
	}
}
