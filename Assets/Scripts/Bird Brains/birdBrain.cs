using UnityEngine;
using System.Collections;

public class birdBrain : MonoBehaviour {

    public float flapForce=20;
    public Rigidbody2D myRigidBody;
    public float horizontalSpeedMax = 5;
    public float flapHorizontal = 2;
    public int goingLeft=1;
    public float flapDelayTimer;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.AddForce(new Vector2(goingLeft* 500,0),ForceMode2D.Force);

        if (goingLeft == -1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        SetBaseStats();
        SetStats();
    }

    public virtual void SetBaseStats()
    {
        flapForce = 20;
        flapHorizontal = 2;
        horizontalSpeedMax = 5;
        myRigidBody.mass = 1;
        myRigidBody.gravityScale = 6;
    }

    public virtual void SetStats()
    {
    }

    // Update is called once per frame 
    void Update () {
        if (flapDelayTimer>0)
        {
            flapDelayTimer -= Time.deltaTime;
        } else if (flapDelayTimer<0)
        {
            flapDelayTimer = 0;
            Flap();
        }
        if (goingLeft == 1)
        {
            if (Input.touchCount > 0)
            {
                if (Input.touches[Input.touches.Length - 1].phase == TouchPhase.Began)
                {
                    if (Input.touches[Input.touches.Length - 1].position.x < Screen.width / 2)
                    {
                        if (Input.touches[Input.touches.Length - 1].position.y < Screen.height / 2)
                        {
                            Flap();
                        }
                        else
                        {
                            Ability();
                        }
                    }
                }
            }
        } else
        {
            if (Input.touchCount > 0)
            {
                if (Input.touches[Input.touches.Length - 1].phase == TouchPhase.Began)
                {
                    if (Input.touches[Input.touches.Length - 1].position.x > Screen.width / 2)
                    {
                        if (Input.touches[Input.touches.Length - 1].position.y < Screen.height / 2)
                        {
                            Flap();
                        } else
                        {
                            Ability();
                        }
                    }
                }
            }
        }

        if (transform.position.x < -10)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }
        else if (transform.position.x > 10)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
    }

    public virtual void Flap()
    {
        myRigidBody.rotation = -45 * goingLeft + 90;
        myRigidBody.angularVelocity = -200 * goingLeft;
        myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 0, 0);
        myRigidBody.AddForce(new Vector2(goingLeft * flapHorizontal, flapForce), ForceMode2D.Impulse);
    }

    public virtual void Ability() {
        Flap();
    }
}
