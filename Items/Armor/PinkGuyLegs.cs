using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class PinkGuyLegs : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Guy's Leggings");
			DisplayName.AddTranslation(GameCulture.Russian, "Штаны Розового Парня"); 
			Tooltip.SetDefault("The perfect pants for leg day. May even make you stronger.");
			Tooltip.AddTranslation(GameCulture.Russian, "Превосходные штаны для трудного дня. Возможно, могут даже сделать вас сильнее."); 
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 16;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}