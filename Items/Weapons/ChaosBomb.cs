using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChaosBomb : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 11111;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 1;
			item.consumable = false;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("ChaosBomb");
			item.shootSpeed = 16f;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Bomb");
			Tooltip.SetDefault("CHAOS! CHAOS!"
			+"\nExplodes on contact, releasing random chaos");
			
			DisplayName.AddTranslation(GameCulture.Russian, "Хаотическая Бомба");
			Tooltip.AddTranslation(GameCulture.Russian, "ХАОС! ХАОС!\nВзрывается при касании, производя случайный хаос");
			DisplayName.AddTranslation(GameCulture.Chinese, "混沌爆弹");
			Tooltip.AddTranslation(GameCulture.Chinese, "混·沌! 混·沌!"
			+"\n接触时爆炸, 释放随机混沌");
        }
	}
}
