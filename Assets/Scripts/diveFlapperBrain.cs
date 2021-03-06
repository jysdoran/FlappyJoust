﻿using UnityEngine;
using System.Collections;

public class diveFlapperBrain : birdBrain
{

    public float diveForce;

    public override void SetStats()
    {
        flapForce = 20;
        flapHorizontal = 2;
        horizontalSpeedMax = 5;
        myRigidBody.mass = 1;
        myRigidBody.gravityScale = 6;
        diveForce = 20;
    }


    public override void Ability()
    {
        myRigidBody.AddForce(new Vector2(0, -diveForce), ForceMode2D.Impulse);
        flapDelayTimer = 0.08f;
    }
}
