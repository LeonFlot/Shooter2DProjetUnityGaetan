using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private InputMapController _playerInput;
    private InputAction _Weapon;

    [SerializeField]private Transform aimTransform;
    [SerializeField]private GameObject transformSpawnBullet;

    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private GameObject player;

    private float timer;

    [SerializeField] private float fireRate;

    [SerializeField] bool _useAngle, _useOldAngle, _rotateWeapon;

    [SerializeField] Vector3 _viewAimDirection, _viewMousePosition, _viewDirection;

    private bool shootON;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInput = new InputMapController();
        _Weapon = _playerInput.Player.Shoot;
        
    }
    private void Start()
    {
        _playerInput.Enable();
    }
    private void OneBullet()
    {
        Instantiate(bulletPrefab, transformSpawnBullet.transform.position, transform.rotation);
    }
    private void Enabool()
    {
        shootON = true;
    }
    private void Disabool()
    {
        shootON= false;
    }

    private void Update()
    {
        if (_rotateWeapon)
        {
            if (_useAngle)
            {
                if (_useOldAngle)
                {
                    WeaponFollowMouse();
                }
                else
                {
                    FollowMouseAngle();
                }

            }
            else
            {
                FollowMouse();
            }
        }

        
        Shoot();
        _playerInput.Player.Shoot.started += ctx => OneBullet();
        _playerInput.Player.Shoot.performed += ctx => Enabool();
        _playerInput.Player.Shoot.canceled += ctx => Disabool();
    }

    private void FollowMouse()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        mousePosition.z = Camera.main.nearClipPlane;

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        aimTransform.right = aimDirection;

        _viewAimDirection = aimDirection;
        _viewMousePosition = mousePosition;
        _viewDirection = (mousePosition - transform.position);
    }

    private void FollowMouseAngle()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - aimTransform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        aimTransform.rotation = rotation;

        _viewAimDirection = new Vector3();
        _viewMousePosition = dir;
        _viewDirection = new Vector3(rotation.x, rotation.y, rotation.z);
    }

    private void WeaponFollowMouse()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - player.transform.position);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        //transform.LookAt(mousePosition);
    }

    /// <summary>
    /// Create and lanch a bullet on forward of weapon
    /// </summary>
    private void Shoot()
    {
        if(shootON)
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                Instantiate(bulletPrefab, transformSpawnBullet.transform.position, transform.rotation);
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 vec  = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        Debug.Log(vec);
        //vec.z = 0;
        return vec;
    }

    private Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, -15));
        return worldPosition;
    }
}
