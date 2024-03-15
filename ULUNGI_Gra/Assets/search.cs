using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class search : MonoBehaviour
{
    public bool isclose;
    public bool opened;
    public GameObject gameObject;
    public Animator animator;
    // Start is called before the first frame update

    void Update()
    {
        if ((isclose == true) && (Input.GetKeyDown(KeyCode.E)) && (opened == false))
        {
            Destroy(gameObject);
            animator.SetBool("Wypadnij", true);
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
