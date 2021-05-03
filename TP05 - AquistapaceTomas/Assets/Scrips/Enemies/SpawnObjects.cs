using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> spawnObj = new List<GameObject>();

    public float distanceBetweenObj = 3f;
    public float timeBetweenObj = 3f;
    public float maxObj = 10f;

    [HideInInspector]
    public List<GameObject> listObj = new List<GameObject>();

    float multipliScale = 5f;
    float actualTime;
    int actualObj;

    void Start()
    {
        actualTime = 0;
        actualObj = 0;
    }

    void Update()
    {
        InstantiateNewObj();
    }

    void InstantiateNewObj()
    {
        CleanList();

        if (actualObj < maxObj)
        {
            Timer();

            if (actualTime >= timeBetweenObj)
            {
                bool exit = false;
                int count = -1;

                Vector3 newPos;

                do
                {
                    newPos = new Vector3(Random.Range(transform.position.x - transform.localScale.x * multipliScale, transform.position.x + transform.localScale.x * multipliScale),
                                         transform.position.y,
                                         Random.Range(transform.position.z - transform.localScale.z * multipliScale, transform.position.z + transform.localScale.z * multipliScale));

                    if (listObj.Count > 0)
                    {
                        foreach (GameObject i in listObj)
                        {
                            if (Vector3.Distance(newPos, i.transform.position) > distanceBetweenObj)
                                count++;
                        }
                    }
                    else
                    {
                        count++;
                    }
                    
                    if (count == listObj.Count)
                    {
                        exit = true;
                    }
                    else
                    {
                        exit = false;
                        count = 0;
                    }

                } while (exit == false);
                
                int ran = Random.Range(0, spawnObj.Count);

                GameObject go = Instantiate(spawnObj[ran], newPos, Quaternion.Euler(transform.forward));
                listObj.Add(go);
                
                actualObj++;

                actualTime = 0;
            }
        }
    }

    void Timer()
    {
        if (actualTime < timeBetweenObj)
            actualTime += 1f * Time.deltaTime;
    }

    void CleanList()
    {
        for (int i = 0; i < listObj.Count; i++)
        {
            if (listObj[i] == null)
            {
                listObj.RemoveAt(i);
                actualObj--;
            }
        }
    }
}
