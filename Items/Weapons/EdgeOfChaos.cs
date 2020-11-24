using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class EdgeOfChaos : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Edge of Chaos");
			Tooltip.SetDefault("Swing of this blade may tear reality in half"
			+"\nInflicts Chaos State debuff on hit");
			DisplayName.AddTranslation(GameCulture.Russian, "Грань Хаоса");
            Tooltip.AddTranslation(GameCulture.Russian, "Взмах этого меча может разорвать реальность надвое\nНакладывает Хаотическое Состояние на цель");
			DisplayName.AddTranslation(GameCulture.Chinese, "混沌边缘");
			Tooltip.AddTranslation(GameCulture.Chinese, "剑刃足以撕裂现实"
			+"\n攻击造成混沌状态Debuff");

		}

		public override void SetDefaults()
		{
			item.damage = 33333;
			item.melee = true;
			item.width = 66;
			item.height = 66;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.buyPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.buffImmune[mod.BuffType("ChaosState")] = false;
			target.AddBuff(mod.BuffType("ChaosState"), 1800);
			Projectile.NewProjectile(target.position.X, target.position.Y, 0f, 0f, mod.ProjectileType("ExplosionAvenger"), damage, 0, Main.myPlayer);
		}
	}
}
