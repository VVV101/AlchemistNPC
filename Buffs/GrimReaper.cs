using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class GrimReaper : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Grim Reaper");
			Description.SetDefault("Hello! My name's Gregg, the Grim Reaper – and don't laugh!");
            DisplayName.AddTranslation(GameCulture.Chinese, "死神");
            Description.AddTranslation(GameCulture.Chinese, "你好! 我叫格雷格, 死神....不许笑!!");
            Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Жнец");
			Description.AddTranslation(GameCulture.Russian, "Привет! Мое имя Грегг, я Жнец - пожалуйста, не надо смеяться!");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
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
			player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player, ref buffIndex);
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				RedemptionBoost(player);
			}
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				Calamity.Call("AddRogueCrit", player, 10);
			}
		}

		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            RedemptionPlayer.druidCrit += 10;
        }
		private void ThoriumBoosts(Player player, ref int buffIndex)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 10;
            ThoriumPlayer.radiantCrit += 10;
        }
	}
}