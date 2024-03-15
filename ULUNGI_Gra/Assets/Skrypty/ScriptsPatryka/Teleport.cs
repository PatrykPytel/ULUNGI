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
    private bool isclose;
    public bool old = true;


    // Update is called once per frame
    //  transform.position = uciekaj.position;

    void Update()
    {
        if ((isclose == true) && (Input.GetKeyDown(KeyCode.E)))
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
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            isclose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isclose = false;
        }
    }
}
