using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Summoning
{
	public class MusicianHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Musician Horcrux");
			Tooltip.SetDefault("The piece of Musician's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Музыканта");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Музыканта находится внутри");
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
			item.makeNPC = (short)mod.NPCType("Musician");
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("Musician"));
		}
		
		public override void OnConsumeItem(Player player)
		{
			Main.NewText("A Musician is spawned.", 255, 255, 255);
		}
	}
}