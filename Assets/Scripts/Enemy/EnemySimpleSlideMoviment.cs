using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleSlideMoviment : MonoBehaviour
{

    public int enemySpeed = 1;

    public SliderJoint2D slider;
    private JointMotor2D motor;
    void Start()
    {
        motor = slider.motor;
        motor.motorSpeed = enemySpeed;
        slider.motor = motor;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.limitState == JointLimitState2D.LowerLimit)
        {
            motor.motorSpeed = enemySpeed;
            slider.motor = motor;
        }else if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            motor.motorSpeed = -enemySpeed;
            slider.motor = motor;
        }
    }
}
