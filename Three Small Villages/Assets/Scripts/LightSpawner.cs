using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    public SpawnData mySpawnData;
    private List<Light> myLights;

    // Use this for initialization
    void Start()
    {
        myLights = new List<Light>();
        foreach (Vector3 spawn in mySpawnData.spawnPoints)
        {
            GameObject myLight = new GameObject("Light");
            myLight.AddComponent<Light>();
            myLight.transform.position = spawn;
            myLight.GetComponent<Light>().enabled = false;
            if (mySpawnData.colorIsRandom)
            {
                //myLight.GetComponent<Light>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                myLight.GetComponent<Light>().color = new Color(UnityEngine.Random.value, Random.value, Random.value);
            }
            else
            {
                myLight.GetComponent<Light>().color = mySpawnData.thisColor;
            }
            myLights.Add(myLight.GetComponent<Light>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach (Light light in myLights)
            {
                light.enabled = !light.enabled;
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            UpdateLights();
        }

    }

    void UpdateLights()
    {
        foreach (var myLight in myLights)
        {
            myLight.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }
}
