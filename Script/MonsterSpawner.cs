using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform Left, Right;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)  // left side
            {
                spawnedMonster.transform.position = Left.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 11);
            }
            else                  // Right side
            {
                spawnedMonster.transform.position = Right.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 11);

                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
} 


























