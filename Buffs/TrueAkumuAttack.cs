using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TrueAkumuAttack : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Akumu");
			Description.SetDefault("Attacks nearby enemies");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Акуму");
			Description.AddTranslation(GameCulture.Russian, "Атакует ближайших противников");
            DisplayName.AddTranslation(GameCulture.Chinese, "Akumu");
            Description.AddTranslation(GameCulture.Chinese, "攻击附近敌人");
        }
		
		public bool CalamityModRevengeance
		{
        get { return CalamityMod.World.CalamityWorld.revenge; }
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (CalamityModRevengeance)
				{
					if (player.ownedProjectileCounts[mod.ProjectileType("AkumuSphere")] == 0)
					{
						for (int h = 0; h < 1; h++) {
						Vector2 vel = new Vector2(0, -1);
						vel *= 0f;
						Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType ("AkumuSphere"), 1500, 0, player.whoAmI);
						}
					}
				}
				else
				{
					if (player.ownedProjectileCounts[mod.ProjectileType("AkumuSphere")] == 0)
					{
						for (int h = 0; h < 1; h++) {
						Vector2 vel = new Vector2(0, -1);
						vel *= 0f;
						Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType ("AkumuSphere"), 1000, 0, player.whoAmI);
						}
					}
				}
			}
			if (ModLoader.GetMod("CalamityMod") == null)
			{
				if (player.ownedProjectileCounts[mod.ProjectileType("AkumuSphere")] == 0)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType ("AkumuSphere"), 1000, 0, player.whoAmI);
					}
				}
			}
		}
	}
}
