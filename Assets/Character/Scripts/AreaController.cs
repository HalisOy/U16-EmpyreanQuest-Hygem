using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaController : MonoBehaviour
{
    [SerializeField] GameObject CharacterImageText;

    [SerializeField] GameObject AreaText;
    [SerializeField] Animator Anim;

    [SerializeField] Sprite Azorka;
    [SerializeField] Sprite BilgeBuyucu;
    [SerializeField] Sprite BuzGolem;

    [SerializeField] Sprite Arena;
    [SerializeField] Sprite Portal;
    [SerializeField] Sprite Kuyu;
    [SerializeField] Sprite Akademi;
    [SerializeField] Sprite Sunak;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            if (other.name == "Arena")
            {
                AreaText.GetComponent<Image>().sprite = Arena;
                Anim.SetTrigger("IsVisible");
                CharacterImageText.GetComponent<Image>().sprite = BuzGolem;
            }
            if (other.name == "Portal")
            {
                AreaText.GetComponent<Image>().sprite = Portal;
                Anim.SetTrigger("IsVisible");
            }
            if (other.name == "Kuyu")
            {
                AreaText.GetComponent<Image>().sprite = Kuyu;
                Anim.SetTrigger("IsVisible");
            }
            if (other.name == "Akademi")
            {
                AreaText.GetComponent<Image>().sprite = Akademi;
                Anim.SetTrigger("IsVisible");
                CharacterImageText.GetComponent<Image>().sprite = BilgeBuyucu;
            }
            if (other.name == "Sunak")
            {
                AreaText.GetComponent<Image>().sprite = Sunak;
                Anim.SetTrigger("IsVisible");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterImageText.GetComponent<Image>().sprite = Azorka;
    }
}
