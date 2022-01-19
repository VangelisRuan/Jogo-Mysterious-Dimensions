using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPooler : MonoBehaviour
{

    public GameObject objetoPooled;

    public int quantidadeDoPooled;

    List<GameObject> objetosPooled;

    // Start is called before the first frame update
    void Start()
    {

        objetosPooled = new List<GameObject>();

        for(int i = 0; i < quantidadeDoPooled; i++)
        {
            GameObject obj = (GameObject)Instantiate(objetoPooled);
            obj.SetActive(false);
            objetosPooled.Add(obj);
        }

    }

    public GameObject GetObejetoPooled()
    {
        for(int i = 0; i < objetosPooled.Count; i++)
        {
            if (!objetosPooled[i].activeInHierarchy)
            {
                return objetosPooled[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(objetoPooled);
        obj.SetActive(false);
        objetosPooled.Add(obj);
        return obj;

    }
}
