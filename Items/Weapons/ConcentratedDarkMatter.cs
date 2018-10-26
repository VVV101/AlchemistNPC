using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ConcentratedDarkMatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Concentrated Dark Matter");
			Tooltip.SetDefault("Requred to shoot from Portal Gun");
			DisplayName.AddTranslation(GameCulture.Russian, "Концентрированная Тёмная Материя");
            Tooltip.AddTranslation(GameCulture.Russian, "Необходима для стрельбы из Портальной Пушки");
        }

		public override void SetDefaults()
		{
			item.damage = 1;
			item.ranged = true;
			item.width = 14;
			item.height = 22;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 10;
			item.shoot = mod.ProjectileType("PortalGunProj");
			item.ammo = item.type;
		}
	}
}
