using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class BrewerHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brewer Horcrux");
			Tooltip.SetDefault("The piece of Brewer's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Варщицы Зелий");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Варщицы Зелий находится внутри"); 
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.maxStack = 30;
			item.value = 15000;
			item.rare = 6;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("Brewer"));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Brewer"));
			return true;
		}
	}
}