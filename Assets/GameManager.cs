using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs Inputs;
    [SerializeField] private GameObject EscMenu;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        OnEscape();
    }

    private void OnEscape()
    {
        if (Inputs.esc)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            EscMenu.SetActive(true);
        }
    }

    private void OffEscape()
    {
        EscMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Inputs.esc = false;
    }

    public void Resume()
    {
        OffEscape();
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
