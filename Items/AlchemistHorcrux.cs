using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class AlchemistHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Horcrux");
			Tooltip.SetDefault("The piece of Alchemist's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Алхимика");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Алхимика находится внутри"); 
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
			return !NPC.AnyNPCs(mod.NPCType("Alchemist"));
		}

		public override bool UseItem(Player player)
		{
			NPC.NewNPC((int)player.Center.X+2, (int)player.Center.Y, mod.NPCType("Alchemist"));
			return true;
		}
	}
}