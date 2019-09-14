using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject target;
    public GameObject body1;
    public GameObject body2;

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
        enemy.GetComponent<Animator>().Play("Floating");
        rb.AddForce(bounceBack * 3f, ForceMode.Impulse);
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(enemy);
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
                StartCoroutine(WaitAndDestroy());
                break;

            case ("Door"):
                touchingDoor = true;
                StartCoroutine(WaitAndDestroy());
                break;

            case ("Limit"):
                BounceBack();
                StartCoroutine(WaitAndDestroy());
                break;

            case ("Target"):
                touchingTarget = true;
                Destroy(enemy);
                break;
        }
    }


}
