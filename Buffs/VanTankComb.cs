using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class VanTankComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tank Combination (Vanilla)");
			Description.SetDefault("Combination of Swiftness, Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns and Regeneration buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Танка (без Модовых)");
            Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Быстроты, Выносливости, Жизненных Сил, Железной Кожи, Обсидиановой Кожи, Шипов и Регенерации");
            DisplayName.AddTranslation(GameCulture.Chinese, "坦克药剂包 (原版)");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：敏捷, 耐力, 生命力, 铁皮, 黑曜石皮肤, 荆棘, 恢复");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			modPlayer.Defense8 = true;
			modPlayer.DR10 = true;
			modPlayer.Regeneration = true;
			modPlayer.Lifeforce = true;
			modPlayer.MS = true;
			player.lavaImmune = true;
			player.fireWalk = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[3] = true;
			player.buffImmune[5] = true;
			player.buffImmune[14] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			if (player.thorns < 1.0)
			{
				player.thorns = 0.3333333f;
			}
			BuffLoader.Update(BuffID.ObsidianSkin, player, ref buffIndex);
		}
	}
}
