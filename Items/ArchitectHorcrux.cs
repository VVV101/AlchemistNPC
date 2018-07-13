using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class ArchitectHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Architect Horcrux");
			Tooltip.SetDefault("The piece of Architect's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Архитектора");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Архитектора находится внутри"); 
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
			item.UseSound = SoundID.Item37;
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("Architect"));
		}

		public override bool UseItem(Player player)
		{
			Main.NewText("Architect is spawned.", 255, 255, 255);
			NPC.NewNPC((int)player.Center.X+2, (int)player.Center.Y, mod.NPCType("Architect"));
			return true;
		}
	}
}