using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCastle : MonoBehaviour
{

    public BuildManager buildManager;
    void Start()
    {

    }

    public void Build(string whatToBuild)
    {
        buildManager.SelectBuildnig(whatToBuild);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Barracks");
            Build("Barracks");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Archery");
            Build("Archery");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            print("Guild");
            Build("Guild");
        }
    }

}



