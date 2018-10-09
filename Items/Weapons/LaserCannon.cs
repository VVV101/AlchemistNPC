using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class LaserCannon : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Cannon");
			Tooltip.SetDefault("Shoots homing exploding energy balls"
			+ "\nDoes not require ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "Лазерная Пушка");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает самонаводящиеся взрывающиеся энергетические шары\nНе требует патронов");
        }

		public override void SetDefaults()
		{
			item.damage = 333;
			item.ranged = true;
			item.width = 44;
			item.height = 38;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item92;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LaserCannon"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
		}
	}
}
