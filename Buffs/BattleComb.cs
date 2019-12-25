using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class BattleComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Battle Combination");
			Description.SetDefault("Combination of Endurance, Lifeforce, Ironskin, Regeneration, Rage & Wrath buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Боевая комбинация");
            Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Выносливости, Жизненных Сил, Железной Кожи, Регенерации, Ярости и Гнева");

            DisplayName.AddTranslation(GameCulture.Chinese, "战斗药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：耐力, 生命力, 铁皮, 恢复, 暴怒, 怒气");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			modPlayer.AllDamage10 = true;
			modPlayer.AllCrit10 = true;
			modPlayer.Defense8 = true;
			modPlayer.DR10 = true;
			modPlayer.Regeneration = true;
			modPlayer.Lifeforce = true;
			player.endurance += 0.1f;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
		}
	}
}
