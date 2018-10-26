using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Buffs
{
	public class LittleWitchMonster : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Little Witch Monster");
			Description.SetDefault("So that's what it contained...");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Монстр Маленькой Ведьмы");
			Description.AddTranslation(GameCulture.Russian, "Так вот что было внутри...");
            DisplayName.AddTranslation(GameCulture.Chinese, "小巫怪");
            Description.AddTranslation(GameCulture.Chinese, "嗯，这就是它里面的东西...");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("LittleWitchMonster")] < 1)
			{
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.position.X-15, player.position.Y, vel.X, vel.Y, mod.ProjectileType("LittleWitchMonster"), 30, 3f, player.whoAmI);
				modPlayer.lwm = true;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}