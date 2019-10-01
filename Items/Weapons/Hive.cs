using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class Hive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive");
			Tooltip.SetDefault("''NOT THE BEES!''"
			+"\nShoots beehive, which is spreading bees around it"
			+"\nBreaks on collide, releasing even more bees"
			+"\nBoosted stats will be shown after the first use");
			DisplayName.AddTranslation(GameCulture.Russian, "Улей");
            Tooltip.AddTranslation(GameCulture.Russian, "''ТОЛЬКО НЕ ПЧЁЛЫ!''\nВыстреливает ульем, испускающим пчёл вокруг\nЛомается при столкновении, выпуская ещё больше пчёл");
			DisplayName.AddTranslation(GameCulture.Chinese, "蜂巢");
			Tooltip.AddTranslation(GameCulture.Chinese, "''NOT THE BEES!''"
			+"\n发射蜂巢, 在周围传播蜜蜂"
			+"\n碰撞时破坏, 释放更多蜜蜂"
			+"\n提升过后的属性将会在使用后显示");
			Item.staff[item.type] = true;
        }

		public override void SetDefaults()
		{
			item.useTime = 40;
			item.useAnimation = 40;
			item.damage = 52;
			item.magic = true;
			item.mana = 15;
			item.rare = 11;
			item.width = 40;
			item.height = 40;
			item.UseSound = SoundID.Item20;
			item.useStyle = 5;
			item.shootSpeed = 11f; 
			item.knockBack = 4;
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Hive");
		}
	}
}
