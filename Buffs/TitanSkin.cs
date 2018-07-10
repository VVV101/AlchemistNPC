using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TitanSkin : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Titan Skin");
			Description.SetDefault("You have some heavy debuff immunity");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Кожа Титана");
			Description.AddTranslation(GameCulture.Russian, "Вы имеете иммунитет к некоторым серьёзным дебаффам");
            DisplayName.AddTranslation(GameCulture.Chinese, "泰坦皮肤");
            Description.AddTranslation(GameCulture.Chinese, "你免疫一些Debuff");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			if (NPC.downedMechBoss2)
			{
			player.buffImmune[39] = true;
			player.buffImmune[69] = true;
			}
			player.buffImmune[24] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			
		}
	}
}
