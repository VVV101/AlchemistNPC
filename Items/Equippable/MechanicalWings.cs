using Terraria;
using Terraria.ID;
using System.Linq;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Wings)]
	public class MechanicalWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Wings");
			Tooltip.SetDefault("Allows you to fly"
			+ "\nShoots deadly lasers at nearby enemies ");
			DisplayName.AddTranslation(GameCulture.Russian, "Механические Крылья");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяют летать\nСтреляют в ближайших противников лазерами");
            DisplayName.AddTranslation(GameCulture.Chinese, "机械翅膀");
            Tooltip.AddTranslation(GameCulture.Chinese, "允许飞行\n发射致命激光攻击附近敌人");
        }

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 1000000;
			item.rare = ItemRarityID.Yellow;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 120;
			player.AddBuff(mod.BuffType("LaserBattery"), 2);
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.135f;
		}
		
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 9f;
			acceleration *= 2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SteampunkWings);
			recipe.AddIngredient(ItemID.MechanicalBatteryPiece);
			recipe.AddIngredient(ItemID.XenoStaff);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
