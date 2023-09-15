using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject[] barracks;
    public GameObject[] archery;
    public GameObject[] guild;
    public Transform barracksPos;
    public Transform archeryPos;
    public Transform guildPos;
    public TreasureManager treasureManager;
    public static int barracksLevel =0;
    public static int archeryLevel = 0;
    public static int guildLevel = 0;
    ItemsCostCSV csv;
    GameObject what;
    GameObject old;
    int level;
    Transform position;

    private void Start()
    {
        csv = GetComponent<ItemsCostCSV>();

        if (barracksLevel > 0)
        {
            what = barracks[barracksLevel - 1];
            position = barracksPos;
            Build();
        }

        if (archeryLevel > 0)
        {
            what = archery[archeryLevel - 1];
            position = archeryPos;
            Build();
        }

        if (guildLevel > 0)
        {
            what = guild[guildLevel - 1];
            position = guildPos;
            Build();
        }
    }
    public void SelectBuildnig(string whatToBuild)
    {
        switch (whatToBuild)
        {
            case "Barracks":
                {
                    level = barracksLevel;
                    what = barracks[level];
                    position = barracksPos;
                    barracksLevel++;
                    old = GameObject.FindGameObjectWithTag("Barracks");
                }
                break;
            case "Archery":
                {
                    level = archeryLevel;
                    what = archery[level];
                    position = archeryPos;
                    archeryLevel++;
                    old = GameObject.FindGameObjectWithTag("Archery");
                }
                break;
            case "Guild":
                {
                    level = guildLevel;
                    what = guild[level];
                    position = guildPos;
                    guildLevel++;
                    old = GameObject.FindGameObjectWithTag("Guild");
                }
                break;
        }
        Pay(whatToBuild, level);
        Build();
    }

    void Build()
    {
        if (old)
        {
            Destroy(old);
        }
        Instantiate(what, position.position, position.rotation);
    }

    void Pay(string whatName, int level)
    {
        foreach (var item in csv.itemsValue)
        {
            if (item.Name == whatName && item.Level == level)
            {
                treasureManager.Take(item);
                treasureManager.Show();
                break;
            }
        }

    }
    private void Update()
    {
        print("Barrackslevel " + barracksLevel);
    }
}
