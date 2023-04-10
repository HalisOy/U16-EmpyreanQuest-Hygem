using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera AimVirtualCamera;
    private ThirdPersonController thirdPersonController;
    private Animator anim;
    [SerializeField] Image Crosshair;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform PfBulletProjectile;
    [SerializeField] private Transform SpawnBulletPosition;

    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HedefAtes();
        Attack();
    }

    private void Attack()
    {
        if (starterAssetsInputs.shoot)
        {
            anim.SetTrigger("Attack");
            starterAssetsInputs.shoot = false;
        }
    }

    private void HedefAtes()
    {
        Vector3 MouseWorldPosition = Vector3.zero;
        Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            MouseWorldPosition = raycastHit.point;
        }


        if (starterAssetsInputs.aim)
        {
            AimVirtualCamera.gameObject.SetActive(true);
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            Crosshair.color = new Color(Crosshair.color.r, Crosshair.color.g, Crosshair.color.b, Mathf.Lerp(Crosshair.color.a, 1, Time.deltaTime * 3f));
            thirdPersonController.SetRotateOnMove(false);

            Vector3 WorldAimTarget = MouseWorldPosition;
            WorldAimTarget.y = transform.position.y;
            Vector3 AimDirection = (WorldAimTarget - transform.position).normalized;
            transform.right = Vector3.Lerp(transform.right, -AimDirection, Time.deltaTime * 20f);

            if (starterAssetsInputs.shoot)
            {
                Vector3 AimDir = (MouseWorldPosition - SpawnBulletPosition.position).normalized;
                Instantiate(PfBulletProjectile, SpawnBulletPosition.position, Quaternion.LookRotation(AimDir, Vector3.up));
                starterAssetsInputs.shoot = false;
            }
        }
        else
        {
            AimVirtualCamera.gameObject.SetActive(false);
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            Crosshair.color = new Color(Crosshair.color.r, Crosshair.color.g, Crosshair.color.b, Mathf.Lerp(Crosshair.color.a, 0, Time.deltaTime * 3f));
            thirdPersonController.SetRotateOnMove(true);
        }
    }
}
