using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class MemerRiposte : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Memer's Riposte");
			Tooltip.SetDefault("Mirrors 500% of damage back to all enemies on screen"
			+ "\nIncrease all damage by 15%"
			+ "\nCuts your critical strike chance by 25%, but they can deal 4x damage"
			+ "\nWeakens any hostile memes");
				DisplayName.AddTranslation(GameCulture.Russian, "Ответ Мемеру");
            Tooltip.AddTranslation(GameCulture.Russian, "Отражает 500% урона обратно всем противникам на экране\nУвеличивает весь урон на 15%\nУменьшает ваш шанс критического удара вдвое, но крит может нанести 4-х кратный урон\nОслабляет любые враждебные мемы");
            DisplayName.AddTranslation(GameCulture.Chinese, "Memer的反击");
            Tooltip.AddTranslation(GameCulture.Chinese, "反弹500%的伤害\n增加15%全伤害\n暴击率减半, 但是暴击能造成4倍伤害\n削弱敌对meme");
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
			player.allDamage += 0.15f;
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2 == false)
			{
			player.meleeCrit -= 25;
			player.magicCrit -= 25;
			player.rangedCrit -= 25;
			player.thrownCrit -= 25;
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
				RedemptionBoost(player);
				}
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2)
			{
			player.meleeCrit -= 15;
			player.magicCrit -= 15;
			player.rangedCrit -= 15;
			player.thrownCrit -= 15;
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
				RedemptionBoost(player);
				}
			}
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MemersRiposte = true;
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				Calamity.Call("AddRogueCrit", player, -25);
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2) Calamity.Call("AddRogueCrit", player, 10);
			}
		}
		
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2 == false)
				{
				RedemptionPlayer.druidCrit -= 25;
				}
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2)
				{
				RedemptionPlayer.druidCrit -= 15;
				}
        }
		
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2 == false)
				{
				ThoriumPlayer.symphonicCrit -= 25;
				ThoriumPlayer.radiantCrit -= 25;
				}
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2)
				{
				ThoriumPlayer.symphonicCrit -= 15;
				ThoriumPlayer.radiantCrit -= 15;
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