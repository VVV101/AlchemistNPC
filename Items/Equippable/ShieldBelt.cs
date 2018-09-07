using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Waist)]
	public class ShieldBelt : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield Belt");
			Tooltip.SetDefault("Allows you to take less damage depending on belt's charge"
			+"\nMaximal damage reduction is 150"
			+"\nConsumes belt charge while getting hit"
			+"\nDamage reduction is weaker on Revengeance/Death Mode:"
			+"\nDamage cannot be lower than 30");
			DisplayName.AddTranslation(GameCulture.Russian, "Щитовой пояс");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяет вам получать меньше урона в зависимости от заряда щита\nМаксимальное уменьшение урона равно 150\nТратит часть заряд после получения удара\nНа уровне сложности Возмездие снижение урона ослаблено:\nНе менее 30 урона может быть получено");
        }
	
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("ShieldBelt"), 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BlackBelt);
			recipe.AddIngredient(null, "ChromaticCrystal", 5);
			recipe.AddIngredient(null, "SunkroveraCrystal", 5);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}