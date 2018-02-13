using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class somebody0214Robe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("somebody0214's Robe");
			Tooltip.SetDefault("Great for impersonating a Sun Praiser!");
			DisplayName.AddTranslation(GameCulture.Russian, "Роба somebody0214");
			Tooltip.AddTranslation(GameCulture.Russian, "Отлично подходит для подражания Молящемуся Солнцу"); 
		}
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 14;
			item.rare = -11;
			item.vanity = true;
		}

		public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
		{
			robes = true;
			equipSlot = mod.GetEquipSlot("somebody0214Robe_Legs", EquipType.Legs);
		}
		
		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}
	}
}
