using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogTexts : MonoBehaviour
{
    public TextMeshProUGUI scriptTextObject;     // // ���e�̃e�L�X�g��\������I�u�W�F�N�g
    public TextMeshProUGUI nameTextObject;     // ���O�̃e�L�X�g��\������I�u�W�F�N�g
    public int textNumber;     // n�Ԗ�

    private int choiceSelectNumber;     // �I�񂾑I�����̔ԍ�
    private int previousChoiceSelectNumberSaveListLength;     // ���X�g�̒����̕ύX�m�F�p

    private void Start()
    {
        // ������Ԃł̃��X�g�̒�����ۑ�
        previousChoiceSelectNumberSaveListLength = 
            StoryManager.choiceSelectNumberSaveList.Count;
    }

    public void Update()
    {
        // �e�L�X�g�����͂���Ă���Ƃ�
        if (StoryManager.scriptTexts[textNumber] != "")
        {
            // �e�L�X�g��ݒ肷��
            scriptTextObject.text = StoryManager.scriptTexts[textNumber];
            nameTextObject.text = StoryManager.nameTexts[textNumber];
        }
        // �I�������\������Ă���Ƃ�
        else
        {
            // ���O�̃e�L�X�g��\�������Ȃ�
            nameTextObject.text = "";
            // choiceSelectNumber�����X�g�͈͓̔����`�F�b�N
            if (choiceSelectNumber >= 0 && choiceSelectNumber < StoryManager.choiceSelectNumberSaveList.Count)
            {
                // 1�̑I�������I�΂ꂽ��
                if (StoryManager.choiceSelectNumberSaveList[choiceSelectNumber] == 1)
                {
                    // 1�̑I�����Ɠ����e�L�X�g��
                    scriptTextObject.text = StoryManager.choiceOne[textNumber];
                }
                // 2�̑I�������I�΂ꂽ��
                else if (StoryManager.choiceSelectNumberSaveList[choiceSelectNumber] == 2)
                {
                    // 2�̑I�����Ɠ����e�L�X�g��
                    scriptTextObject.text = StoryManager.choiceTwo[textNumber];
                }
            }
        }
        // choiceSelectNumberSaveList�̃��X�g�̒������Ď�
        monitorChoiceSelectNumber();
    }

    // choiceSelectNumberSaveList�̃��X�g�̒������Ď�
    private void monitorChoiceSelectNumber()
    {
        // choiceSelectNumberSaveList�̒������ύX���ꂽ�Ƃ�
        if (previousChoiceSelectNumberSaveListLength != StoryManager.choiceSelectNumberSaveList.Count)
        {
            choiceSelectNumber = StoryManager.choiceSelectNumberSaveList.Count;
            // ���݂̃��X�g�̒�����ۑ�
            previousChoiceSelectNumberSaveListLength = 
                StoryManager.choiceSelectNumberSaveList.Count;
        }
    }
}
