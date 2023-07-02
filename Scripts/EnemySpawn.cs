using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPointList = new List<GameObject>();
    [SerializeField] List<GameObject> enemyPrefabList = new List<GameObject>();
    [SerializeField] GameObject bossPrefab;
    [SerializeField] Transform cloneEnemies;

    List<int> randomPosList = new List<int>();
    List<GameObject> cloneEnemy = new List<GameObject>();

    //5以上にするとerrorの可能性ある。5未満は少ない。正の整数ね。
    const int SpawnAmount = 5;



    public void SpawnControll(int playerDirection, int mapAmount)
    {
        CloneEnemyDestroy();

        if (playerDirection == 1)
        {
            if (mapAmount == 30)
            {
                BossSpawn(playerDirection);
                return;
            }
            if (mapAmount != 0)
            {
                Spawn(playerDirection, 0, 5);
            }
            
        }
        else if (playerDirection == -1)
        {
            if (mapAmount != 0)
            {
                Spawn(playerDirection, 2, 7);
            }
            
        }

        randomPosList.Clear();

    }

    //Left : min=>2, max=>7(2...6の地点)
    //right: min=>0, max=>5(0...4の地点)
    void Spawn(int playerDirection, int min, int max)
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            int randomPos = Random.Range(min, max);
            int randomEnemy = Random.Range(0, enemyPrefabList.Count);


            if (SamePointCheck(randomPos))
            {
                randomPosList.Add(randomPos);
                //prefabの値ではなく、cloneの値を変えている（顔の向き）
                cloneEnemy.Add(Instantiate(
                    enemyPrefabList[randomEnemy],
                    spawnPointList[randomPos].transform.position,
                    Quaternion.identity,
                    cloneEnemies));

                for (int k = 0; k < cloneEnemy.Count; k++)
                {
                    cloneEnemy[k].transform.localScale = new Vector3(-playerDirection, 1, 1);
                }

            }
        }
    }

    void BossSpawn(int playerDirection)
    {
        cloneEnemy.Add(Instantiate(
            bossPrefab,
            spawnPointList[1].transform.position,
            Quaternion.identity,
            cloneEnemies));

        for (int i = 0; i < cloneEnemy.Count; i++)
        {
            cloneEnemy[i].transform.localScale = new Vector3(-playerDirection, 1, 1);
        }
    }

    public void CloneEnemyDestroy()
    {
        foreach (Transform child in cloneEnemies)
        {
            Destroy(child.gameObject);
        }
        /*
        for(int i = 0; i < cloneEnemy.Count; i++)
        {
            Destroy(cloneEnemy[i]);
        }
        */
        cloneEnemy.Clear();
    }

    public void HideCloneEnemy()
    {
        foreach (Transform child in cloneEnemies)
        {
            child.gameObject.SetActive(false);
        }
        /*
        for (int i = 0; i < cloneEnemy.Count; i++)
        {
            if (cloneEnemy[i] == null) { continue; }
            cloneEnemy[i].gameObject.SetActive(false);
        }
        */
    }
    public void ShowCloneEnemy()
    {
        foreach (Transform child in cloneEnemies)
        {
            child.gameObject.SetActive(true);
        }
        /*
        for (int i = 0; i < cloneEnemy.Count; i++)
        {
            if (cloneEnemy[i] == null) { continue; }
            cloneEnemy[i].gameObject.SetActive(true);
        }
        */
    }

    public bool SamePointCheck(int randomPos)
    {
        for(int j = 0; j < randomPosList.Count; j++)
        {
            if (randomPosList[j] == randomPos)
            {
                return false;
            }
        }
        
        return true;
    }



        
}
