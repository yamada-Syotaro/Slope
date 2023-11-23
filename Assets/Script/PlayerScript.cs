using UnityEngine;

/// <summary>
/// ����I�ȃL�����N�^�[����X�L�[�}����������B
/// �u�J�������猩�������v�ɃL�����N�^�[�uRigidbody.AddForce ���g���āv�������B
/// �~�܂鎞�̌������ Rigidbody.Drag �� Physics Material �Œ�������B
/// </summary>
public class PlayerScript : MonoBehaviour
{
    [SerializeField] float _movePower = 3;
    Rigidbody _rb = default;
    /// <summary>���͂��ꂽ������ XZ ���ʂł̃x�N�g��</summary>
    Vector3 _dir;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = Vector3.forward * v + Vector3.right * h;
        // �J�����̃��[�J�����W�n����� dir ��ϊ�����
        _dir = Camera.main.transform.TransformDirection(_dir);
        // �J�����͎΂߉��Ɍ����Ă���̂ŁAY ���̒l�� 0 �ɂ��āuXZ ���ʏ�̃x�N�g���v�ɂ���
        _dir.y = 0;
        // �L�����N�^�[���u���݂́iXZ ���ʏ�́j�i�s�����v�Ɍ�����
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }
    }

    void FixedUpdate()
    {
        // �u�͂�������v�����͗͊w�I�����Ȃ̂� FixedUpdate �ōs������
        _rb.AddForce(_dir.normalized * _movePower, ForceMode.Force);
    }
}
