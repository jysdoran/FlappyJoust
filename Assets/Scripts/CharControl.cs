using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour {

    GameObject bird0;
    GameObject birdbackup0;
    int selected0;
    bool swipe0 = false;

    GameObject bird1;
    GameObject birdbackup1;
    int selected1;
    bool swipe1 = false;

    public int birdTypes = 4;

	// Use this for initialization
	void Start () {
        bird0 = (GameObject) Instantiate(Resources.Load("Bird"));
        bird0.transform.position = new Vector3(-5, 0, 0);
        bird0.GetComponent<Rigidbody2D>().Sleep();
        bird0.GetComponent<CircleCollider2D>().enabled = false;
        birdbackup0 = (GameObject)Instantiate(Resources.Load("Bird"));
        birdbackup0.transform.position = new Vector3(-5, 0, 0);
        birdbackup0.GetComponent<Rigidbody2D>().Sleep();


        bird1 = (GameObject)Instantiate(Resources.Load("Bird"));
        bird1.transform.position = new Vector3(5, 0, 0);
        bird1.GetComponent<Rigidbody2D>().Sleep();
        bird1.GetComponent<CircleCollider2D>().enabled = false;
        birdbackup1 = (GameObject)Instantiate(Resources.Load("Bird"));
        birdbackup1.transform.position = new Vector3(5, 0, 0);
        birdbackup1.GetComponent<Rigidbody2D>().Sleep();


    }

    public void AddType(GameObject ObjectToAdd, int ID)
    {
        switch (ID)
        {
            case 0:
                ObjectToAdd.AddComponent<flapperBrain>();
                break;
            case 1:
                ObjectToAdd.AddComponent<diverBrain>();
                break;
            case 2:
                ObjectToAdd.AddComponent<diveFlapperBrain>();
                break;
            case 3:
                ObjectToAdd.AddComponent<dasherBrain>();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++) {
                if (Input.touches[i].phase == TouchPhase.Moved)
                {
                    if (Mathf.Abs(Input.touches[i].deltaPosition.x) > Mathf.Abs(Input.touches[i].deltaPosition.y))
                    {
                        if (Input.touches[i].position.x < Screen.width / 2)
                        {
                            if (Input.touches[i].deltaPosition.x > 30 && swipe0 == false)
                            {
                                Debug.Log("Swipe right");

                                bird0.GetComponent<Rigidbody2D>().WakeUp();
                                bird0.GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 0));

                                bird0 = (GameObject)Instantiate(Resources.Load("Bird"));
                                bird0.transform.position = new Vector3(-5, 0, 0);
                                bird0.GetComponent<Rigidbody2D>().Sleep();
                                //bird0.GetComponent<CircleCollider2D>().enabled = false;

                                selected0 += 1;
                                if (selected0 >= birdTypes)
                                {
                                    selected0 = 0;
                                }
                                swipe0 = true;
                            }
                            else if (Input.touches[i].deltaPosition.x < -30)
                            {
                                Debug.Log("Swipe left");
                            }
                        } else
                        {
                            Debug.Log("Swipe left");
                        }
                    }
                } else if (Input.touches[i].phase == TouchPhase.Ended)
                {
                    if (Input.touches[i].position.x < Screen.width / 2)
                    {
                        swipe0 = false;
                    } else
                    {
                        swipe1 = false;
                    }
                }
            }
        }
    }
}
