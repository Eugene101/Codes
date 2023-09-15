using System.Collections.Generic;
using UnityEngine;
using Zenject.ReflectionBaking.Mono.Cecil.Cil;

public class GenericFactory<T> : MonoBehaviour where T : Transform
{
    public T[] prefab;
    static List<Vector3> spawnPoints = new List<Vector3>();
    public T GetNewInstance()
    {
        Vector3 pos = RandomPos();
        int count = 0;
        int randNum = Random.Range(0, prefab.Length);
        float dist = 2.5f;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (prefab[randNum].name.Contains("Mushroom")) { dist = 0.5f; }
            else if (prefab[randNum].name.Contains("Rock")) { dist = 1f; }
            else { dist = 2.5f; }

            if (Vector3.Distance(spawnPoints[i], pos) < dist)
            {
                pos = RandomPos();
                i = -1;
                count++;
                print("*");
                if (count > 130)
                {
                    print("skipped");
                    return null;
                }
            }
        }
        spawnPoints.Add(pos);
        Transform result = Instantiate(prefab[randNum], pos, Quaternion.identity);
        return (T)result;
    }

    Vector3 RandomPos()
    {
        float x = Random.Range(-50f, 50f);
        float z = Random.Range(-50f, 50f);
        return new Vector3(transform.position.x + x, 0f, transform.position.z + z);
    }

}
