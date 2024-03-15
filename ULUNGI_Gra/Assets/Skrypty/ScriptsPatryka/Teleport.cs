using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Teleport : MonoBehaviour
{
    public Transform target;
    public Transform oldtarget;
    public GameObject teleport;
    public Animator animator;// Start is called before the first frame update
  //  public bool isclose;
    public bool old = true;
    [SerializeField] private Isclose1 isclose;
    [SerializeField] private Isclose2 isclose2;
    // [SerializeField] private Isclosenew isclose;


    // Update is called once per frame
    //  transform.position = uciekaj.position;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (isclose2.isclose2==true || isclose.isclose == true))
        {
            if (old)
            {
                animator.SetBool("Teleport", true);
                old = false;
                teleport.transform.position = target.position;
            }
            else if (old == false)
            {
                animator.SetBool("Teleport", false);
                old = true;
                teleport.transform.position = oldtarget.position;
            }
        }
    }

}
