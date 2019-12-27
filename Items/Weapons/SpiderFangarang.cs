using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Weapons
{
	public class SpiderFangarang : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spider Fangarang");
            Tooltip.SetDefault("Throws poisoning boomerang\nCan stack up to 3");
            DisplayName.AddTranslation(GameCulture.Russian, "Паучий Клыкоранг");
            Tooltip.AddTranslation(GameCulture.Russian, "Бросает отравляющий бумеранг\nМожет складываться до 3");

            DisplayName.AddTranslation(GameCulture.Chinese, "蛛牙回旋镖");
            Tooltip.AddTranslation(GameCulture.Chinese, "投掷涂毒回旋镖\n可以堆叠3个");
        }    
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Bananarang);
			item.damage = 21;
			item.melee = false;
			item.thrown = true;
			item.rare = 2;
			item.value = 3333;
			item.useTime = 20;
			item.useAnimation = 20;
			item.maxStack = 3;
			item.shoot = mod.ProjectileType("SpiderFangarang");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.ownedProjectileCounts[mod.ProjectileType("SpiderFangarang")] < item.stack)
			{
				return true;
			}
			return false;
		}
	}
}