using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
	public class MarcoMagicWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[item.type] = true;
			DisplayName.SetDefault("Prince's Magic Wand");
			Tooltip.SetDefault("Magic Wand of Mewnian Prince"
			+"\nShoots wide beam that can eliminate everything on its way."
			+"\nThe longer you are holding the beam, the more powerful it becomes"
			+"\nMana cost grows respectively"
			+"\nRight click to launch kitten bombs");
			DisplayName.AddTranslation(GameCulture.Russian, "Волшебная Палочка Принца");
            Tooltip.AddTranslation(GameCulture.Russian, "Волшебная Палочка Принца Мьюни\nИспускает широкий луч, который способен уничтожить всё на своём пути\nЧем дольше удерживается луч, тем мощнее он становится\nЗатраты маны увеличиваются соответственно\nПравый клик для запуска бомб-котят");
			DisplayName.AddTranslation(GameCulture.Chinese, "王子的魔杖");
			Tooltip.AddTranslation(GameCulture.Chinese, "喵尼尔王子的魔杖"
			+"\n发射毁灭沿途一切事物的宽激光"
			+"\n激光持续时间越长, 威力越强"
			+"\n法力消耗分别增加"
			+"\n右键发射小猫炸弹");
        }

		public override void SetDefaults()
		{
			item.damage = 250;
			item.noMelee = true;
			item.magic = true;
			item.channel = true;                            //Channel so that you can held the weapon [Important]
			item.crit = 10;
			item.mana = 10;
			item.rare = 11;
			item.width = 30;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;   
			item.knockBack = 2;			
			item.shoot = mod.ProjectileType("MagicWandM");
			item.value = Item.sellPrice(3, 0, 0, 0);
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				item.damage = 250;
				item.shootSpeed = 14f;
				item.shoot = mod.ProjectileType("MagicWandM");
				item.channel = true;
				item.useTime = 20;
				item.useAnimation = 20;
			}
			if (player.altFunctionUse == 2)
			{
				item.damage = 2000;
				item.shootSpeed = 0f;
				item.shoot = mod.ProjectileType("DarkBomb");
				item.channel = false;
				item.useTime = 10;
				item.useAnimation = 10;
			}
			return base.CanUseItem(player);
		}
		
		public override void UseStyle(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				item.UseSound = SoundID.Item13;
				item.damage = 250;
				item.mana = 10;
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime++;
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime >= 390)
				{
					item.damage = 550;
					item.mana = 20;
					player.moveSpeed *= 0.8f;
				}
				else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime >= 210)
				{
					item.damage = 400;
					item.mana = 15;
					player.moveSpeed *= 0.9f;
				}
			}
			if (player.altFunctionUse == 2)
			{
				item.UseSound = SoundID.Item57;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				damage = 2000;
				Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				position = SPos;
				return true;
			}
			if (player.altFunctionUse != 2)
			{
				damage = 250;
				return true;
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkMagicWand");
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CosmiliteBar")), 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel")), 25);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy")), 25);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 500);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
