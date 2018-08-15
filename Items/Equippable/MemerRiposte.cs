using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class MemerRiposte : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Memer's Riposte");
			Tooltip.SetDefault("Mirrors 500% of damage back to all enemies on screen"
			+ "\nIncrease all damage by 15%"
			+ "\nCuts your critical strike chance by half, but they can deal 4x damage"
			+ "\nWeakens any hostile memes");
				DisplayName.AddTranslation(GameCulture.Russian, "Ответ Мемеру");
            Tooltip.AddTranslation(GameCulture.Russian, "Отражает 500% урона обратно всем противникам на экране\nУвеличивает весь урон на 15%\nУменьшает ваш шанс критического удара вдвое, но крит может нанести 4-х кратный урон\nОслабляет любые враждебные мемы");
            DisplayName.AddTranslation(GameCulture.Chinese, "Memer的反击");
            Tooltip.AddTranslation(GameCulture.Chinese, "反弹500%的伤害\n增加15%全伤害\n暴击几率减半, 但是暴击能造成4倍伤害");
        }
	
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thrownDamage += 0.15f;
            player.meleeDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.minionDamage += 0.15f;
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2 == false)
			{
			player.meleeCrit /= 2;
			player.magicCrit /= 2;
			player.rangedCrit /= 2;
			player.thrownCrit /= 2;
			player.meleeCrit -= 5;
			player.magicCrit -= 5;
			player.rangedCrit -= 5;
			player.thrownCrit -= 5;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2)
			{
			player.meleeCrit /= 2;
			player.magicCrit /= 2;
			player.rangedCrit /= 2;
			player.thrownCrit /= 2;
			player.meleeCrit += 10;
			player.magicCrit += 10;
			player.rangedCrit += 10;
			player.thrownCrit += 10;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
			}
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MemersRiposte = true;
		}
		
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.15f;
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2 == false)
				{
				RedemptionPlayer.druidCrit /= 2;
				}
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2)
				{
				RedemptionPlayer.druidCrit /= 2;
				RedemptionPlayer.druidCrit += 10;
				}
        }
		
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.15f;
			ThoriumPlayer.radiantBoost += 0.15f;
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2 == false)
				{
				ThoriumPlayer.symphonicCrit /= 2;
				ThoriumPlayer.radiantCrit /= 2;
				}
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2)
				{
				ThoriumPlayer.symphonicCrit /= 2;
				ThoriumPlayer.radiantCrit /= 2;
				ThoriumPlayer.symphonicCrit += 10;
				ThoriumPlayer.radiantCrit += 10;
				}
        }
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "KnucklesUgandaDoll", 1);
			recipe.AddIngredient(null, "BanHammer", 1);
			recipe.AddIngredient(null, "PinkGuyHead", 1);
			recipe.AddIngredient(null, "PinkGuyBody", 1);
			recipe.AddIngredient(null, "PinkGuyLegs", 1);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}