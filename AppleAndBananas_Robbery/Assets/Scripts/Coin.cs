using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    string type;

    [SerializeField]
    int point;

    public event Action<int, AudioClip> collectCoinEvent;
    public event Action<string> generateNewCoinEvent;


    public bool isRotate;
    public float rotateSpeed;

    private AudioSource coinAS;


    private void Start()
    {
        coinAS = GetComponent<AudioSource>();

        collectCoinEvent += GameManager.Instance.AddPoint;
        if (type == "Red") {
            StartCoroutine("RedDisappear");
        }

        generateNewCoinEvent += GameManager.Instance.GenerateCoin;
    }

    private void Update()
    {
        if (isRotate) {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnDestroy() {
        generateNewCoinEvent?.Invoke(type);
        if(collectCoinEvent !=null)
            collectCoinEvent -= GameManager.Instance.AddPoint;
        if (generateNewCoinEvent != null)
            generateNewCoinEvent -= GameManager.Instance.GenerateCoin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            collectCoinEvent?.Invoke(point,coinAS.clip);
            Destroy(this.gameObject);
        }
    }

    IEnumerator RedDisappear() {
        float waitTime = UnityEngine.Random.Range(6f, 10f);
        yield return new WaitForSeconds(waitTime);

        int leftTimes = 15;

        while (leftTimes > 0) {
            if (gameObject.GetComponent<MeshRenderer>().isVisible)
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            else gameObject.GetComponent<MeshRenderer>().enabled = true; ;
            yield return new WaitForSeconds(0.2f);
            leftTimes--;
        }

        Destroy(gameObject, 0.2f);
    }
}
