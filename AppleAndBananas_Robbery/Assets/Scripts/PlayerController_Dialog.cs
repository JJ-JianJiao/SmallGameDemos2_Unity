using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController_Dialog : MonoBehaviour
{
    Animator anim;
    float vInput;
    float hInput;

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    private int Gold;

    public Text GoldText;

    private void Awake()
    {
        Gold = 0;
        anim = GetComponent<Animator>();

    }
    void Update()
    {

        Movement();
        SwitchAnimation();
        UpdateGoldUI();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.F1)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void UpdateGoldUI() {
        GoldText.text = Gold.ToString();
    }

    void Movement()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * vInput * moveSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * hInput * rotateSpeed);
    }
    void SwitchAnimation()
    {
        anim.SetFloat("Speed", vInput);
    }

    public void StopAnimation()
    {
        vInput = 0;
        hInput = 0;
    }

    public void GetGold(int gold) {
        this.Gold += gold;
    }
}
