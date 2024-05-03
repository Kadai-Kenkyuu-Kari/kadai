using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeManager : MonoBehaviour
{
    public float tick;     // ���v���i�ފ���
    public float second;     // �b
    public int minute;     // ��
    public int hour;     // ��
    public int day = 1;     // ��
    public GameObject volumeObject;     // ���邳�𒲐߂���I�u�W�F�N�g

    private Volume volume = null;

    void Start()
    {
        volume = volumeObject.GetComponent<Volume>();
    }


    void FixedUpdate()
    {
        CalculateTime();
        ControlVolume();
    }

    // ���Ԃ̌v�Z
    private void CalculateTime()
    {
        // �o�ߎ��Ԃ��v������
        second += Time.fixedDeltaTime * tick;
        // 60�b��1��
        if (second >= 60)
        {
            second = 0;
            minute++;
        }
        // 60����1����
        if (minute >= 60)
        {
            minute = 0;
            hour++;
        }
        // 24���Ԃ�1��
        if (hour >= 24)
        {
            hour = 0;
            day++;
        }
    }

    // ���邳�̒���
    private void ControlVolume()
    {
        // 21:00�`22:00�̊�
        if (hour >= 21 && hour < 22)
        {
            // ���邳���������Ƒ���������
            volume.weight = (float)minute / 60; 
        }
        // 6:00�`7:00�̊�
        if (hour >= 6 && hour < 7)
        {
            // ���邳���������ƌ���������
            volume.weight = 1 - (float)minute / 60;
        }
    }
}
