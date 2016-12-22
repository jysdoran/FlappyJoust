using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class gameControl : MonoBehaviour {

    void Awake()
    {
        Application.targetFrameRate = 60;
        GameObject bird1 = Instantiate(Resources.Load<GameObject>("Bird"));
        GameObject bird0 = Instantiate(Resources.Load<GameObject>("Bird"));

        bird0.transform.position = new Vector3(0, -2, 0);
        AddType(bird0, Mathf.FloorToInt(Random.Range(0, 4)));

        bird1.transform.position = new Vector3(0, 2, 0);
        AddType(bird1, Mathf.FloorToInt(Random.Range(0, 4)));
        bird1.GetComponent<birdBrain>().goingLeft = -1;
        bird1.transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
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
}
