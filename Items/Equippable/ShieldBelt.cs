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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield Belt");
			Tooltip.SetDefault("Allows you to take less damage depending on belt's charge"
			+"\nMaximal damage reduction is 150"
			+"\nConsumes belt charge while getting hit"
			+"\nDamage reduction is weaker on Revengeance/Death Mode:"
			+"\nDamage cannot be lower than 30");
			DisplayName.AddTranslation(GameCulture.Russian, "Щитовой пояс");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяет вам получать меньше урона в зависимости от заряда щита\nМаксимальное уменьшение урона равно 150\nТратит часть заряда после получения удара\nНа уровне сложности Возмездие/Смерть снижение урона ослаблено:\nМинимальный полученный урон равен 30");
            DisplayName.AddTranslation(GameCulture.Chinese, "防护盾带");
            Tooltip.AddTranslation(GameCulture.Chinese, "根据盾代充能减免伤害\n最大减免伤害150\n被攻击时消耗盾带充能\n在复仇/死亡模式下, 减弱伤害减免\n所减免伤害不得低于30");
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
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ShieldBelt = true;
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Shield < 150)
			{
				if (Main.rand.Next(4) == 0)
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Shield++;
			}
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