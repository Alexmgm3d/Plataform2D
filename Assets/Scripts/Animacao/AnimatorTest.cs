using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;
    public KeyCode keyTotrigger = KeyCode.A;
    
    public string triggerToPlay = "Fly";


    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyTotrigger))
        {
            animator.SetTrigger(triggerToPlay);
        }
    }
}
