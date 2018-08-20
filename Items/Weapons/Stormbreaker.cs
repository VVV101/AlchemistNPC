using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;

namespace AlchemistNPC.Items.Weapons
{
	public class Stormbreaker : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Forged to fight the most powerful beings in the universe. Wield it wisely.");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(3858);
			item.melee = true;
			item.damage = 100;
			item.crit = 21;
			item.width = 50;
			item.height = 40;
			item.hammer = 600;
			item.axe = 120;
			item.value = 10000000;
			item.rare = 11;
            item.knockBack = 10;
			item.expert = true;
			item.scale = 1.5f;
			item.shoot = mod.ProjectileType("StormbreakerSwing");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				item.shoot = mod.ProjectileType("StormbreakerSwing");
			}
			if (player.altFunctionUse == 2)
			{
				item.useTime = 15;
				item.useAnimation = 15;
				item.damage = 150;
				item.shootSpeed = 24f;
				item.shoot = mod.ProjectileType("Stormbreaker");
				item.noMelee = true;
				item.noUseGraphic = true;
			}
			
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NimbusRod);
			recipe.AddRecipeGroup("AlchemistNPC:AnyLunarHamaxe");
			recipe.AddIngredient(ItemID.MoltenHamaxe);
			recipe.AddIngredient(ItemID.MeteorHamaxe);
			recipe.AddIngredient(ItemID.LivingWoodWand);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
