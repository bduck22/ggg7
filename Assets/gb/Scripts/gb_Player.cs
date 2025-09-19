using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gb_Player : MonoBehaviour
{
    public float Speed;
    public bool stop;
    public Rigidbody rb;
    public Animator animator;
    public float Money;

    public int NowPlant;
    public gb_Tile nowTile;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    Vector3 dir;

    public Transform info;
    public Text plantName;
    public Slider waterSlider;
    public Slider glowSlider;
    public Transform glow;
    public Transform seed;
    public Transform getbutton;
    public Transform toolbutton;

    void Update()
    {
        if (!stop)
        {
            if (Input.GetMouseButton(1))
            {
                transform.Rotate(0, Input.GetAxis("Mouse X")*2, 0);
            }

            dir = Vector3.zero;
            if (Input.GetButton("Horizontal"))
            {
                dir += transform.right*Speed*Input.GetAxis("Horizontal");
            }

            if (Input.GetButton("Vertical"))
            {
                dir += transform.forward*Speed * Input.GetAxis("Vertical");
            }

            if(dir != Vector3.zero)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            rb.velocity = new Vector3(dir.x, rb.velocity.y, dir.z);
        }

        if (nowTile)
        {
            info.gameObject.SetActive(true);
            string name = "-";
            if (nowTile.plants[NowPlant].type != gb_PlantType.None)
            {
                getbutton.gameObject.SetActive(true);
                glow.gameObject.SetActive(true);
                switch (nowTile.plants[NowPlant].type)
                {
                    case gb_PlantType.Potato:
                        name = "감자";
                        break;
                    case gb_PlantType.Carrot:
                        name = "당근";
                        break;
                    case gb_PlantType.Tomato:
                        name = "토마토";
                        break;
                    case gb_PlantType.Garic:
                        name = "마늘";
                        break;
                    case gb_PlantType.Onion:
                        name = "양파";
                        break;
                }

                if (nowTile.plants[NowPlant].Glow >= nowTile.plants[NowPlant].maxGlow)
                {
                    getbutton.gameObject.SetActive(true);
                }
                else
                {
                    
                }
            }
            else
            {
                seed.gameObject.SetActive(true);
                getbutton.gameObject.SetActive(false);
                glow.gameObject.SetActive(false);
            }
            plantName.text = name;
        }
        else
        {
            info.gameObject.SetActive(false);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            if (other.transform.root.GetComponent<gb_Tile>().buyed)
            {
                nowTile = other.transform.root.GetComponent<gb_Tile>();
                NowPlant = int.Parse(other.gameObject.name) - 1;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            nowTile = null;
            NowPlant = -1;
        }
    }

    public void Setplant(int num)
    {
        nowTile.setplant(num, NowPlant);
    }
}
