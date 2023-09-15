using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public TreeFactory treeFactory;
    public RockFactory rockFactory;
    public MushroomFactory mushroomFactory;

    void Start()
    {
        for (int i = 0; i < 300; i++)
        {
            var prefab = treeFactory.GetNewInstance();
        }

        for (int i = 0; i < 300; i++)
        {
            var prefab = rockFactory.GetNewInstance();
        }
        for (int i = 0; i < 300; i++)
        {
            var prefab = mushroomFactory.GetNewInstance();
        }
    }





}
