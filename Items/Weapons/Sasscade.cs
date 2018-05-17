using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Sasscade : ModItem
	{
		public override void SetDefaults()
		{
		item.CloneDefaults(3389);
		item.damage = 150;
		item.shoot = mod.ProjectileType("SasscadeYoyo");
		item.knockBack = 4;
		item.value = 5000000;
		item.rare = 11;
		item.shootSpeed = 32f;
		item.useTime = 10;
		item.useAnimation = 10;
		}

		public override void UpdateEquip(Player player)
		{
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void UpdateInventory(Player player)
		{
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void HoldItem(Player player)
		{
		player.counterWeight = 556 + Main.rand.Next(6);
        player.yoyoGlove = true;
        player.yoyoString = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sasscade Yo-Yo");
			Tooltip.SetDefault("Legendary Yo-Yo"
			+"\nShoots homing Nebula Blazes to nearby enemies"
			+"\nBlazes destroy enemies with less than 10K HP and inflict heavy damaging debuff"
			+"\nGives effects of Yo-yo Bag while placed in inventory or being held");
			DisplayName.AddTranslation(GameCulture.Russian, "Сасскад");
			Tooltip.AddTranslation(GameCulture.Russian, "Легендарное Йо-йо\nСтреляет самонаводящимися снарядами в ближайших противников\nСнаряды убивают противников, имеющих менее 10К здоровья и накладывают мощный дебафф\nДаёт эффекты сумки Йо-Йо если находится в инвентаре или в руках"); 
		}
	}
}
