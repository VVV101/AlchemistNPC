using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class WatcherAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Watcher Amulet");
			Tooltip.SetDefault("No wonder it had an oddly shaped amulet in the middle."
				+ "\nBy obtaining certain essentials you have awakened the true form of this amulet."
				+ "\nWhat unearthly powers does it have? Nobody knows.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(25, 12));
			DisplayName.AddTranslation(GameCulture.Russian, "Дозорный Амулет");
            Tooltip.AddTranslation(GameCulture.Russian, "Неудивительно, что он имел амулет странной формы в середине.\nДобыв необходимые материалы, вы пробудили его истинную силу.\nКакую невероятную мощь он имеет в себе? Никто не знает.");

            DisplayName.AddTranslation(GameCulture.Chinese, "凝视者护符");
            Tooltip.AddTranslation(GameCulture.Chinese, "怪不得中间有个奇形怪状的护身符.\n通过某种方式, 你唤醒了这个护身符的真实形态.\n它拥有怎样的可怕力量？没人知道.");
        }    
		public override void SetDefaults()
		{
			item.damage = 250;
			item.mana = 100;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.knockBack = 10;
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
			recipe.AddIngredient(null, "AlchemicalBundle", 1);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			if (player.ownedProjectileCounts[mod.ProjectileType("WatcherCrystal")] < player.maxTurrets)
			{
				return true;
			}
			else
			{
				return false;
			}
			return false;
		}
	}
}
