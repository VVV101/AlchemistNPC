using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Pandora : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nBase form 422: Launches sharp shuriken, which sticks to enemies."
			+"\nAttacking fills Disaster Gauge"
			+"\nFull gauge allows you to switch weapon's form"
			+"\nRight click to change form");
			DisplayName.AddTranslation(GameCulture.Russian, "Пандора");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nБазовая форма 422: Запускает бритвенно-острый сюрикен, цепляющийся за противников\nПри наборе полной шкалы Бедствия вы можете сменить форму Пандоры\nНажмите правую кнопку мыши для смены формы");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉");
            Tooltip.AddTranslation(GameCulture.Chinese, "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n基础形态 422: 发射锋利的手里剑, 能粘在敌人身上"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换形态");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.PiranhaGun);
			item.ranged = false;
			item.thrown = true;
			item.damage = 125;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.rare = 12;
			item.knockBack = 8;
			item.shoot = mod.ProjectileType("PF422");
		}

		public override void HoldItem(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).PH = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge += 33;
			if (player.altFunctionUse != 2)
			{
				type = mod.ProjectileType("PF422");
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			return false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				return true;
			}
			if (player.altFunctionUse == 2 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge < 500)
			{
				return false;
			}
			if (player.altFunctionUse == 2 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge >= 500)
			{
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge = 0;		
				item.SetDefaults(mod.ItemType("PandoraPF013"));
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PandoraPF422");
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 10);
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