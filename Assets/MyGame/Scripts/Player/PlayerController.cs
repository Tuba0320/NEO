using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    static SoundManager sound;
    static int cnt_find = 0;
    Vector3 pos;
    Rigidbody rigidbody;
    Transform camera;
    Vector3 vec3;

    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float mouseSpeed = 1.0f;
    [SerializeField]
    float AlwaysMoveSpeed = 0.1f;

    float moveX;
    bool moveXpermission;
    float mouseX, mouseY;
    float rotationXcamera;
    float rotationYcamera;
    bool mouseXpermission, mouseYpermission;

    [SerializeField]
    int playerHp = 5;
    [SerializeField]
    Slider hpSlider;
    public Image damageBoard;

    [SerializeField]
    float duration = 1.0f, magnitude = 1.0f;

    public bool stopFlag = false;
    public bool antiFlag = false;

    [SerializeField]
    float interval_damage = 0.2f;
    float cnt_damage = 0f;
    float interval_se = 28f;
    float cnt_se = 0f;
    

    [SerializeField]
    GameObject body;

    void Start()
    {
        if (cnt_find < 1)
        {
            sound = GameObject.Find("GameManager").GetComponent<SoundManager>();
            cnt_find++;
        }
        hpSlider.maxValue = playerHp;
        damageBoard.color = Color.clear;
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
        rotationXcamera = camera.localEulerAngles.x;
        rotationYcamera = camera.localEulerAngles.y;
        pos = camera.localPosition;
        sound.PlaySeByName("戦闘機内（飛行中）");
    }


    void Update()
    {
        cnt_se += Time.deltaTime;
        cnt_damage += Time.deltaTime;
        movePermission();
        if (transform.position.z <= -150)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, 150);
        }
        
        if (interval_se >= cnt_se)
        {
            return;
        }
        if (stopFlag)
        {
            sound.StopSe();
        }
        cnt_se = 0;
        sound.PlaySeByName("戦闘機内（飛行中）");
    }
    
    void FixedUpdate()
    {
        hpSlider.value = playerHp;

        if (stopFlag)
        {
            rigidbody.velocity = Vector3.zero;
            return;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += transform.TransformDirection(Vector3.forward * AlwaysMoveSpeed * 0.25f);
        }
        else
        {
            transform.position += transform.TransformDirection(Vector3.forward * AlwaysMoveSpeed);
        }
        moveExcution();
    }
    
    void movePermission()
    {
        moveX = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        if (antiFlag)
        {
            mouseX = Input.GetAxis("Mouse Y");
            mouseY = Input.GetAxis("Mouse X");
        }

        if (moveX != 0)
        {
            moveXpermission = true;
        }

        if (mouseX != 0)
        {
            mouseXpermission = true;
        }

        if (mouseY != 0)
        {
            mouseYpermission = true;
        }
    }

    void moveExcution()
    {
        if (moveXpermission || mouseXpermission || mouseYpermission)
        {
            moveXpermission = false;
            mouseXpermission = false;
            mouseYpermission = false;

            vec3 = new Vector3(moveX * 200, 0, 0);

            if (vec3.magnitude > 1)
            {
                rigidbody.velocity = transform.rotation * vec3.normalized * moveSpeed * Time.deltaTime * 100;
            }
            else
            {
                rigidbody.velocity = transform.rotation * vec3 * moveSpeed * Time.deltaTime * 100;
            }
            rotationXcamera = Mathf.Clamp(rotationXcamera - mouseY * Time.deltaTime * 100.0f * mouseSpeed, -100, 5);
            rotationYcamera = Mathf.Clamp(rotationYcamera - -mouseX * Time.deltaTime * 100.0f * mouseSpeed, -35, 35);
            body.transform.localEulerAngles = new Vector3(rotationXcamera, rotationYcamera, 0);
            camera.localEulerAngles = new Vector3(rotationXcamera, rotationYcamera, 0);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    public void ReceveDamage(int damageSorce)
    {
        if (cnt_damage >= interval_damage)
        {
            sound.PlaySeByName("パソコンの電源を切る");
            cnt_damage = 0;
            playerHp -= damageSorce;
            StartCoroutine("damageFlashing");
            StartCoroutine(shakeCamera(duration, magnitude));
        }
        if (playerHp <= 0)
        {
            GameObject.Find("GameManager").GetComponent<RestManager>().Rest--;
            playerHp = 20;
        }
    }

    public void setPlayerHp(int num)
    {
        if (playerHp + num > 20)
        {
            return;
        }
        playerHp += num;
    }

    IEnumerator damageFlashing()
    {
        damageBoard.color = new Color(1f, 0f, 0f, 0.7f);
        yield return new WaitForSeconds(0.15f);
        damageBoard.color = Color.clear;
    }

    IEnumerator shakeCamera(float duration,float magnitude)
    {
        var elapsed = 0f;

        while (elapsed < duration)
        {
            camera.localPosition = new Vector3(pos.x + Random.Range(-1f, 1f) * magnitude, pos.y + Random.Range(-1f, 1f) * magnitude, pos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        camera.localPosition = pos;
    }

    public void SetStopFlag(bool flag)
    {
        stopFlag = flag;
    }

    public bool GetStopFlag()
    {
        return stopFlag;
    }

    public void SetAntiFlag(bool flag)
    {
        antiFlag = flag;
    }
}
