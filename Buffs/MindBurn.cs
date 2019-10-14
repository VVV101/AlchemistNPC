using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class MindBurn : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mind Burn");
			Description.SetDefault("Your mind is burning!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Mind Burn");
			Description.AddTranslation(GameCulture.Russian, "Разум горит!");
            DisplayName.AddTranslation(GameCulture.Chinese, "心智燃烧");
            Description.AddTranslation(GameCulture.Chinese, "心智在燃烧!");
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.KillMe(PlayerDeathReason.ByOther(player.Male ? 14 : 15), 1.0, 0, false);
        }
	}
}
