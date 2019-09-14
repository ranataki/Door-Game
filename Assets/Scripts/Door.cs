using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Enemy e;
    public Guy g;

    public GameObject doorLeft;
    public GameObject doorRight;

    public Collision collision;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            doorLeft.GetComponent<Animator>().Play("doorLeftClose");
            doorRight.GetComponent<Animator>().Play("doorRightClose");

            if (Input.GetMouseButtonDown(0))
            {
                doorLeft.GetComponent<Animator>().Play("doorLeftOpen");
                doorRight.GetComponent<Animator>().Play("doorRightOpen");
            }
            else if (g.touchingDoor)
            {
                doorLeft.GetComponent<Animator>().Play("doorLeftVibrate");
                doorRight.GetComponent<Animator>().Play("doorRightVibrate");
                print("hi");
            }
            else if (e.touchingDoor)
            {
                doorLeft.GetComponent<Animator>().Play("doorLeftVibrate");
                doorRight.GetComponent<Animator>().Play("doorRightVibrate");
            }
        }

    }

}
