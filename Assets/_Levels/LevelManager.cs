using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelControll> levelsList;

    private Dictionary<int, LevelControll> levelsDict;

    private void Start()
    {
        levelsDict = new Dictionary<int, LevelControll>();

        for (int i = 0; i < levelsList.Count; i++)
        {
            levelsDict.Add(i, levelsList[i]);
        }
        
    }

}
