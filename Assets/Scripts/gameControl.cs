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
        bird0.AddComponent<diveFlapperBrain>();

        bird1.transform.position = new Vector3(0, 2, 0);
        bird1.AddComponent<diverBrain>();
        bird1.GetComponent<birdBrain>().goingLeft = -1;
        bird1.transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
