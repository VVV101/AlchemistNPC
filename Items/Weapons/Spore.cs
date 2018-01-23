using System;
using AlchemistNPC.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Spore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore (O-04-66)");
			Tooltip.SetDefault("The spear, covered with spores and attention."
			+ "\nIt expands mind, shines like a star and gradually becomes closer to weilder."
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nIts attack hits enemy several times"
			+ "\nAfter certain amount of hits releases damaging spores into enemy");
			DisplayName.AddTranslation(GameCulture.Russian, "Спора (O-04-66)");
			Tooltip.AddTranslation(GameCulture.Russian, "Копьё, покрытое спорами и вниманием.\nОно раскрывает разум, сияет словно звезда и постепенно сближается с носителем.\n[c/FF0000:Э.П.О.С. оружие]\nЕго атаки наносят урон противнику несколько раз\nПри нанесении определённого количество ударов выпускает атакующие споры во врага"); 
		}

		public override void SetDefaults()
		{
			item.damage = 55;
			item.useStyle = 5;
			item.useAnimation = 20;
			item.useTime = 25;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = 6;
			item.value = Item.sellPrice(gold: 50);

			item.magic = true;
			item.mana = 4;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("Spore");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 25);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1; 
		}
	}
}
