using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    float vInput, hInput, movementSpeed, rotationSpeed;
    [SerializeField]
    GameObject model;
    [SerializeField]
    Image fogPanel;
    [SerializeField]
    bool fade, fadeOn;

    public ParticleSystem bubblePS;
    public ParticleSystem bubblePS2;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        movementSpeed = 1.0f;
        rotationSpeed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (!fade)
        {
            vInput = Input.GetAxis("Vertical");
            hInput = Input.GetAxis("Horizontal");               
        }
        else
        {
            vInput = 0;
            hInput = 0;
            if (fadeOn && fogPanel.color.a < 1)
            {
                Debug.Log(fogPanel.color.a);
                fogPanel.color = new Color(fogPanel.color.r, fogPanel.color.g, fogPanel.color.b, fogPanel.color.a + Time.deltaTime/2);
                if (!bubblePS.isPlaying)
                {
                    bubblePS.Play();
                    bubblePS2.Play();
                }
                //fogPanel.fillAmount += Time.deltaTime;
            }
            else if (!fadeOn && fogPanel.color.a > 0)
            {
                fogPanel.color = new Color(fogPanel.color.r, fogPanel.color.g, fogPanel.color.b, fogPanel.color.a - Time.deltaTime / 3);
                //fogPanel.fillAmount -= Time.deltaTime;
                if (!bubblePS.isPlaying)
                {
                    bubblePS.Play();
                    bubblePS2.Play();
                }
            }
            else
            {
                if (bubblePS.isPlaying) {
                    bubblePS.Stop();
                    bubblePS2.Stop();
                }

                fade = false;
            }
            
        }

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.Translate(new Vector3(hInput * movementSpeed * Time.deltaTime, 0, vInput * movementSpeed * Time.deltaTime));
        transform.rotation = Quaternion.identity;


        if (hInput == 0 && vInput == 0)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            model.transform.LookAt(transform.position + new Vector3(hInput, 0, vInput).normalized);
            anim.SetBool("Walk", true);

            anim.speed = movementSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 10.0f;
        }
        else
        {
            movementSpeed = 1.0f;
        }
    }

    public void Fade(bool on)
    {
        fade = true;
        fadeOn = on;
    }

    public bool Fading()
    {
        return fade;
    }
}
