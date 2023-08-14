using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim; // Đối tượng Animator để điều khiển hoạt ảnh
    public Rigidbody2D rb; // Đối tượng Rigidbody2D để điều khiển vật lý
    public float moveSpeed; // Tốc độ di chuyển

    private Vector3 dir, vel; // Hướng di chuyển và vận tốc
    private float x, y; // Biến lưu trữ input ngang và dọc
    private const string Hor = "Horizontal"; // Tên input ngang
    private const string Ver = "Vertical"; // Tên input dọc
    private const string Move = "isMove"; // Tên tham số hoạt ảnh

    private void Update()
    {
        x = Input.GetAxis(Hor); // Lấy giá trị input ngang
        y = Input.GetAxis(Ver); // Lấy giá trị input dọc

        dir = new Vector3(x, y); // Xác định hướng di chuyển dựa trên input
        vel = dir.normalized * moveSpeed; // Tính toán vận tốc dựa trên hướng và tốc độ
    }

    private void FixedUpdate()
    {
        if (dir.magnitude > .1f) // Nếu hướng di chuyển có giá trị lớn hơn 0.1
        {
            // Cho player di chuyển
            rb.velocity = vel * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero; // Ngừng di chuyển
        }

        Animate(dir.magnitude > .1f); // Gọi hàm điều khiển hoạt ảnh dựa trên việc di chuyển

        if (x > 0)
        {
            transform.eulerAngles = Vector3.zero; // Quay hướng nhân vật theo trục Y
        }
        else if (x < 0)
        {
            transform.eulerAngles = Vector3.up * 180; // Quay hướng nhân vật theo trục Y 180 độ
        }
    }

    private void Animate(bool isMove)
    {
        anim.SetBool(Move, isMove); // Đặt tham số hoạt ảnh dựa trên việc di chuyển
    }
}