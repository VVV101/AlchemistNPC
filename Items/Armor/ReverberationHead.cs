using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ReverberationHead : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Reverberation Wreath (T-04-53)");
            DisplayName.AddTranslation(GameCulture.Russian, "Венок Реверберации (T-04-53)");
            Tooltip.SetDefault("The sleek surface is tough as if it had been cured several times."
            + "\n[c/FF0000:EGO armor piece]"
            + "\nIncreases ranged damage by 20%");
            Tooltip.AddTranslation(GameCulture.Russian, "Гладкая поверхность всё так же прочна, как будто не была восстановлена несколько раз.\n[c/FF0000:Э.П.О.С часть брони]\nПовышает урон в дальнем бою на 20%");

            DisplayName.AddTranslation(GameCulture.Chinese, "余香花环 (T-04-53)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'经过数次加工处理后, 这件护甲的表面变得光滑而又坚硬.'\n[c/FF0000:EGO 盔甲]\n增加20%远程伤害");

            ModTranslation text = mod.CreateTranslation("ReverberationSetBonus");
            text.SetDefault("Forms shield around weilder. Shield reduces all incoming damage by 15%\nSpeeds up all arrows\nImproves Reverberation Crossbow:\nLowers manacost for additional projectiles\nMakes crossbow shot multiple projectiles\nBoosts Druidic type damage and critical strike chance by 20%");
            text.AddTranslation(GameCulture.Russian, "Создаёт щит вокруг владельца. Щит уменьшает весь входящий урон на 15%\nУскоряет все стрелы\nУлучшает арбалет 'Реверберация'\nУменьшает затраты маны на выстрел дополнительными снарядами\nАрбалет будет выстреливать несколько дополнительных снарядов\nУведичивает Друидский тип урона и шанс критического удара на 20%");
            text.AddTranslation(GameCulture.Chinese, "在玩家周围形成一圈护盾. 护盾减少15%全部即将到来的伤害\n加速全部箭矢\n加强余香弩:\n降低额外子弹的魔法消耗\n让弩发射更多的子弹");
            mod.AddTranslation(text);
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 9;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage *= 1.2f;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ReverberationBody") && legs.type == mod.ItemType("ReverberationLegs");
		}

		public override void UpdateArmorSet(Player player)
		{
			string ReverberationSetBonus = Language.GetTextValue("Mods.AlchemistNPC.ReverberationSetBonus");
			player.setBonus = ReverberationSetBonus;
			player.magicQuiver = true;
			player.AddBuff(mod.BuffType("ShieldofSpring"), 300);
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).RevSet = true;
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
		}
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.1f;
            RedemptionPlayer.druidCrit += 8;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.1f;
            ThoriumPlayer.symphonicCrit += 8;
			ThoriumPlayer.radiantBoost += 0.1f;
            ThoriumPlayer.radiantCrit += 8;
        }
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(ItemID.DynastyWood, 100);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}