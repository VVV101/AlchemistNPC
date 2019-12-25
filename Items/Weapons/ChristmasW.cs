using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;

namespace AlchemistNPC.Items.Weapons
{
	public class ChristmasW : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Christmas (F-02-49)");
			Tooltip.SetDefault("''It is patched with heavy leather. No one knows where the leather came from though."
			+ "\nIts true identity under the leather is classified, but its secrecy only makes the weapon all the more powerful.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nCauses some ornament balls to fall from the sky on swing"
			+ "\nGives 3% chance to get Present from any enemy as drop");
			DisplayName.AddTranslation(GameCulture.Russian, "Рождество (F-02-49)");
            Tooltip.AddTranslation(GameCulture.Russian, "''Он запечатан в крепкую кожи. Никто не знает, откуда она.\nЧто находится под ней - неизвестно, но эта таинственность лишь делает оружие сильнее.''\n[c/FF0000:Оружие Э.П.О.С.]\nВызывает падение нескольких ёлочных украшений при взмахе\nДаёт 3% шанс на получение подарка при убийстве любого противника");
			DisplayName.AddTranslation(GameCulture.Chinese, "悲惨圣诞 (F-02-49)");
			Tooltip.AddTranslation(GameCulture.Chinese, "''掩盖在层层厚皮下的真相绝不能被人知道."
			+"\n对真相的刻意隐瞒只会使这把武器更加强大.''"
			+"\n[c/FF0000:EGO 武器]"
			+"\n挥舞时从天上掉落装饰球"
			+"\n任何敌人都有3%概率掉落礼物");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);
			item.melee = true;
			item.damage = 33;
			item.width = 78;
			item.height = 106;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.value = 50000;
			item.rare = 3;
            item.knockBack = 6;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1f;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
				item.damage = 150;
				item.useTime = 20;
				item.useAnimation = 20;
			}
			else
			{
				item.damage = 33;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 335;
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
				Projectile.NewProjectile(position.X+Main.rand.Next(-75,75), position.Y+Main.rand.Next(-75,75), speedX, speedY, type, damage, 3, player.whoAmI);
				Projectile.NewProjectile(position.X+Main.rand.Next(-100,100), position.Y+Main.rand.Next(-100,100), speedX, speedY, type, damage, 3, player.whoAmI);
				Projectile.NewProjectile(position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), speedX, speedY, type, damage/2, 3, player.whoAmI);
				Projectile.NewProjectile(position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), speedX, speedY, type, damage/2, 3, player.whoAmI);
			}
			else
			{
				damage /= 2;
				Projectile.NewProjectile(position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), speedX, speedY, type, damage/2, 3, player.whoAmI);
				Projectile.NewProjectile(position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), speedX, speedY, type, damage/2, 3, player.whoAmI);
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 56);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 5);
			recipe.AddRecipeGroup("AlchemistNPC:EvilBar", 5);
			recipe.AddIngredient(ItemID.BorealWood, 25);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 15);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
