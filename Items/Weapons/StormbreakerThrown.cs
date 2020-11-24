using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class StormbreakerThrown: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormbreaker");
			Tooltip.SetDefault("Forged to fight the most powerful beings in the universe. Wield it wisely."
			+"\nRight click in inventory to change damage type");
			
			DisplayName.AddTranslation(GameCulture.Russian, "Громобой");
			Tooltip.AddTranslation(GameCulture.Russian, "Выкован для противодействия самым мощным существам во вселенной. Используй его мудро.\nПравый клик в инвентаре меняет тип урона");
			DisplayName.AddTranslation(GameCulture.Chinese, "风暴战锤");
			Tooltip.AddTranslation(GameCulture.Chinese, "为了与宇宙中最强大的存在战斗而打造. 请明智地使用它."
			+"\n在物品栏中右键切换伤害类型");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MonkStaffT3);
			item.melee = false;
			item.thrown = true;
			item.damage = 110;
			item.crit = 21;
			item.width = 50;
			item.height = 40;
			item.hammer = 600;
			item.axe = 120;
			item.value = 10000000;
			item.rare = ItemRarityID.Purple;
            item.knockBack = 10;
			item.expert = true;
			item.scale = 1.5f;
			item.shoot = mod.ProjectileType("StormbreakerSwing");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				item.shoot = mod.ProjectileType("StormbreakerSwing");
			}
			if (player.altFunctionUse == 2)
			{
				item.useTime = 15;
				item.useAnimation = 15;
				item.damage = 150;
				item.shootSpeed = 24f;
				item.shoot = mod.ProjectileType("StormbreakerT");
				item.noMelee = true;
				item.noUseGraphic = true;
			}
			
			return base.CanUseItem(player);
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
			item.consumable = true;
            Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("Stormbreaker"), 1, false, 81);
        }
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 82;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NimbusRod);
			recipe.AddRecipeGroup("AlchemistNPC:AnyLunarHamaxe");
			recipe.AddIngredient(ItemID.MoltenHamaxe);
			recipe.AddIngredient(ItemID.MeteorHamaxe);
			recipe.AddIngredient(ItemID.LivingWoodWand);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
