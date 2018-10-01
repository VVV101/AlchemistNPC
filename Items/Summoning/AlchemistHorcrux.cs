using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Summoning
{
	public class AlchemistHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Horcrux");
			Tooltip.SetDefault("The piece of Alchemist's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Алхимика");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Алхимика находится внутри");

            DisplayName.AddTranslation(GameCulture.Chinese, "炼金师魂器");
            Tooltip.AddTranslation(GameCulture.Chinese, "里面有炼金师的一片灵魂");
        }

		public override void SetDefaults()
		{
			item.width = 46;
            item.height = 42;
            item.maxStack = 1;
            item.rare = 10;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.consumable = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item37;
			item.makeNPC = (short)mod.NPCType("Alchemist");
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("Alchemist"));
		}
		
		public override void OnConsumeItem(Player player)
		{
			Main.NewText("An Alchemist is spawned.", 255, 255, 255);
		}
	}
}