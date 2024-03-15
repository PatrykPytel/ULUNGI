using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KratySkrypt : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") == true)
        {
            animator.SetBool("Otwieranie", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") == true)
        {
            animator.SetBool("Otwieranie", false);
        }
    }
}
