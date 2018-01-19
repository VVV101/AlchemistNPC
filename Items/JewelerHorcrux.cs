using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class JewelerHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jeweler Horcrux");
			Tooltip.SetDefault("The piece of Jeweler's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Ювелира");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Ювелира находится внутри"); 
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
			return !NPC.AnyNPCs(mod.NPCType("Jeweler"));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Jeweler"));
			return true;
		}
	}
}