using Terraria.Localization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Summoning
{
	public class HorrifyingSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horrifying Skull");
			Tooltip.SetDefault("Summons the mightiest enemy"
			+"\nUse with the extreme care");
			DisplayName.AddTranslation(GameCulture.Russian, "Пугающий Череп");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает могущественного противника\nИспользовать с крайней осторожностью");
			DisplayName.AddTranslation(GameCulture.Chinese, "可怖头骨");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤最强大的敌人\n使用时极端注意");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 30;
			item.value = 100;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			NPC.NewNPC((int)player.position.X, (int)player.position.Y - 350, NPCID.DungeonGuardian);
			Main.NewText("Dungeon Guardian has awoken!", 175, 75, 255);
			NetMessage.SendData(23, -1, -1, null, NPCID.DungeonGuardian, 0f, 0f, 0f, 0);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
	}
}