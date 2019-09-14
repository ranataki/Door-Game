using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    public GameObject guy;
    public GameObject target;
    public GameObject guyBody1;
    public GameObject guyBody2;

    public float speed;

    public Rigidbody rb;

    public bool touchingTarget;
    public bool touchingDoor;

    public Vector3 bounceBack = new Vector3(-10.3f, 0f, 0.11f);

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().enabled = true;
        touchingTarget = false;
        touchingDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!touchingDoor)
        {
            MoveToTarget();
        }
        else
        {
            BounceBack();
            this.enabled = false;
            StartCoroutine(WaitAndDisable());
        }
    }

    void MoveToTarget()
    {
        var direction = Vector3.zero;
        direction = target.transform.position - transform.position;
        rb.AddRelativeForce(direction.normalized * speed, ForceMode.Impulse);
    }

    void BounceBack()
    {
        guy.GetComponent<Animator>().Play("Floating");
        rb.AddForce(bounceBack * 3f, ForceMode.Impulse);
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(guy);
    }

    IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<BoxCollider>().enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Wall"):
                BounceBack();
                StartCoroutine(WaitForDestroy());
                break;

            case ("Door"):
                touchingDoor = true;
                StartCoroutine(WaitForDestroy());
                break;

            case ("Limit"):
                StartCoroutine(WaitForDestroy());
                break;

            case ("Target"):
                touchingTarget = true;
                Destroy(guy);
                break;
        }
    }
}
