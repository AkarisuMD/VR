using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Animation_Hand_Script : MonoBehaviour
{
    public InputActionProperty trigger_Input;
    public InputActionProperty grip_Input;

    public Animator hand_Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float trigger = trigger_Input.action.ReadValue<float>();
        hand_Animator.SetFloat("Trigger", trigger);

        float grip= grip_Input.action.ReadValue<float>();
        hand_Animator.SetFloat("Grip", grip);
    }
}
