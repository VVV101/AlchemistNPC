using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class MGB : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("17mm Round");
			Tooltip.SetDefault("Requred to shoot from ''Meat Grinder''");
			DisplayName.AddTranslation(GameCulture.Russian, "17mm патрон");
            Tooltip.AddTranslation(GameCulture.Russian, "Необходим для стрельбы из ''Мясорубки''");
			DisplayName.AddTranslation(GameCulture.Chinese, "17mm 子弹");
			Tooltip.AddTranslation(GameCulture.Chinese, "''绞肉机'' 射击所需");
        }

		public override void SetDefaults()
		{
			item.damage = 1;
			item.ranged = true;
			item.width = 14;
			item.height = 22;
			item.maxStack = 9999;
			item.consumable = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 12;
			item.shoot = 638;
			item.ammo = item.type;
		}
	}
}
