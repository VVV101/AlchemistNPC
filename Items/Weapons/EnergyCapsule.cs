using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class EnergyCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Capsule");
			Tooltip.SetDefault("Requred to shoot from Portal Gun");
			DisplayName.AddTranslation(GameCulture.Russian, "Капсула с энергией");
            Tooltip.AddTranslation(GameCulture.Russian, "Необходима для стрельбы из Портальной Пушки");
			DisplayName.AddTranslation(GameCulture.Chinese, "能量胶囊");
			Tooltip.AddTranslation(GameCulture.Chinese, "传送枪射击所需");
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
