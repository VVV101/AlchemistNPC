using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
	public class DarkMagicWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Magic Wand");
			Tooltip.SetDefault("Royal Dark Magic Wand"
			+"\nShoots wide beam that can eliminate everything on its way."
			+"\nThe longer you are holding the beam, the more powerful it becomes"
			+"\nMana cost grows respectively");
			DisplayName.AddTranslation(GameCulture.Russian, "Тёмная Волшебная Палочка");
            Tooltip.AddTranslation(GameCulture.Russian, "Королевская Тёмная Волшебная Палочка\nИспускает широкий луч, который способен уничтожить всё на своём пути\nЧем дольше удерживается луч, тем мощнее он становится\nЗатраты маны увеличиваются соответственно");

            DisplayName.AddTranslation(GameCulture.Chinese, "魔杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "皇家魔杖\n发射一束能消灭一切的激光束\n激光持续时间越长, 威力越强\n法力消耗分别增加");
        }

		public override void SetDefaults()
		{
			item.damage = 150;
			item.noMelee = true;
			item.magic = true;
			item.channel = true;                            //Channel so that you can held the weapon [Important]
			item.mana = 10;
			item.rare = ItemRarityID.Purple;
			item.width = 30;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 14f;
			item.useAnimation = 20;   
			item.knockBack = 1;			
			item.shoot = mod.ProjectileType("MagicWandC");
			item.value = Item.sellPrice(1, 0, 0, 0);
		}
		
		public override void UseStyle(Player player)
		{
			item.damage = 150;
			item.mana = 10;
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime++;
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime >= 390)
			{
				item.damage = 250;
				item.mana = 30;
				player.moveSpeed *= 0.50f;
			}
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime >= 210)
			{
				item.damage = 200;
				item.mana = 20;
				player.moveSpeed *= 0.8f;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagicWand");
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 15);
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
