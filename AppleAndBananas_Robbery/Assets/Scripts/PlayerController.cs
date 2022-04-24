using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    float vInput;
    float hInput;

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotateSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }


    private void Update()
    {
        if (!GameManager.Instance.isPause)
        {
            Movement();
        }
        SwitchAnimation();

    }

    void Movement() {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * vInput * moveSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * hInput  * rotateSpeed);
    }

    void SwitchAnimation() {
        anim.SetFloat("Speed", vInput);
    }

    public void StopAnimation() {
        vInput = 0;
        hInput = 0;
    }
}
