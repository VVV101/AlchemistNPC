using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class TrueSasscade : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetDefaults()
		{
		item.CloneDefaults(3389);
		item.damage = 200;
		item.shoot = mod.ProjectileType("TrueSasscadeYoyo");
		item.knockBack = 4;
		item.value = 5000000;
		item.rare = 11;
		item.shootSpeed = 12f;
		item.useTime = 10;
		item.useAnimation = 10;
		}

		public override void UpdateEquip(Player player)
		{
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void UpdateInventory(Player player)
		{
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void HoldItem(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).TS = true;
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Sasscade Yo-Yo");
			Tooltip.SetDefault("Legendary Yo-Yo"
			+"\nShoots homing Nebula Arcanums to nearby enemies"
			+"\nGives effects of Yo-yo Bag while placed in inventory or being held");
			DisplayName.AddTranslation(GameCulture.Russian, "Истинный Сасскад");
            Tooltip.AddTranslation(GameCulture.Russian, "Легендарное Йо-йо\nСтреляет Арканумами Туманности в ближайших противников\nДаёт эффекты сумки Йо-Йо если находится в инвентаре или в руках");
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Sasscade");
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 15);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 10);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
