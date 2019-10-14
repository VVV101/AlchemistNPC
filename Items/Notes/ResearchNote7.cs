using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class ResearchNote7 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note #7");
			Tooltip.SetDefault("''Once, I was in quite insane world."
			+"\nThere was one old scientist, named [c/00FF00:Rick]."
			+"\nLuckly, I was able to saw all that without being caught..."
			+"\nHe escaped from the maximum security prison without help from outside."
			+"\nAnd then destroyed the entire Galactic Federation in the same day." 
			+"\nThe thing what I was the most interested in is his Portal Gun."
			+"\nHe managed to use it as a weapon. And I really want to make one for myself.."
			+"\nNaturally we need [c/00FF00:Portal Gun] as the base..."
			+"\nFor some parts, we need an [c/00FF00:Alchemical Bundle]."
			+"\nWe also need the [c/00FF00:Lunar Portal Staff] for stabilizing the portals."
			+"\nTo variate dimensions, we can use [c/00FF00:R.E.K. 3000]."
			+"\nI am still not sure about source of energy..."
			+"\nRick used some kind of [c/00FF00:Energy Capsules] as ammo."
			+"\nI hope I'm able to synthesize it...''");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №7");
            Tooltip.AddTranslation(GameCulture.Russian, "''Однажды я побывала в довольно безумном мире.\nТам я видела старика-учёного, которого звали [c/00FF00:Рик].\nК счастью, я смогла понаблюдать за событиями незамеченной.\nОн сбежал из тюрьмы максимальной безопасности безо всякой помощи снаружи.\nИ в тот же день он уничтожил Галактическую Федерацию.\nМеня очень заинтересовала его Портальная Пушка.\nОн пользовался ей в качестве оружия. Я очень хочу себе такую же...\nКонечно, нам необходима [c/00FF00:Портальная Пушка] Лунного Лорда в качестве основы.\nДля некоторых частей нам потребуется [c/00FF00:Алхимический Набор].\nДля стабилизации порталов нам потребуется [c/00FF00:Посох Лунных Порталов].\nДля варьирования реальностей, нам понадобится [c/00FF00:R.E.K. 3000].\nНо я не уверена насчёт источника энергии...\nРик использовал какие-то [c/00FF00:Капсулы с энергией] в качестве патронов.\nНадеюсь, мне удастся их воссоздать...''");
			DisplayName.AddTranslation(GameCulture.Chinese, "研究笔记 #7");
			Tooltip.AddTranslation(GameCulture.Chinese, "''曾经, 我去过一个疯狂的世界"
			+"\n那儿有个老科学家, 名字叫[c/00FF00:瑞克]."
			+"\n我很幸运, 能够在没被抓到的情况下看到这一切."
			+"\n他单凭自己从一所最高安全级别的监狱中逃了出来."
			+"\n然后在同一天内覆灭了整个银河联邦."
			+"\n在这其中, 我最感兴趣的是他的传送枪."
			+"\n他把它作为武器使用. 我真的想为自己做一个..."
			+"\n理所当然的, 我们首先需要[c/00FF00:传送枪]作为基础..."
			+"\n为了制作一些部件, 我们需要一个[c/00FF00:炼金捆绑包]."
			+"\n我们同样需要[c/00FF00:月球传送门法杖]来稳定传送门."
			+"\n为了改变维度, 我们可以使用[c/00FF00:R.E.K. 3000]."
			+"\n我还不确定能量源该用什么..."
			+"\n瑞克用某种[c/00FF00:能量胶囊]作为弹药."
			+"\n希望我能合成它...''");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 1;
			item.value = 10000000;
			item.rare = 10;
		}	
	}
}
