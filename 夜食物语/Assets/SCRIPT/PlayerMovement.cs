using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 10f; // 走路速度
    public float rotateSpeed = 3f; // 转向速度
    public float speedThreshold = 0.1f; // 动画切换阈值

    private CharacterController _controller;
    private Animator _animator;
    private Vector3 _moveDir;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _controller.minMoveDistance = 0.01f; // 避免抖动
    }
    [Header("跳跃设置")]
    public float jumpHeight = 1.2f; // 跳跃高度

    private float _verticalVelocity;
    private float _gravity = -15f; // 稍微加大重力让手感更干脆

    void Update()
    {
        bool isGrounded = _controller.isGrounded;

        // 1. 地面状态重置速度
        if (isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = -2f;
        }

        // 2. 获取水平移动输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * vertical + transform.right * horizontal; // 相对自身坐标移动

        if (move.magnitude > 0.1f)
        {
            // 执行移动
            _controller.Move(move.normalized * moveSpeed * Time.deltaTime);

            // 【补回这部分】处理人物转向：让小人面向移动的方向
            if (move.magnitude > 0.1f)
            {
                // 执行移动
                _controller.Move(move.normalized * moveSpeed * Time.deltaTime);

                // --- 修复转向太快/乱转的问题 ---
                // 1. 确定目标朝向（仅保留水平方向，防止人物抬头或低头）
                Vector3 lookDir = new Vector3(move.x, 0, move.z);

                if (lookDir != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(lookDir);

                    // 2. 使用你定义的 rotateSpeed 变量，而不是硬编码的 3f
                    // 建议在 Inspector 面板中将 rotateSpeed 调为 5 到 10 之间尝试
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
                }
            }
        }

        // 3. 【新增】跳跃逻辑
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // 物理公式：速度 = 根号下(高度 * -2 * 重力)
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * _gravity);

            // 触发跳跃动画（如果你有的话）
            _animator.SetTrigger("Jump");
        }

        // 4. 应用重力和垂直位移
        _verticalVelocity += _gravity * Time.deltaTime;
        _controller.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);

        // 5. 更新动画状态
        _animator.SetFloat("Speed", move.magnitude * moveSpeed);
        _animator.SetBool("IsGrounded", isGrounded);

     
    }
}