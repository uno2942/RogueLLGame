using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * \brief 콘솔창 컴포넌트에 붙어 유닛들의 Action에 따라 출력할 문장을 만들고
 * 출력하는 클래스
 * 
 * 향후 수정이 필요한 부분
 * 1. Start()의 Gameobject.find에서 Logger를 붙이는 콘솔창 오브젝트의 테그를 교체하기
 * 2. 물을 몸에 뿌리는 부분의 메서드 추가
 * 3. 보스의 특수 액션을 enum에 추가하고, 이에 따른 특수 대서 출력
 * 4. 환자 무리 포함한 GameObject의 이름 확인하고 이에 맞추어 Tostring의 비교 대상 변경
 * 5. Logger에 글자 색을 변경할 수 있는 옵션이 추가되면 이에 맞추어 플레이어 사망 시에 call하는 함수 변경
 */

public class MessageMaker : MonoBehaviour {

    Logger logger;

    void Start () {
		logger = GameObject.Find("Logger").GetComponent<Logger>();
    }

/**
* 인자로 사용하는 유닛 행동의 열거형
*/
    public enum UnitAction
    {
        Attack,
        UseItem, EatCapsule, InjectItem, //아이템 사용
        PickItem, TakeCapsule, //아이템 획득
        Move, //이동: 카드 에러시 사용
    }

    /**
     * Name : 인자를 받아 플레이어가 볼 인자 이름의 string으로 바꾸어 줌
     * Subj/ObjName : 주어/목적어에 따라 은는이가 를 붙인 string을 반환함
     * 
     */

    private string Name(Unit subject)
    {
        string name = "강원기";
        if (subject.ToString() == "Player") name = "당신";
        else if (subject.ToString() == "Rat") name = "쥐";
        else if (subject.ToString() == "Dog") name = "개";
        else if (subject.ToString() == "Human") name = "사람";
        else if (subject.ToString() == "BoundedCrazy") name = "구속된 미치광이";
        else if (subject.ToString() == "Gunner") name = "외팔의 명사수";
        else if (subject.ToString() == "Nurse") name = "노련한 간호사";
        else if (subject.ToString() == "AngryDog") name = "분노의 맹견";
        // else if (subject.ToString() == "") name = "환자";
        else if (subject.ToString() == "HospitalDirector") name = "정신병원 원장";
        else name = "프로그래머의 실수로 이름이 지정되지 않은 무엇인가";

        return name;
    }

    private string SubjName(Unit subject)
    {
        string name = "강원기";
        if (subject.ToString() == "Player") name = "당신은";
        else if (subject.ToString() == "Rat") name = "쥐가";
        else if (subject.ToString() == "Dog") name = "개가";
        else if (subject.ToString() == "Human") name = "사람이";
        else if (subject.ToString() == "BoundedCrazy") name = "구속된 미치광이가";
        else if (subject.ToString() == "Gunner") name = "외팔의 명사수가";
        else if (subject.ToString() == "Nurse") name = "노련한 간호사가";
        else if (subject.ToString() == "AngryDog") name = "분노의 맹견이";
        // else if (subject.ToString() == "") name = "환자가";
        else if (subject.ToString() == "HospitalDirector") name = "정신병원 원장이";
        else name = "프로그래머의 실수로 이름이 지정되지 않은 무엇인가가";

        return name;
    }

    private string ObjName(Unit target)
    {
        string name = "강원기";
        if (target.ToString() == "Player") name = "당신을";
        else if (target.ToString() == "Rat") name = "쥐를";
        else if (target.ToString() == "Dog") name = "개를";
        else if (target.ToString() == "Human") name = "사람을";
        else if (target.ToString() == "BoundedCrazy") name = "구속된 미치광이를";
        else if (target.ToString() == "Gunner") name = "외팔의 명사수를";
        else if (target.ToString() == "Nurse") name = "노련한 간호사를";
        else if (target.ToString() == "AngryDog") name = "분노의 맹견을";
        // else if (Subject.ToString() == "") name = "환자가";
        else if (target.ToString() == "HospitalDirector") name = "정신병원 원장을";
        else name = "프로그래머의 실수로 이름이 지정되지 않은 무엇인가를";

        return name;
    }

    private string ObjName()
    {
        string name = "s";
        return name;
    }


    /**
    * 타 오브젝트와 상호작용 없는 단독 행동시 MakeMessage 함수, 보스의 특수액션 시 사용
    * 7월 29일 기준 미완성된 메서드입니다.
    */
    public void MakeActionMessage(Unit subject, UnitAction action)
    {
        //switch case by Subject and Action. 
        string s = "보스가 특수한 행동을 합니다.";
        logger.AddLog(s);
    }

    /**
    * 전투로 인한 데미지 출력 시 MakeMessage 함수
    * 인자로 UnitAction:Attack을 받지 않으면 에러 메세지 띄움. 추후 확장 가능성도 있음.
    */
    public void MakeAttackMessage(Unit subject, UnitAction action, Unit target, int damage)
    {
        //switch case by Subject and Action. 
        string s = "Error: MakeAttackMessage가 call되었으나 string이 제대로 생성되지 않았습니다.";

        if(action != UnitAction.Attack) // 잘못된 호출
        {
            Debug.Log("MakeAttackMessage가 잘못된 행동 인자를 받았습니다.");
            return;
        }

        if (subject.ToString() == "Player") //플레이어 공격   
        {
            s = "";
            s += SubjName(subject);
            s += " "; // "당신은 "
            s += ObjName(target); 
            s += " 공격하여 "; // "당신은 대상을 "
            s += damage;
            s += "의 피해를 주었습니다."; // "당신은 대상을 공격하여 1의 피해를 주었습니다."
        }

        else // 플레이어 방어
        {
            s = "";
            s += SubjName(subject);
            s += " "; // "적이 "
            s += ObjName(target);
            s += " 공격하여 "; // "적이 당신을 공격하여 "
            s += damage;
            s += "의 피해를 주었습니다."; // "적이 당신을 공격하여 1의 피해를 주었습니다."
        }
        logger.AddLog(s);
    }

    /**
    * 전투로 인한 데미지 출력 시 MakeMessage 함수에서 치명타가 터질 시 overload
    * 인자로 UnitAction:Attack을 받지 않으면 에러 메세지 띄움. 추후 확장 가능성도 있음.
    * 현재 기획서 기준으로 치명타는 플레이어에서만 발동하므로 그 부분만 구현했습니다.
    * 사실 위의 메서드를 아예 사용하지 않고 이 메서드만 사용해도 무방합니다.
    */
    public void MakeAttackMessage(Unit subject, UnitAction action, Unit target, int damage, bool crit)
    {
        //switch case by Subject and Action. 
        string s = "Error: MakeAttackMessage가 call되었으나 string이 제대로 생성되지 않았습니다.";

        if (action != UnitAction.Attack) // 잘못된 호출
        {
            Debug.Log("MakeAttackMessage가 잘못된 행동 인자를 받았습니다.");
            return;
        }

        if (subject.ToString() == "Player") //플레이어 공격   
        {
            s = "";
            s += SubjName(subject);
            s += " "; // "당신은 "
            if (crit == true)
            {
                s += Name(target);
                s += "에게 치명적인 일격을 가했습니다! "; // "당신은 대상에게 치명적인 일격을 가했습니다! "
            }
            else
            {
                s += ObjName(target);
                s += " 공격하여 "; // "당신은 대상을 공격하여"
            }
            s += damage;
            s += "의 피해를 주었습니다.";

        }

        else // 플레이어 방어
        {
            s = "";
            s += SubjName(subject);
            s += " "; // "적이 "
            s += ObjName(target);
            s += " 공격하여 "; // "적이 당신을 공격하여 "
            s += damage;
            s += "의 피해를 주었습니다."; // "적이 당신을 공격하여 1의 피해를 주었습니다."
            if (crit == true)
            {
                s = "기획서상으로 적이 치명타를 가했을 리가 없는데요?";
            }
        }

        logger.AddLog(s);
    }

    /**
     * 전투로 인한 사망 시에 Message를 출력하는 함수
     */
    public void MakeDeathMessage(Unit subject, Unit deadUnit)
    {
        string s = "";
        if (deadUnit.ToString() == "Player")
        {
            s += Name(subject);
            s += " 공격으로 인해 죽었습니다...";

            logger.AddLog(s); // 글자색 변경 필요!!!!
        }
        else
        {
            s += ObjName(subject);
            s += " ";
            s += SubjName(deadUnit);
            s += " 공격하여 처치했습니다.";
            logger.AddLog(s);
        }
    }


    /**
    * 아이템과 관련된 메세지를 출력하는 함수
    * 상황에 따라 3가지 오버로딩
    */

    // 보통 아이템 관련 메세지 출력하는 오버로딩 함수
    public void MakeItemMessage(UnitAction action, ItemManager.ItemCategory item)
    {
        string s = "";
        if(action == UnitAction.EatCapsule)
        {
            Debug.Log("MakeItemMessage 인자 사용 오류");
            return;
        }
        if (action == UnitAction.PickItem || action == UnitAction.TakeCapsule)
        {
            
        }

        logger.AddLog(s);
    }

    //TakeCapsule시 여러 개를 획득할 때 한정으로 사용하는 오버로딩 함수
    public void MakeItemMessage(UnitAction action, ItemManager.ItemCategory item, int n)
    {
        string s = "";
        logger.AddLog(s);
    }

    //EatCapsule시 한정하여 사용하는 오버로딩 함수, 물을 사용했는지를 인자로 받는다
    public void MakeItemMessage(UnitAction action, ItemManager.ItemCategory item, bool water)
    {
        string s = "";
        logger.AddLog(s);
    }


    /**
    * 아이템과 관련된 메세지를 출력하는 함수
    * 상황에 따라 3가지 오버로딩
    */

    public void MakeCannotMessage(UnitAction action)
    {
        string s = "";
        if(action == UnitAction.InjectItem)
        {
            s = "지금은 이 주사기를 사용할 수 없습니다.";
        }
        else if(action == UnitAction.Move )
        {
            s = "이 문은 잠겨있습니다. 문 옆에 카드 리더기가 있습니다.";
        }
        else
        {
            s = "Undefined CannotMessage Called";
            Debug.Log("지정되지 않은 예외 상황에서 MakeCannotMessage를 사용했습니다.");
        }
        logger.AddLog(s);
    }

}
