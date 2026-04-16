using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CS
{
    public static AudioClip[] MainAudio = new AudioClip[13];

    public enum M { a00startgame, a01gameover, a02missground, a03misswater,a04hit,a05bonusclick, a06bonuscoming,a07enemyfly,a08enemyescape,a09musicmenu,a10musicgame,a11scale,a12timer };

    public static string[] MPackPath;

    //public static Color[] Mcolor = { Color.yellow, Color.red, Color.green, Color.grey, Color.blue }; 
    //public enum C { c00bonus, c01boom, c02cube, c03enemy, c04plane };

    public static GameObject[] Mprefabs = new GameObject[4];
    public enum P { p00boom, p01cube, p02enemy, p03bonusbar};
}//public static class CS

// 0 // Начало игры - 00startgame.mp3
// 1 // Конец игры - 01gameover.mp3
// 2 // Промах по земле - 02missground.mp3
// 3 // Промах по воде - 03misswater.mp3
// 4 // Убийство - 04hit.mp3
// 5 // Бонус активация - 05bonusclick.mp3
// 6 // Бонус появление - 06bonuscoming.mp3
// 7 // Полёт объекта - 07enemyfly.mp3
// 8 // Побег объекта - 08enemyescape.mp3
// 9 // Музыка меню - 09musicmenu.mp3
// 10 // Музыка боя - 10musicgame.mp3
// 11 // Заполнение шкалы - 11scale.mp3
// 12 // Окончание таймера - 12timer.mp3