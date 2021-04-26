using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBombs : MonoBehaviour
{
    public GameObject spawnObj;

    public float distanceBetweenObj = 3f;
    public float timeBetweenObj = 3f;
    public float maxObj = 10f;

    public List<GameObject> listObj = new List<GameObject>();

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
        if (actualObj < maxObj)
        {
            if (actualTime < timeBetweenObj)
                actualTime += 1f * Time.deltaTime;

            if (actualTime >= timeBetweenObj)
            {
                bool exit = false;
                int count = -1;

                Vector3 newPos;

                do
                {
                    newPos = new Vector3(Random.Range(transform.position.x - transform.localScale.x, transform.position.x + transform.localScale.x),
                                         transform.position.y,
                                         Random.Range(transform.position.z - transform.localScale.z, transform.position.z + transform.localScale.z));

                    //Debug.Log("nueva pos: " + newPos);
                    if (listObj.Count > 0)
                    {
                        foreach (GameObject i in listObj)
                        {
                            if (Vector3.Distance(newPos, i.transform.position) > distanceBetweenObj)
                                count++;
                        }

                        //for (int i = 0; i < listObj.Count + 1; i++)
                        //{
                        //    if (Vector3.Distance(newPos, listObj[i].transform.position) > distanceBetweenObj)
                        //        count++;
                        //}
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
                
                GameObject go = Instantiate(spawnObj, newPos, Quaternion.Euler(transform.forward));
                listObj.Add(go);

                actualObj++;

                actualTime = 0;
            }
        }
    }
}
