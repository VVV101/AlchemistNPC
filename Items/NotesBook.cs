using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class NotesBook : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Notes Book");
			Tooltip.SetDefault("No matter its pages are torn, hidden information is now readeable."
			+"\nCan open portal to the other world"
			+"\nCan be used only on certain conditions"
			+"\n''If you managed to collect all Notes, then you will be able to read this information."
			+"\nMoon Lord is not ordinary creatures. Defeating him may do some unexpected effects..."
			+"\nLike weakening barrier between worlds. Even way between worlds may appear."
			+"\nThis barrier becomes especially weak during the event, called ''The Dark Sun''."
			+"\nIf I will stuck in Interdimension and you will know coordinates of the Porta......''");
			DisplayName.AddTranslation(GameCulture.Russian, "Книга с Записками");
			Tooltip.AddTranslation(GameCulture.Russian, "Неважно, что её страницы истрёпаны...\nСкрытая информация теперь может быть прочитана.\nМожет открыть портал в Другой Мир\nМожет быть использована только в определённых условиях\n''Если ты собрал все Записи, то ты сможешь это прочесть.\nЛунный Лорд - неординарное создание. Его убийство может привести к неожиданным последствиям...\nНапример, ослабевание барьера между мирами. Может даже появиться путь для прохода через миры.\nБарьер наиболее тонок во время события, именуемого ''Чёрное Солнце''.\nЕсли я застряну в Междумирье и у тебя будут координаты Порта......''"); 
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 30;
			item.value = 5000000;
			item.rare = 11;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return (!NPC.AnyNPCs(mod.NPCType("OtherworldlyPortal")) && !NPC.AnyNPCs(mod.NPCType("Explorer")) && Main.eclipse);
		}

		public override bool UseItem(Player player)
		{
			Main.NewText("Otherworldly Portal was opened.", 255, 255, 255);
			NPC.NewNPC((int)player.Center.X+Main.rand.Next(-250,250), (int)player.Center.Y+Main.rand.Next(-250,250), mod.NPCType("OtherworldlyPortal"));
			return true;
		}
	}
}