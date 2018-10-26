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

            DisplayName.AddTranslation(GameCulture.Chinese, "somebody0214的长袍");
            Tooltip.AddTranslation(GameCulture.Chinese, "非常适合扮演太阳歌颂者!");
        }
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 14;
			item.rare = -11;
			item.value = 2500000;
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
