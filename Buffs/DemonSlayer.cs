using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class DemonSlayer : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Demon Slayer");
			Description.SetDefault("You became stronger after beating him"
			+"\nImmune to Mana Sickness debuff"
			+"\nMelee speed is increased by 10%"
			+"\nArmor penetration is increased by 20"
			+"\nAdds 25% chance not to consume ammo"
			+"\nIncreases max amount of minions and sentries by 1"
			+"\nYou have a chance to release additional throwing projectiles"
			+"\nYou are immune to some specific debuffs");
			Main.debuff[Type] = false;
			canBeCleared = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Убийца Демонов");
			Description.AddTranslation(GameCulture.Russian, "Вы стали сильнее после победы над НИМ\nИммунитет к Магической Слабости\nСкорость ближнего боя увеличена на 10%\nПробивание брони увеличено на 20\n25% шанс не потратить патроны\nМаксимальное число турелей и прислужников увеличено на 1\nВы имеете шанс бросить дополнительное метательное оружие\nВы иммунны к некоторым дебаффам");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeSpeed += 0.1f;
			player.maxMinions += 1;
			player.maxTurrets += 1;
			player.armorPenetration += 20;
			player.buffImmune[20] = true;
			player.buffImmune[22] = true;
			player.buffImmune[23] = true;
			player.buffImmune[24] = true;
			player.buffImmune[30] = true;
			player.buffImmune[31] = true;
			player.buffImmune[32] = true;
			player.buffImmune[33] = true;
			player.buffImmune[35] = true;
			player.buffImmune[36] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
			player.buffImmune[70] = true;
			player.buffImmune[94] = true;
			player.buffImmune[BuffID.Electrified] = true;
			player.buffImmune[BuffID.OgreSpit] = true;
		}
	}
}
