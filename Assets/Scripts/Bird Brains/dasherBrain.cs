using UnityEngine;
using System.Collections;

public class dasherBrain : birdBrain
{

    public float dashForce;

    public override void SetStats()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BirdSprites/dasher");

        flapForce = 12;
        flapHorizontal = 2;
        horizontalSpeedMax = 5;
        myRigidBody.mass = 0.8f;
        myRigidBody.gravityScale = 6;
        transform.localScale = new Vector3(goingLeft*0.75f,0.75f,0.75f);
        dashForce = 6;
    }


    public override void Ability()
    {
        myRigidBody.AddForce(new Vector2(dashForce*goingLeft, 0), ForceMode2D.Impulse);
    }
}