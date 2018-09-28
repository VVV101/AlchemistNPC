using Terraria.Localization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Items.Summoning
{
	public class HorrifyingSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horrifying Skull");
			Tooltip.SetDefault("Summons the mightiest enemy"
			+"\nUse with the extreme care");
			DisplayName.AddTranslation(GameCulture.Russian, "Пугающий Череп");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает могущественного противника\nИспользовать с крайней осторожностью");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 100;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.DungeonGuardian);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
	}
}