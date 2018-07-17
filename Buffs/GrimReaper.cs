using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class GrimReaper : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Grim Reaper");
			Description.SetDefault("Hello! My name's Gregg, the Grim Reaper – and don't laugh!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Жнец");
            DisplayName.AddTranslation(GameCulture.Chinese, "死神");
            Description.AddTranslation(GameCulture.Chinese, "你好! 我叫格雷格, 我是魔鬼....不许笑!!");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("GrimReaper")] > 0)
			{
				modPlayer.grimreaper = true;
			}
			if (!modPlayer.grimreaper)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("GrimReaper")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("GrimReaper"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}