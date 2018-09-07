using Terraria;
using Terraria.ID;
using System.Linq;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Wings)]
	public class MechanicalWings : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Wings");
			Tooltip.SetDefault("Allows to flight"
			+ "\nShooting nearby enemies with deadly laser");
			DisplayName.AddTranslation(GameCulture.Russian, "Механические Крылья");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяют летать\nСтреляют в ближайших противников лазерами");
        }

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 1000000;
			item.rare = 8;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accRunSpeed = 2f;
            player.moveSpeed = player.moveSpeed + 0.08f;
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