using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    [SerializeField] private Sprite YeniGorev;
    [SerializeField] private Image Image;
    [SerializeField] private Animator Anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            if (other.name == "Akademi")
            {
                Anim.SetBool("IsOpen", false);
            }
        }
    }

    public void YeniGorevAl()
    {
        Image.sprite = YeniGorev;
        Anim.SetBool("IsOpen", true);
    }
}
