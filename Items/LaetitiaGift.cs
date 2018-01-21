using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	[AutoloadEquip(EquipType.Neck)]
	public class LaetitiaGift : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laetitia Gift (O-01-67-1)");
			Tooltip.SetDefault("She says that she has many friends, but they can't come with you. So she came up with this brilliant idea!"
			+ "\n[c/FF0000:EGO Gift/Weapon]"
			+ "\n[c/FF0000:Warning!!! Will slowly consume your life if Little Witch Monster is not summoned]"
			+ "\nAllows to summon Little Witch Monster if full set of Laetitia EGO armor is on"
			+ "\nLittle Witch Monster will dissapear if EGO armor set is not on"
			+ "\nIncreases maximum amount of minions by 5");
			DisplayName.AddTranslation(GameCulture.Russian, "Дар Летиции (O-01-67-1)");
			Tooltip.AddTranslation(GameCulture.Russian, "Она говорила, что у неё много друзей, но они не смогут пойти с тобой. И тогда ей пришла в голову блестящая идея!\n[c/FF0000:Э.П.О.С Дар/Оружие]\n[c/FF0000:Осторожно!!! Будет медленно пожирать ваше HP, если Монстр Маленькой Ведьмы не призван]\nПозволяет призвать Монстра Маленькой Ведьмы если одет полный сет Э.П.О.С брони Летиции.\nМонстр Маленькой Ведьмы пропадёт если если Э.П.О.С броня не одета\nУвеличивает максимальное число прислужников на 5"); 
		}
	
		public override void SetDefaults()
		{
			item.damage = 30;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("LittleWitchMonster");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("LittleWitchMonster");
			item.buffTime = 3600;
			item.accessory = true;
			
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			++player.maxMinions;
			++player.maxMinions;
			++player.maxMinions;
			++player.maxMinions;
			++player.maxMinions;
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).lwm == false)
			{
			player.lifeRegen -= 20;
			}
		}

		public override bool CanUseItem(Player player)
		{
			return (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).jr == true && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).lwm == false);
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpiderFang, 5);
			recipe.AddIngredient(ItemID.HallowedBar, 8);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}
	}
}