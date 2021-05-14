using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    SoundManager sound;
    float v_cnt;

    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float mouseSpeed = 1.0f;
    Rigidbody rigidbody;
    float moveX, moveZ;
    bool moveXpermission, moveZpermission;
    float mouseX, mouseY;
    float rotationXcamera;
    bool mouseXpermission, mouseYpermission;
    Transform camera;
    Vector3 vec3;
    [SerializeField]
    int playerHp = 5;
    public Image damageBoard;
    public GameObject remainingHp;
    [SerializeField]
    float duration = 1.0f, magnitude = 1.0f;
    Vector3 pos;
    [SerializeField]
    float speed = 0.1f;

    public bool stopFlag = false;
    public bool antiFlag = false;

    void Start()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        damageBoard.color = Color.clear;
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
        rotationXcamera = camera.localEulerAngles.x;
        pos = camera.localPosition;
    }


    void Update()
    {
        v_cnt += Time.deltaTime;
        movePermission();
    }
    
    void FixedUpdate()
    {
        if (stopFlag)
        {
            rigidbody.velocity = Vector3.zero;
            return;
        }
        transform.position += transform.TransformDirection(Vector3.forward * speed);
        moveExcution();
    }
    
    void movePermission()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (antiFlag)
        {
            moveX = Input.GetAxis("Vertical") * 100;
            moveZ = Input.GetAxis("Horizontal") * 500;
            mouseX = Input.GetAxis("Mouse Y");
            mouseY = Input.GetAxis("Mouse X");
        }

        if (moveX != 0)
        {
            moveXpermission = true;
        }

        if (moveZ != 0)
        {
            moveZpermission = true;
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
        if (moveXpermission || moveZpermission || mouseXpermission || mouseYpermission)
        {
            moveXpermission = false;
            moveZpermission = false;
            mouseXpermission = false;
            mouseYpermission = false;

            vec3 = new Vector3(moveX * 100, 0, moveZ * 200);

            if (vec3.magnitude > 1)
            {
                rigidbody.velocity = transform.rotation * vec3.normalized * moveSpeed * Time.deltaTime * 100;
            }
            else
            {
                rigidbody.velocity = transform.rotation * vec3 * moveSpeed * Time.deltaTime * 100;
            }

            rigidbody.MoveRotation(Quaternion.Euler(0.0f, rigidbody.rotation.eulerAngles.y + mouseX * Time.deltaTime * 100.0f * mouseSpeed, 0.0f));
            rotationXcamera = Mathf.Clamp(rotationXcamera - mouseY * Time.deltaTime * 100.0f * mouseSpeed, -75, 0);
            camera.localEulerAngles = new Vector3(rotationXcamera, 0, 0);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    public void ReceveDamage(int damageSorce)
    {
        if (v_cnt >= 0.5)
        {
            v_cnt = 0;
            sound.PlaySeByName("othr07");
        }
        playerHp -= damageSorce;
        rigidbody.AddForce(-transform.forward * 250f, ForceMode.VelocityChange);
        StartCoroutine("damageFlashing");
        StartCoroutine(shakeCamera(duration,magnitude));

        if (playerHp <= 19)
        {
            remainingHp.transform.Find("RemainingHp_20").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 18)
        {
            remainingHp.transform.Find("RemainingHp_19").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 17)
        {
            remainingHp.transform.Find("RemainingHp_18").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 16)
        {
            remainingHp.transform.Find("RemainingHp_17").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 15)
        {
            remainingHp.transform.Find("RemainingHp_16").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 14)
        {
            remainingHp.transform.Find("RemainingHp_15").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 13)
        {
            remainingHp.transform.Find("RemainingHp_14").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 12)
        {
            remainingHp.transform.Find("RemainingHp_13").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 11)
        {
            remainingHp.transform.Find("RemainingHp_12").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 10)
        {
            remainingHp.transform.Find("RemainingHp_11").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 9)
        {
            remainingHp.transform.Find("RemainingHp_10").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 8)
        {
            remainingHp.transform.Find("RemainingHp_9").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 7)
        {
            remainingHp.transform.Find("RemainingHp_8").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 6)
        {
            remainingHp.transform.Find("RemainingHp_7").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 5)
        {
            remainingHp.transform.Find("RemainingHp_6").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 4)
        {
            remainingHp.transform.Find("RemainingHp_5").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 3)
        {
            remainingHp.transform.Find("RemainingHp_4").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 2)
        {
            remainingHp.transform.Find("RemainingHp_3").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 1)
        {
            remainingHp.transform.Find("RemainingHp_2").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (playerHp <= 0)
        {
            remainingHp.transform.Find("RemainingHp_1").gameObject.GetComponent<Image>().color = Color.black;
            GameObject.Find("GameManager").GetComponent<RestManager>().subRest();
        }
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
