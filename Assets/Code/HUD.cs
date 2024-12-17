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
                // 진행 시간 텍스트 업데이트
                float gameTime = GameManager.instance.gameTime; // 남은 시간 계산
                int min = Mathf.FloorToInt(gameTime / 60); // 분 단위 계산
                int sec = Mathf.FloorToInt(gameTime % 60); // 초 단위 계산
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec); // "MM:SS" 형식으로 시간 표시
                break;
            case InfoType.Health:
                float curHealth = Player.instance.health; // 현재 체력
                float maxHealth = Player.instance.maxhealth;
                mySlider.value = curHealth / maxHealth; // 체력 비율로 슬라이더 값 설정
                break;
            case InfoType.HealthP:
                // 체력 슬라이더 업데이트
                float cHealth = Player.instance.health; // 현재 체력
                if (cHealth < 0)
                {
                    myText.text = "0%"; // 0 미만일 경우 출력하지 않음
                }
                else
                {
                    myText.text = string.Format("{0:F1}%", cHealth); // 소수점 첫 번째 자리까지 출력
                }
            break;
            case InfoType.expp:
                // 현재 경험치와 다음 레벨업에 필요한 경험치
                float currentExp = GameManager.instance.exp;
                float maxExpp = GameManager.instance.nextExp[Mathf.Min(Player.instance.playerlevel, GameManager.instance.nextExp.Length - 1)];

                // 경험치 비율 계산
                float expPercentage = (currentExp / maxExpp) * 100f; // 퍼센트 값으로 변환

                // 값 보정 (0% 미만 방지)
                if (expPercentage < 0)
                {
                    myText.text = "0%";
                }
                else
                {
                    myText.text = string.Format("Exp : {0:F1}%", expPercentage); // 소수점 1자리까지 표시
                }
                break;

        }
    }
}
