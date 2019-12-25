using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class RangerComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ranger Combination");
			Description.SetDefault("Combination of Archery, Ammo Reservation, Wrath, Rage buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Стрелка");
			Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Лучника, Экономии Боеприпасов, Гнева и Ярости");
            DisplayName.AddTranslation(GameCulture.Chinese, "射手药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：箭术, 弹药储备, 暴怒, 怒气");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			modPlayer.AllDamage10 = true;
			modPlayer.AllCrit10 = true;
			player.ammoPotion = true;
			player.archery = true;
			player.buffImmune[16] = true;
			player.buffImmune[112] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
		}
	}
}
