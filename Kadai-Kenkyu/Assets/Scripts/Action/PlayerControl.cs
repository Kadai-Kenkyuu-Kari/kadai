using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed;     // �v���C���[�̓����X�s�[�h

    private Vector2 playerVelocity;     // �v���C���[�ɉ��������
    private Rigidbody2D rb = null;     // Rigidbody2D�̃R���|�[�l���g���擾���邽�߂ɕK�v

    private void Start()
    {
        // Rigidbody2D�̃R���|�[�l���g���擾
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // �v���C���\�ɗ͂�������
        rb.velocity = playerVelocity * playerSpeed;
    }

    // �ړ��ɕK�v�ȃL�[(InputSystem)���������Ƃ����s
    private void OnMove(InputValue value)
    {
        // �͂̌����Ƒ傫�����擾����
        playerVelocity = value.Get<Vector2>();
    }
}
