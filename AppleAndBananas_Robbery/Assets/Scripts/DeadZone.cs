using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Transform restartPoint;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            player.transform.position = restartPoint.position;
            player.transform.rotation = restartPoint.rotation;
        }
    }
}
