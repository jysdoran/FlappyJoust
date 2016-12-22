using UnityEngine;
using System.Collections;

public class flapperBrain : birdBrain
{
    public override void SetStats()
    {
        flapForce = 20;
        flapHorizontal = 2;
        horizontalSpeedMax = 5;
        myRigidBody.mass = 1;
        myRigidBody.gravityScale = 6;
    }
}
