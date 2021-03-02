using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    public GameObject target;
    public Vector3 target_pos;
    public Bounds targetRange = new Bounds(new Vector3(0, 0, 0), new Vector3(50, 50, 50));
    public Vector2 distanceRange = new Vector2(0, 200);
    //public Vector2 eulerXRange;
    //public Vector2 eulerYRange;

    public float moveLerpSpeed = 30;
    public float rotateLerpSpeed = 30;

    public float speedMove = 50;
    public float speedRotate = 300;
    public float speedScalling = 100;

    [SerializeField]
    private float m_Distance;
    private Quaternion m_Rotation;

    void Start()
    {
        if (target)
        {
            target_pos = target.transform.position;
            Vector3 look_forward = target.transform.forward;
        }

        m_Rotation = transform.rotation;

        m_Distance = Vector3.Distance(transform.position, target_pos);

        transform.position = target_pos - transform.forward * m_Distance;
    }

    void Update()
    {
        float _scrollWheelValue = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetMouseButton(1))
        {
            CameraRotate();
        }
        if (Input.GetMouseButton(2))
        {
            CameraMove();
        }
        CameraScalling(_scrollWheelValue);

        Vector3 camPos = target_pos - transform.forward * m_Distance;

        transform.rotation = Quaternion.Lerp(transform.rotation, m_Rotation, Time.deltaTime * rotateLerpSpeed);
        transform.position = Vector3.Lerp(transform.position, camPos, Time.deltaTime * moveLerpSpeed);
    }

    private void CameraMove()
    {
        target_pos += (-Input.GetAxis("Mouse X") * transform.right - Input.GetAxis("Mouse Y") * transform.up) * Time.deltaTime * speedMove;

        target_pos.x = Mathf.Clamp(target_pos.x, targetRange.min.x, targetRange.max.x);
        target_pos.y = Mathf.Clamp(target_pos.y, targetRange.min.y, targetRange.max.y);
        target_pos.z = Mathf.Clamp(target_pos.z, targetRange.min.z, targetRange.max.z);
    }

    private void CameraScalling(float axis)
    {
        if (Mathf.Abs(axis) > 0.01f)
        {
            m_Distance -= Time.deltaTime * axis * speedScalling;
            m_Distance = Mathf.Clamp(m_Distance, distanceRange.x, distanceRange.y);
        }
    }

    private void CameraRotate()
    {
        Vector3 _rotation = transform.rotation.eulerAngles;
        Vector3 rotate_input = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        _rotation += rotate_input * Time.deltaTime * speedRotate;
        Debug.Log(string.Format("get rotation {0}", rotate_input.ToString()));

        //_rotation.x = Mathf.Clamp(_rotation.x, eulerXRange.x, eulerXRange.y);
        //_rotation.y = Mathf.Clamp(_rotation.y, eulerYRange.x, eulerYRange.y);

        _rotation.z = 0;

        m_Rotation = Quaternion.Euler(_rotation);
    }
}