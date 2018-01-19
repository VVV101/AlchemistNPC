using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class WatcherAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Watcher Amulet");
			Tooltip.SetDefault("No wonder it had an oddly shaped amulet in the middle."
				+ "\nBy obtaining certain essentials you have awakened the true form of this amulet."
				+ "\nWhat unearthly powers does it have? No one knows.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(25, 12));
			DisplayName.AddTranslation(GameCulture.Russian, "Дозорный Амулет");
			Tooltip.AddTranslation(GameCulture.Russian, "Неудивательно, что он имел амулет странной формы в середине.\nДобыв необходимые материалы, вы пробудили его истинную силу.\nКакую невероятную мощь он имеет в себе? Никто не знает."); 
		}    
		public override void SetDefaults()
		{
			item.damage = 500;
			item.mana = 100;
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.knockBack = 10f;
			item.value = Item.buyPrice(10, 0, 0, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("WatcherCrystal");
			item.summon = true;
			item.sentry = true;
			item.buffType = mod.BuffType("WatcherCrystal");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OtherworldlyAmulet", 1);
			recipe.AddRecipeGroup("AlchemistNPC:Tier3Bar", 25);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.ShroomiteBar, 25);
			recipe.AddIngredient(ItemID.SpectreBar, 25);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ItemID.LunarOre, 25);
			recipe.AddIngredient(ItemID.FragmentStardust, 20);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			for (int l = 0; l < Main.projectile.Length; l++)
			{
				Projectile proj = Main.projectile[l];
				if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
				{
					proj.active = false;
				}
			}
			return player.altFunctionUse != 2;
		}
	}
}
