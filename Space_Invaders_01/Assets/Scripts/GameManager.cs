using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy_01 enemy_01;
    private List<Enemy_01> enemy_01_List;
    public int enemy_01_Count = 5;
    public int enemyOffsetX = 2;

    public GameObject coverBox;
    private List<GameObject> coverBoxList;
    public int coverBoxGroupsCount = 3;
    public int coverBoxCount = 2;
    public float coverBoxOffset=.5f;
    public float coverBoxGroupOffset =2f;
    public int coverBoxRows = 3;
    public float coverBoxRowsOffset = 1f;

    void Start()
    {
        enemy_01_List = new List<Enemy_01>();
        coverBoxList = new List<GameObject>();
        InstantiateEnemies();
        InstantiateCoverBoxes();

    }
    void InstantiateEnemies()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int i = 0; i < enemy_01_Count; i++)
            {
                float xPosition = (((20f / enemy_01_Count) * (i + .5f)) - 10f) + y % 2;
                float yPosition = 10 - 1 * y;
                Enemy_01 e = Instantiate(enemy_01);
                e.transform.parent = transform;
                enemy_01_List.Add(e);

                e.transform.position = new Vector3(xPosition, yPosition, 0);
                if (y % 2 == 0)
                {
                    e.moveSpeed = -e.moveSpeed;
                }
            }
        }
    }
    void InstantiateCoverBoxes()
    {
        for (int y = 0; y < coverBoxRows; y++)
        {
            for (int i = 0; i < coverBoxGroupsCount; i++)
            {
                for (int x = 0; x < coverBoxCount; x++)
                {
                    GameObject cB = Instantiate(coverBox);
                    //cB.transform.parent = transform;
                    coverBoxList.Add(cB);

                    cB.transform.position = new Vector3(((i/(float)coverBoxGroupsCount*20f)-10f+10f/coverBoxGroupsCount) + x/4f-coverBoxCount/10f, 1 + y*coverBoxRowsOffset, 0);

                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
