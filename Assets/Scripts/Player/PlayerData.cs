using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int sympathyLevel;
    public int chapterUnlocked;
    public int SceneOnChapter;

    public PlayerData (Player player)
    {
        sympathyLevel = player.sympathyLevel;
        chapterUnlocked = player.chapterUnlocked;
        SceneOnChapter = player.SceneOnChapter;
    }
}
