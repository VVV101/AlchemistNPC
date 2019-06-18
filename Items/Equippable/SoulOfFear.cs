using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class SoulOfFear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Of Fear");
			Tooltip.SetDefault("''I am fear!''"
				+ "\nWeakening nearby enemies, inflicting several debuffs");
				DisplayName.AddTranslation(GameCulture.Russian, "Душа Страха");
            Tooltip.AddTranslation(GameCulture.Russian, "''Я - страх''\nБлижайшие враги ослабляются, получая целый комплек дебаффов");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 26;
			item.height = 26;
			item.value = 100000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Fear"), 0, 0, player.whoAmI);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFright, 99);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}