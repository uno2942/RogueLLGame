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
    ItemManager itemmanager;

    void Start() {
        logger = GameObject.Find("Logger").GetComponent<Logger>() as Logger;
        itemmanager = GameObject.Find("ItemManager").GetComponent<ItemManager>() as ItemManager;
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
        NurseHeal, // 간호사 회복
        GunnerBuff, // 거너 공격력 증가
    }

    /**
     * Name : 인자를 받아 플레이어가 볼 인자 이름의 string으로 바꾸어 줌
     * Subj/ObjName : 주어/목적어에 따라 은는이가 를 붙인 string을 반환함
     * AndName: 와/과 를 붙여서 반환함
     * 
     */



    private string Name(Unit subject)
    {
        string name = "강원기";
        if (subject is Player) name = "당신";
        else if (subject is Rat) name = "쥐";
        else if (subject is Dog) name = "개";
        else if (subject is Human) name = "사람";
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
        Debug.Log(subject.ToString());
        if (subject is Player) name = "당신은";
        else if (subject is Rat) name = "쥐가";
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
        if (target is Player) name = "당신을";
        else if (target is Rat) name = "쥐를";
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

    private string AndName(ItemManager.Label label) //캡슐 한정 사용
    {
        string name = "";
        if (label == ItemManager.Label.CaffeinCapsule1 || label == ItemManager.Label.CaffeinCapsule2 || label == ItemManager.Label.CaffeinCapsule3) name = "카페인 알약과";
        else if (label == ItemManager.Label.CureAll1 || label == ItemManager.Label.CureAll2 || label == ItemManager.Label.CureAll3) name = "만병통치약과";
        else if (label == ItemManager.Label.Hallucinogen1 || label == ItemManager.Label.Hallucinogen2 || label == ItemManager.Label.Hallucinogen3) name = "환각제와";
        else if (label == ItemManager.Label.LiquidFlameMedicine1 || label == ItemManager.Label.LiquidFlameMedicine2 || label == ItemManager.Label.LiquidFlameMedicine3) name = "매운 알약과";
        else if (label == ItemManager.Label.PoisonCapsule1 || label == ItemManager.Label.PoisonCapsule2 || label == ItemManager.Label.PoisonCapsule3) name = "독약과";
        else if (label == ItemManager.Label.Salt1 || label == ItemManager.Label.Salt2 || label == ItemManager.Label.Salt3) name = "소금과";
        else if (label == ItemManager.Label.Soup1 || label == ItemManager.Label.Soup2 || label == ItemManager.Label.Soup3) name = "수프와";
        else if (label == ItemManager.Label.VitaminTablet1 || label == ItemManager.Label.VitaminTablet2 || label == ItemManager.Label.VitaminTablet3) name = "비타민 알약과";

        else
        {
            Debug.Log("이름이 정의되지 않은 아이템이 있습니다.");
            return "Unnamed Item";
        }

        return name;
    }

    private string Name(ItemManager.Label label) //캡슐 한정 사용
    {
        string name = "";
        if (label == ItemManager.Label.CaffeinCapsule1 || label == ItemManager.Label.CaffeinCapsule2 || label == ItemManager.Label.CaffeinCapsule3) name = "카페인 알약";
        else if (label == ItemManager.Label.CureAll1 || label == ItemManager.Label.CureAll2 || label == ItemManager.Label.CureAll3) name = "만병통치약";
        else if (label == ItemManager.Label.Hallucinogen1 || label == ItemManager.Label.Hallucinogen2 || label == ItemManager.Label.Hallucinogen3) name = "환각제";
        else if (label == ItemManager.Label.LiquidFlameMedicine1 || label == ItemManager.Label.LiquidFlameMedicine2 || label == ItemManager.Label.LiquidFlameMedicine3) name = "매운 알약";
        else if (label == ItemManager.Label.PoisonCapsule1 || label == ItemManager.Label.PoisonCapsule2 || label == ItemManager.Label.PoisonCapsule3) name = "독약";
        else if (label == ItemManager.Label.Salt1 || label == ItemManager.Label.Salt2 || label == ItemManager.Label.Salt3) name = "소금";
        else if (label == ItemManager.Label.Soup1 || label == ItemManager.Label.Soup2 || label == ItemManager.Label.Soup3) name = "수프";
        else if (label == ItemManager.Label.VitaminTablet1 || label == ItemManager.Label.VitaminTablet2 || label == ItemManager.Label.VitaminTablet3) name = "비타민 알약";

        else
        {
            Debug.Log("이름이 정의되지 않은 아이템이 있습니다.");
            return "Unnamed Item";
        }

        return name;
    }

    private string ObjName(ItemManager.Label label)
    {
        string name = "";
        
        if (label == ItemManager.Label.AutoHandgun) name = "자동권총을";
        else if (label == ItemManager.Label.BlackKnife) name = "검은 식칼을";
        else if (label == ItemManager.Label.Club) name = "각목을";
        else if (label == ItemManager.Label.Hammer) name = "망치를";
        else if (label == ItemManager.Label.Lighter) name = "라이터를";
        else if (label == ItemManager.Label.Mess) name = "매스를";
        else if (label == ItemManager.Label.Nuckle) name = "너클을";
        else if (label == ItemManager.Label.SharpDagger) name = "단검을";
        else if (label == ItemManager.Label.Shock) name = "제세동기를";
        //else if (label == ItemManager.Label.Injector) name = "주사기를"; //미구현
        
        else if (label == ItemManager.Label.BloodJacket) name = "피 묻은 가죽 재킷을";
        else if (label == ItemManager.Label.CleanDoctorCloth) name = "깔끔한 의사 가운을";
        else if (label == ItemManager.Label.DamagedDoctorCloth) name = "해진 의사 가운을";
        else if (label == ItemManager.Label.FullPlated) name = "판금 갑옷을";
        else if (label == ItemManager.Label.Padding) name = "두꺼운 패딩을";
        else if (label == ItemManager.Label.Patient) name = "환자복을";
        else if (label == ItemManager.Label.Tshirts) name = "티셔츠를";

        else if (label == ItemManager.Label.MorfinDrug) name = "모르핀을";
        else if (label == ItemManager.Label.AdrenalineDrug) name = "아드레날린을";
        else if (label == ItemManager.Label.RingerSolution) name = "링겔액을";
        else if (label == ItemManager.Label.Can) name = "통조림을";
        else if (label == ItemManager.Label.Water) name = "물을";
        else if (label == ItemManager.Label.Bandage) name = "붕대를";
        else if (label == ItemManager.Label.Medicine) name = "약품을";
        else if (label == ItemManager.Label.WhiteCard) name = "하얀 키 카드를";
        else if (label == ItemManager.Label.BlackCard) name = "검정 키 카드를";
        else if (label == ItemManager.Label.YellowCard) name = "노란 키 카드를";

        else if (label == ItemManager.Label.CaffeinCapsule1 || label == ItemManager.Label.CaffeinCapsule2 || label == ItemManager.Label.CaffeinCapsule3) name = "카페인 알약을";
        else if (label == ItemManager.Label.CureAll1 || label == ItemManager.Label.CureAll2 || label == ItemManager.Label.CureAll3) name = "만병통치약을";
        else if (label == ItemManager.Label.Hallucinogen1 || label == ItemManager.Label.Hallucinogen2 || label == ItemManager.Label.Hallucinogen3) name = "환각제를";
        else if (label == ItemManager.Label.LiquidFlameMedicine1 || label == ItemManager.Label.LiquidFlameMedicine2 || label == ItemManager.Label.LiquidFlameMedicine3) name = "매운 알약을";
        else if (label == ItemManager.Label.PoisonCapsule1 || label == ItemManager.Label.PoisonCapsule2 || label == ItemManager.Label.PoisonCapsule3) name = "독약을";
        else if (label == ItemManager.Label.Salt1 || label == ItemManager.Label.Salt2 || label == ItemManager.Label.Salt3) name = "소금을";
        else if (label == ItemManager.Label.Soup1 || label == ItemManager.Label.Soup2 || label == ItemManager.Label.Soup3) name = "수프를";
        else if (label == ItemManager.Label.VitaminTablet1 || label == ItemManager.Label.VitaminTablet2 || label == ItemManager.Label.VitaminTablet3) name = "비타민 알약을";

        else
        {
            Debug.Log("이름이 정의되지 않은 아이템이 있습니다.");
            return "Unnamed Item";
        }
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
        if (subject.ToString() == "Gunner" && action == UnitAction.GunnerBuff) s = "외팔의 명사수: \"사격 개시...!\"";
        else if (subject.ToString() == "Nurse" && action == UnitAction.NurseHeal) s = "노련한 간호사: \"크윽...치료가 필요하겠어.\"";
        else
        {
            Debug.Log("정의되지 않은 방법으로 MakeActionMessage를 호출하였습니다.");
            return;
        }

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

        if (action != UnitAction.Attack) // 잘못된 호출
        {
            Debug.Log("정의되지 않은 방법으로 MakeAttackMessage를 호출하였습니다.");
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
            Debug.Log("정의되지 않은 방법으로 MakeAttackMessage를 호출하였습니다.");
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
            s += "< color =#ff0000ff>";
            s += Name(subject);
            s += " 공격으로 인해 죽었습니다...</color>";

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
    public void MakeItemMessage(UnitAction action, ItemManager.Label item)
    {
        string s = "";
        if (action == UnitAction.EatCapsule)
        {
            Debug.Log("정의되지 않은 방법으로 MakeItemMessage를 호출하였습니다." +
                " EatCapsule로 call시 물 섭취 여부를 true/false로 입력하세요.");
            return;
        }

        if (action == UnitAction.PickItem || action == UnitAction.TakeCapsule)  //아이템 습득
        {
            if (itemmanager.GetItemIdentificationInfo(item) == false)
            {
                s = "미식별 알약을 얻었습니다.";
            }
            else
            {
                s = ObjName(item) + " 얻었습니다.";
            }
        }

        else if (action == UnitAction.UseItem || action == UnitAction.InjectItem) // 아이템(소모품) 사용
        {
            s = ObjName(item) + " 사용했습니다.";
        }
        else
        {
            Debug.Log("정의되지 않은 방법으로 MakeItemMessage를 호출하였습니다.");
            return;
        }

        logger.AddLog(s);
    }

    //TakeCapsule시 여러 개를 획득할 때 한정으로 사용하는 오버로딩 함수
    public void MakeItemMessage(UnitAction action, ItemManager.Label item, int n)
    {
        string s = "";
        if (action != UnitAction.TakeCapsule)
        {
            Debug.Log("정의되지 않은 방법으로 MakeItemMessage를 호출하였습니다.");
            return;
        }
        else
        {
            if (itemmanager.GetItemIdentificationInfo(item) == false)
            {
                s = "미식별 알약 " + n + "개를 얻었습니다.";
            }
            else
            {
                s += Name(item) + " " + n + "개를 얻었습니다.";
            }
        }
        logger.AddLog(s);
    }

    //EatCapsule시 한정하여 사용하는 오버로딩 함수, 물을 사용했는지를 인자로 받는다
    public void MakeItemMessage(UnitAction action, ItemManager.Label item, bool water)
    {
        string s = "";
        if (action != UnitAction.EatCapsule)
        {
            Debug.Log("정의되지 않은 방법으로 MakeItemMessage를 호출하였습니다.");
            return;
        }
        else
        {
            if ( water )
            {
                s = ObjName(item) + " 물과 함께 복용했습니다.";
            }
            else
            {
                s += AndName(item) + " 함께 먹을 물이 없어 억지로 삼켰습니다.";
            }
        }
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
