using System;
using AlchemistNPC.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class GrinderMK4 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grinder MK4 (T-05-41)");
			Tooltip.SetDefault("''The sharp teeth of the grinder makes a clean cut through the enemy.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nIts attack goes through enemy invincibility frames"
			+ "\nAfter certain amount of hits releases broken blades into enemies");
			DisplayName.AddTranslation(GameCulture.Russian, "Дробильщик MK4 (T-05-41)");
			Tooltip.AddTranslation(GameCulture.Russian, "Острые зубы этого дробильщика способны сделать чистый разрез сквозь врага.\n[c/FF0000:Э.П.О.С. оружие]\nЕго атаки проходят сквозь период неуязвимости противника\nПри нанесении определённого количество ударов выпускает отработавшие лезвия во врагов"); 
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.useStyle = 5;
			item.useAnimation = 24;
			item.useTime = 30;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = 6;
			item.value = Item.sellPrice(gold: 50);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("GrinderMK4");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
					{
					item.damage = 200;
					}
					else
					{
					item.damage = 35;
					}
			return player.ownedProjectileCounts[item.shoot] < 1; 
		}
	}
}
