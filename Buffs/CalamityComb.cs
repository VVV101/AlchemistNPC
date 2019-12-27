using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CalamityComb : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			return ModLoader.GetMod("CalamityMod") != null;
		}
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Calamity Combination");
			Description.SetDefault("Perfect sum of Calamity buffs"
			+"\nYharim's Stimulants, Cadence, Fabsol's Vodka, Soaring, Bounding and Titan Scale");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Каламити");
			Description.AddTranslation(GameCulture.Russian, "Идеальное сочетание баффов Каламити мода\nДает эффект Стимулянтов Ярима, Каденции, Водки Фабсола, Полёта, Связующего и Титановой Чешуи");
            DisplayName.AddTranslation(GameCulture.Chinese, "灾厄药剂包");
            Description.AddTranslation(GameCulture.Chinese, "完美结合了以下灾厄药剂的Buff：\n魔君牌兴奋剂、尾音药剂、Fabsol伏特加、腾飞、跳跃、泰坦之鳞药剂");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("Cadence")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("YharimPower")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("TitanScale")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("FabsolVodkaBuff")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("Soaring")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("BoundingBuff")] = true;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player);
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				RedemptionBoost(player);
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				CalamityBoost(player, ref buffIndex);
			}
		}
		
		private void CalamityBoost(Player player, ref int buffIndex)
        {
			Calamity.GetBuff("Cadence").Update(player, ref buffIndex);
			Calamity.GetBuff("YharimPower").Update(player, ref buffIndex);
			Calamity.GetBuff("TitanScale").Update(player, ref buffIndex);
			Calamity.GetBuff("FabsolVodkaBuff").Update(player, ref buffIndex);
			Calamity.GetBuff("Soaring").Update(player, ref buffIndex);
			Calamity.GetBuff("BoundingBuff").Update(player, ref buffIndex);
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            RedemptionPlayer.druidCrit += 2;
        }
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 2;
            ThoriumPlayer.radiantCrit += 2;
        }
	}
}
