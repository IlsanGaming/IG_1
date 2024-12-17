using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType
    {
        Exp,
        Jam,
        Level,
        Time,
        Health,
        HealthP,
        expp,
    }
    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }
    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp=GameManager.instance.nextExp[GameManager.instance.Gamelevel];
                mySlider.value = curExp/maxExp;
                break;
            case InfoType.Jam:
                float bCurHealth=Bus.instance.health;
                float bMaxHealth=Bus.instance.maxhealth;
                mySlider.value=bCurHealth/bMaxHealth;
                break;
            case InfoType.Level:
                myText.text = string.Format("{0:F0}", Player.instance.playerlevel);
                break;
            case InfoType.Time:
                // ���� �ð� �ؽ�Ʈ ������Ʈ
                float gameTime = GameManager.instance.gameTime; // ���� �ð� ���
                int min = Mathf.FloorToInt(gameTime / 60); // �� ���� ���
                int sec = Mathf.FloorToInt(gameTime % 60); // �� ���� ���
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec); // "MM:SS" �������� �ð� ǥ��
                break;
            case InfoType.Health:
                float curHealth = Player.instance.health; // ���� ü��
                float maxHealth = Player.instance.maxhealth;
                mySlider.value = curHealth / maxHealth; // ü�� ������ �����̴� �� ����
                break;
            case InfoType.HealthP:
                // ü�� �����̴� ������Ʈ
                float cHealth = Player.instance.health; // ���� ü��
                if (cHealth < 0)
                {
                    myText.text = "0%"; // 0 �̸��� ��� ������� ����
                }
                else
                {
                    myText.text = string.Format("{0:F1}%", cHealth); // �Ҽ��� ù ��° �ڸ����� ���
                }
            break;
            case InfoType.expp:
                // ���� ����ġ�� ���� �������� �ʿ��� ����ġ
                float currentExp = GameManager.instance.exp;
                float maxExpp = GameManager.instance.nextExp[Mathf.Min(Player.instance.playerlevel, GameManager.instance.nextExp.Length - 1)];

                // ����ġ ���� ���
                float expPercentage = (currentExp / maxExpp) * 100f; // �ۼ�Ʈ ������ ��ȯ

                // �� ���� (0% �̸� ����)
                if (expPercentage < 0)
                {
                    myText.text = "0%";
                }
                else
                {
                    myText.text = string.Format("Exp : {0:F1}%", expPercentage); // �Ҽ��� 1�ڸ����� ǥ��
                }
                break;

        }
    }
}
