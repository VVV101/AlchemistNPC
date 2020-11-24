using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Summoning
{
	public class NotesBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Notes Book");
			Tooltip.SetDefault("Doesn't matter if the pages are torn, hidden information is now accessible."
			+"\nThis can open Otherwordly Portal"
			+"\nCan be used only on certain conditions"
			+"\n''If you managed to collect all Notes, then you will be able to read this information."
			+"\nMoon Lord is not an ordinary creature. Defeating him may have some unexpected effects..."
			+"\nLike weakening barrier between worlds. Even a pathway between worlds may appear."
			+"\nThis barrier becomes especially weak during the event called ''The Dark Sun''."
			+"\nIf I will get stuck in Interdimension and you will know coordinates of the Porta......''");
			DisplayName.AddTranslation(GameCulture.Russian, "Книга с Записками");
            Tooltip.AddTranslation(GameCulture.Russian, "Неважно, что её страницы истрёпаны...\nСкрытая информация теперь может быть прочитана.\nМожет открыть портал в Другой Мир\nМожет быть использована только в определённых условиях\n''Если ты собрал все Записи, то ты сможешь это прочесть.\nЛунный Лорд - неординарное создание. Его убийство может привести к неожиданным последствиям...\nНапример, ослабевание барьера между мирами. Может даже появиться путь для прохода через миры.\nБарьер наиболее тонок во время события, именуемого ''Чёрное Солнце''.\nЕсли я застряну в Междумирье и у тебя будут координаты Порта......''");

            DisplayName.AddTranslation(GameCulture.Chinese, "笔记本");
            Tooltip.AddTranslation(GameCulture.Chinese, "无论它的纸张被破坏成什么样了, 隐藏的信息都已经可以阅读了" +
                "\n能开启一个前往其他世界的传送门" +
                "\n只能在某些条件下使用" +
                "\n''如果你已经收集了所有的笔记, 那么你就能读到这些信息了" +
                "\n月亮领主并不是普通的生物,击败他可能会产生一些意想不到的效果..." +
                "\n如果削弱世界间的屏障, 就算是在世界间打开一条通路也是有可能的" +
                "\n世界间的屏障将在日食时达到最弱状态" +
                "\n如果我被困在空间裂隙中, 你就能得到传送门的坐标....''");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 30;
			item.value = 5000000;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
			item.makeNPC = (short)mod.NPCType("OtherworldlyPortal");
		}

		public override void HoldItem(Player player)
		{
			Player.tileRangeX += 600;
			Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
			{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				if (!NPC.AnyNPCs(mod.NPCType("OtherworldlyPortal")) && !NPC.AnyNPCs(mod.NPCType("Explorer")) && Main.eclipse && !Collision.SolidCollision(vector2, player.width, player.height))
				{
					return true;
				}
			}
			return false;
		}

		public override void OnConsumeItem(Player player)
		{
			string Portal = Language.GetTextValue("Mods.AlchemistNPC.Portal");

            Main.NewText(Portal, 255, 255, 255);
		}
	}
}
