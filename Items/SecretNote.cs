using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class SecretNote : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Secret Note");
			Tooltip.SetDefault("'If you are reading this, then know, that you could spawn your own Grim Reaper."
			+ "\nTo do this, you simply need to find the 'Suspicious Looking Scythe', which drops with 1/150 chance from any Treasure Bag in Hardmode."
			+ "\nGLHF!'"
			+ "\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Тайная записка");
			Tooltip.AddTranslation(GameCulture.Russian, "'Если ты читаешь это, то знай, что ты можешь призвать своего собственного Жнеца.\nДля того, чтобы сделать это, найти предмет 'Подозрительно Выглядящая Коса'.\nC вероятностью 1/80 выпадает из любой сумки босса в Хардмоде.\nGLHF!'"); 
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 1000000;
			item.rare = 5;
		}	
	}
}