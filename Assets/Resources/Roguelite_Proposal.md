로그라이트 게임(제목 미정) – G-pos

<!-- [TOC] -->
- [게임 규칙](#%EA%B2%8C%EC%9E%84-%EA%B7%9C%EC%B9%99)
- [게임 정보](#%EA%B2%8C%EC%9E%84-%EC%A0%95%EB%B3%B4)
  - [플레이어](#%ED%94%8C%EB%A0%88%EC%9D%B4%EC%96%B4)
    - [체력](#%EC%B2%B4%EB%A0%A5)
    - [정신력](#%EC%A0%95%EC%8B%A0%EB%A0%A5)
    - [허기](#%ED%97%88%EA%B8%B0)
    - [공격력](#%EA%B3%B5%EA%B2%A9%EB%A0%A5)
    - [방어력](#%EB%B0%A9%EC%96%B4%EB%A0%A5)
    - [인벤토리](#%EC%9D%B8%EB%B2%A4%ED%86%A0%EB%A6%AC)
  - [적](#%EC%A0%81)
    - [공통 사항](#%EA%B3%B5%ED%86%B5-%EC%82%AC%ED%95%AD)
    - [쥐](#%EC%A5%90)
    - [개](#%EA%B0%9C)
    - [사람](#%EC%82%AC%EB%9E%8C)
  - [NPC](#npc)
    - [NPC 리스트](#npc-%EB%A6%AC%EC%8A%A4%ED%8A%B8)
  - [보스](#%EB%B3%B4%EC%8A%A4)
    - [보스 리스트](#%EB%B3%B4%EC%8A%A4-%EB%A6%AC%EC%8A%A4%ED%8A%B8)
  - [상태이상](#%EC%83%81%ED%83%9C%EC%9D%B4%EC%83%81)
    - [상태이상 리스트](#%EC%83%81%ED%83%9C%EC%9D%B4%EC%83%81-%EB%A6%AC%EC%8A%A4%ED%8A%B8)
  - [전투 시스템](#%EC%A0%84%ED%88%AC-%EC%8B%9C%EC%8A%A4%ED%85%9C)
    - [공격 피해 계산](#%EA%B3%B5%EA%B2%A9-%ED%94%BC%ED%95%B4-%EA%B3%84%EC%82%B0)
    - [명중/회피](#%EB%AA%85%EC%A4%91%ED%9A%8C%ED%94%BC)
  - [장비](#%EC%9E%A5%EB%B9%84)
    - [장비 등급](#%EC%9E%A5%EB%B9%84-%EB%93%B1%EA%B8%89)
    - [무기](#%EB%AC%B4%EA%B8%B0)
    - [방어구](#%EB%B0%A9%EC%96%B4%EA%B5%AC)
  - [알약](#%EC%95%8C%EC%95%BD)
    - [알약 리스트](#%EC%95%8C%EC%95%BD-%EB%A6%AC%EC%8A%A4%ED%8A%B8)
  - [기타 아이템](#%EA%B8%B0%ED%83%80-%EC%95%84%EC%9D%B4%ED%85%9C)
    - [주사기](#%EC%A3%BC%EC%82%AC%EA%B8%B0)
    - [일반 소모품](#%EC%9D%BC%EB%B0%98-%EC%86%8C%EB%AA%A8%ED%92%88)
    - [키 카드](#%ED%82%A4-%EC%B9%B4%EB%93%9C)
  - [맵 생성](#%EB%A7%B5-%EC%83%9D%EC%84%B1)
    - [방의 종류](#%EB%B0%A9%EC%9D%98-%EC%A2%85%EB%A5%98)
# 게임 규칙

- 인원 수: 1
- 6층으로 이루어진 정신병동에서 탈출하는 것이 목적이다.
- 본 게임은 턴제 로그라이트(Rogue-lite) 게임이다.
- 자신의 차례에 할 수 있는 행동은 다음과 같다.
  - 이동: 인접한 방이나 복도로 이동한다. 잠긴 방은 맞는 키 카드가 있을 경우 자동으로 사용하며 이동한다.
  - 공격: 대상 하나에게 공격한다.
  - 아이템 사용: 인벤토리의 아이템을 선택한 다음 사용한다.
  - 아이템 획득: 바닥에 놓여있는 아이템을 자신의 인벤토리에 넣는다.
  - 장비 착용: 인벤토리의 장비를 선택한 다음 착용한다. 다른 장비를 끼고 있을 때 착용을 시도하면 기존 장비를 벗고 새 장비를 착용한다.
  - 장비 해제: 현재 착용중인 장비를 벗는다.
  - 휴식: 아무 것도 하지 않는다. 체력을 1 회복한다. 
- 턴 진행 순서는 다음과 같다.
  - 플레이어 턴 > 플레이어 정신력 체크 > 플레이어 상태이상 체크 > 적1 턴 > 적1 상태이상 체크 > 적2 턴 > 적2 상태이상 체크 > ... > 다시 플레이어 턴
  - 단, 이동 직후에는 '적 턴 > 적 상태이상 체크'를 하지 않는다.
  - 적이 있는 방에서는 이동을 할 수 없다. (도망 불가능)

# 게임 정보

## 플레이어
### 체력
- Visible
- **150/150**으로 시작. 
- 체력이 0 이하가 되면 사망한다. 
- 체력 최대치는 드물게 증가할 수 있다.
- Integer
### 정신력
- Visible
- **100/100**, 정상 상태로 시작. 
- 정신력 최대치는 어떠한 경우에도 변하지 않는다. 
- 정신력은 0 미만이 되지 않으며, 현재 정신력보다 많은 정신력을 잃을 경우 그 수치만큼 체력을 대신 잃는다. 
    - 이 경우 잃는 체력은 소수점을 버리고 계산한다.
    - 예: 14.4 정신력에서 26.8 정신력을 잃어야 한다면, 14.4 정신력과 12 체력을 대신 잃는다.
- 정신력에 따라 정상/환각 상태로 나뉘며, 매 턴마다 정신력 체크를 한다.
    - 정상 상태
        - 평범한 상태.
        - 정신력 체크시 정신력 30 초과: 층에 따라 정신력 -0.5/-0.5/-1/-1/-1.4/-1.4
        - 정신력 체크시 정신력 30 이하: 정신력 = 0이 되며 환각 상태로 돌입 
    - 환각 상태
        - 적이 강력해지며, 높은 층일수록 더 많이 강해진다. 보스의 경우 패턴이 달라질 수 있다.
        - 정신력 체크시 정신력 60 미만: 층에 따라 정신력 +1.2/+1.2/+1.2/+0.8/+0.8/+0.8
        - 정신력 체크시 정신력 60 이상: 정신력 = 100이 되며 정상 상태로 복귀
- Float
### 허기
- Invisible: 현재 상태이상으로 짐작 가능.
- **50/150**으로 시작. 
- 플레이어 상태이상 체크를 할 때마다 +1.
- 150 이상이 되면 즉시 사망.
- Integer

### 공격력

- Invisible: 장비 기본 능력치는 알 수 있으나, 상태이상에 따라 최종 수치는 달라질 수 있다.
- 적에게 주는 피해를 결정한다. 
- 맨손 공격력은 **2-7**이다.
- 착용한 무기에 따라 달라지며, 최소 수치는 0이다.
- Integer

### 방어력

- Invisible: 장비 기본 능력치는 알 수 있으나, 상태이상에 따라 최종 수치는 달라질 수 있다.
- 적에게서 받는 피해를 경감한다.
- 맨몸 방어력은 **0-1**이다.
- 착용한 방어구에 따라 달라지며, 최소 수치는 0이다.
- Integer

### 인벤토리

* Visible
* 12칸의 인벤토리, 1칸의 무기 슬롯, 1칸의 방어구 슬롯를 보유하며, 같은 종류의 아이템은 몇 개를 소유하더라도 한 칸의 공간만 차지한다. 단, 장비 아이템은 서로 겹쳐지지 않는다.
* 무기/방어구 슬롯은 현재 착용중인 무기/방어구가 차지하는 공간이다.
* 인벤토리가 가득 찼다면 현재 보유하지 않은 종류의 아이템을 획득할 수 없다. 가진 아이템을 버린 다음 획득해야 한다.
* 버린 아이템은 영구적으로 사라지며, 다시 획득할 수 없다.
* 여러 개 가진 아이템을 버릴 경우, 버릴 개수를 지정하여 버릴 수 있다.

## 적

### 공통 사항

* 모든 적은 플레이어가 공격하지 않아도 **플레이어를 적대**한다.
* 일반 적으로는 쥐, 개, 사람이 있다.
* 아래 나온 스탯은 모두 정상 상태일때의 최소 공격력/방어력이다.
  * 최대 공격력/방어력 = 최소 공격력/방어력의 **2배**
  * 환각 상태일 경우, 현재 층에 따라 모든 적의 최소 공격력/방어력에 +1/+1/+3/+4/+7/+9 보정이 가해진다.
* 모든 적의 등장 확률은 동일하다. 고정 등장의 경우 제외.

### 쥐

* 체력: 7/9/18/22/40/47
* 최소 공격력: 1/1/1/1/3/3
* 최소 방어력: 0/0/0/0/1/1
* 공격시 0/0/10/10/40/40% 확률로 플레이어에게 **2턴의 중독**을 부여한다.
  * 환각 상태라면, 대신 25/25/45/45/90/90% 확률로 **2턴의 중독**을 부여한다.

### 개

* 체력: 30/35/63/70/110/125
* 최소 공격력: 3/3/5/6/9/11
* 최소 방어력: 1/1/2/2/3/3
* 공격시 0/0/10/10/40/40% 확률로 플레이어에게 **3턴의 출혈**을 부여한다.
  * 환각 상태라면, 대신 25/25/45/45/90/90% 확률로 **3턴의 출혈**을 부여한다.

### 사람

* 체력: 50/60/100/115/170/195
* 최소 공격력: 2/2/4/5/7/9
* 최소 방어력: 1/1/3/4/6/7
* 처치시 10/10/15/15/20/20% 확률로 **아드레날린**이나 **모르핀** 1개를 드롭한다.
  * 정상 상태이며 아드레날린과 모르핀을 소지하고 있지 않다면 대신 20/20/30/30/40/40% 확률로 드롭한다.
  * 환각 상태이며 아드레날린과 모르핀을 소지하고 있지 않다면 대신 100% 확률로 드롭한다.

## NPC

* 플레이어에게 도움이 되는 중립 캐릭터이다.
* 공격 불가능, 물약 던지기 대상으로 선택 불가능.

### NPC 리스트

- 약품 전문가
  - 일회용.
  - 임의의 알약 1종류를 식별해 준다.
  - NPC를 선택하면 대화 창이 등장한다. 이 때 인벤토리의 알약 하나를 선택하면 식별해 준다. 이미 식별된 알약을 선택할 경우에도 사용 기회를 소진한다.
- 주사기 수집가
  - 일회용.
  - 모르핀이나 아드레날린, 링겔액을 요구한다. 건네줄 경우 통조림 2개와 물 2개, 그리고 만병통치약을 제외한 임의의 서로 다른 알약 2개를 받는다.
  - 5층 휴게실에서 반드시 등장하며, 여기서는 위의 보상 대신 전설 등급 주사기를 준다.
  - NPC를 선택하면 대화 창이 등장한다. 이 때 인벤토리의 모르핀/아드레날린/링겔액을 선택하면 건네준다.
- 알약 공급기
  - 여러 번 사용 가능. 
  - 최초 1회는 100%, 이후 50% 확률로 만병통치약을 제외한 알약 1개를 준다. 단, 실패할 경우 자판기가 폭발하여 30의 피해를 입으며 더 이상 사용할 수 없게 된다. 휴게실에서 반드시 등장한다.
  - NPC를 선택하면 대화 창이 등장한다. 이 때 '사용'을 선택 시 사용한다.
- 정신과 의사
  - 일회용.
  - 환각 상태를 해제하고 정신력을 모두 회복한다.
  - NPC를 선택하면 대화 창이 등장한다. 이 때 '사용'을 선택 시 사용한다.
- 구급상자
  - 일회용.
  - 1번만 사용 가능. 출혈, 중독, 화상을 해제하고 체력을 모두 회복한다.
  - NPC를 선택하면 대화 창이 등장한다. 이 때 '사용'을 선택 시 사용한다.

## 보스

- 보스는 강력한 적으로, 보스 방에서 반드시 1기가 등장한다.
- 층별로 어떤 보스가 등장하는지는 미리 정해져 있으며, 능력치도 정해져 있다.

- 아래 리스트에 적힌 공격력/방어력 수치는 모두 **최소** 공격력/방어력이다.
- 보스의 최대 공격력/방어력은 최소 공격력/방어력의 3배이다.

### 보스 리스트

- 1층 = 구속된 미치광이
  - 일반: 체력 180, 공격력 2, 방어력 0
  - 환각: 공격력 11, 방어력 0
  - 플레이어는 매 턴 정신력 체크를 할 때마다 정신력을 1.2 잃는다.
  - 2턴에 1회 공격
- 2층 = 외팔의 명사수
  - 일반: 체력 300, 공격력 2, 방어력 2
  - 환각: 공격력 3, 방어력 3
  - 체력이 90 미만으로 떨어지면 5턴간 최소 공격력이 **10**으로 증가한다.
  - 플레이어가 공격 피해를 10 이상 받을 경우 플레이어를 1턴간 기절시킨다.
  - 처치시 **자동권총**을 무조건 드랍한다.
- 3층 = 노련한 간호사
  - 일반: 체력 450, 공격력 6, 방어력 1
  - 환각: 공격력 10, 방어력 2
  - 플레이어가 공격 피해를 4 이상 받을 경우 플레이어를 3턴간 출혈시킨다.
  - 체력이 100 미만이 된 이후 행동 가능한 첫 턴에 무조건 자신의 체력을 225까지 회복한다. (이 패턴은 1회만 한다)
- 4층 = 분노의 맹견
  - 일반: 체력 550, 공격력 4, 방어력 1
  - 환각: 공격력 7, 방어력 2
  - 1턴에 2회 공격. 환각 상태일 경우 3회 공격.
  - 이 보스는 준 피해의 1/3 (소수점 버림)만큼 자신의 체력을 회복한다.
- 5층 = 환자 무리
  - 일반: 체력 140, 공격력 3, 방어력 5, **5개체 등장**
  - 환각: 공격력 6, 방어력 12
  - 환자 하나가 쓰러질 때마다 남은 환자들의 최소 공격력 +1, 최소 방어력 +1.
  - 환자가 하나만 남으면 즉시 정신력 0의 환각 상태가 된다.
- 6층 = 정신병원 원장
  - 일반: 체력 300, 공격력 6, 방어력 6
  - 환각: 공격력 11, 방어력 11
  - 플레이어가 이 보스에게 가한 최종 피해량이 12(환각 상태에서는 6) 이상일 경우, 12(환각시 6)의 피해만 받는다.
  - 플레이어가 이 보스를 공격하면 정신력 **-10**.
  - 플레이어가 휴식할 경우 정신력 +6.
  - 최종 보스. 처치하면 게임에 승리한다!

## 상태이상

* 상태이상은 플레이어나 적에게 다양한 일시적 효과를 부여한다.
* 상태이상의 지속 시간이 남은 상태에서 같은 상태이상이 다시 부여된 경우, 효과 중첩 없이 남은 지속 시간만 가산된다.
* 상태이상으로 인한 체력 회복 / 손실이 동시에 있다면 회복이 먼저 이루어진 다음 손실이 이루어진다.

### 상태이상 리스트

* 화상
  * 플레이어, 일반 적, 보스에게 적용 가능.
  * 매 턴마다 3의 피해를 받는다. 
  * 최종 공격력 -2, 최종 방어력 -2 (ex: 공격력 14-45, 방어력 6-11는 공격력 12-43, 방어력 4-9로 적용된다)
* 중독
  * 플레이어, 일반 적, 보스에게 적용 가능.
  * 매 턴마다 1의 피해를 받는다. 
  * 받는 공격 피해가 1 증가한다.
* 출혈
  - 플레이어에게만 적용 가능.
  * 공격/이동을 한 경우 5의 피해를, 이외의 경우 2의 피해를 입는다.
* 배부름
  * 플레이어에게만 적용 가능.
  * 매 턴마다 체력을 2 회복한다.
  * 허기 증가 속도 2배.
  * 허기 수치 0-49일 때 발생.
* 배고픔
  * 플레이어에게만 적용 가능.
  * 효과 없음.
  * 허기 수치 100-129일 때 발생.
* 굶주림
  - 플레이어에게만 적용 가능.
  * 매 턴마다 1의 피해를 받는다. 
  * 허기 수치 130 이상일 경우 발생.
* 기절
  * 일반 적에게만 적용 가능.
  * 자신의 턴에 강제로 휴식한다.
  * 받는 공격 피해가 3 증가한다.
* 재생
  * 플레이어에게만 적용 가능.
  * 매 턴마다 체력을 5 회복한다.
* 모르핀
  * 플레이어에게만 적용 가능.
  * 받는 피해가 0.5배로 감소한다.
  * 최종 공격력 -7.
  * 효과 도중에는 아드레날린을 사용할 수 없다.

* 아드레날린
  * 플레이어에게만 적용 가능.
  * 주는 피해가 1.6배로 증가한다.
  * 받는 피해가 1.2배로 증가한다.
  * 효과 도중에는 모르핀을 사용할 수 없다.
* 카페인
  * 플레이어에게만 적용 가능.
  * 최종 공격력 +7, 최종 방어력 +2
  * 매 턴마다 정신력을 1.2 잃는다.
* 어지러움
  * 일반 적에게만 적용 가능.
  * 최종 공격력이 1 이상일 경우 1이 된다.
* 진정
  * 플레이어, 일반 적, 보스에게 적용 가능.
  * 최종 공격력 -3.
* 무방비
  * 일반 적, 보스에게 적용 가능.
  * 최종 방어력이 0으로 고정된다.

## 전투 시스템

### 공격 피해 계산

- {(공격자의 공격력) – (방어자의 방어력) + (중독/기절 보정)} × (모르핀/아드레날린 보정) × (치명타 보정) = (최종 피해) (최소 1, 소수점 버림)
- 단, 공격자 공격력이 **0**인 경우, 공격 피해는 **0**이다.
- integer

### 명중/회피

* 모든 공격은 **반드시 명중**한다.

## 장비

### 장비 등급

* 일반/희귀/전설 등급이 존재
* 최소 성능은 등급 불문하고 동일
* 최대 성능은 높은 등급일수록 증가
* 매 층마다 비품실을 제외한 공간에서 0-2개의 무기/방어구가 등장
* 아이템 생성시, 등급을 먼저 결정한 다음 가능한 리스트에서 임의로 장비 하나를 뽑아 생성
* 아이템 등장 확률은 다음과 같다.
  * 일반: 77-(7×층수)% (70/63/56/49/42/35)
  * 희귀: 20+(5×층수)% (25/30/35/40/45/50)
  * 전설: 3+(2×층수)% (5/7/9/11/13/15)

### 무기

* 모든 무기의 최대 공격력은 일반/희귀/전설 등급에서 각각 최소 공격력의 **2배+3/3배+2/4배+1**이다.
* 따로 서술하지 않은 무기는 일반/희귀/전설 등급이 모두 존재한다.
* 라이터: 최소 공격력 3.
  * 맞은 적을 3/4/5턴간 화상 상태로 만든다.
* 너클: 최소 공격력 4.
  * 공격시 대상에게 2/2/3회 공격한다. 
* 주사기: 최소 공격력 5.
  * 맞은 적을 4/5/6턴간 중독 상태로 만든다.
* 단검: 최소 공격력 6.
  * 공격시 10% 확률로 3배의 피해를 주는 치명타가 발생한다.
* 매스: 최소 공격력 7.
* 망치: 최소 공격력 8. 
  * 공격시 허기가 즉시 1 증가한다.
* 각목: 최소 공격력 10. 
  * 공격시 25/20/15% 확률로 최소 공격력이 1 감소한다.
* 제세동기: 공격력 10-41.
  * 맞은 적을 5턴간 기절시킨다. 
  * 5회 사용 제한. 
  * 전설 등급만 존재.
* 검은 식칼: 최소 공격력 12. 
  * 착용하고 있는 동안 영구적으로 환각 상태가 된다.
  * 착용하고 있는 동안 정신력이 59 이상으로 올라가지 않는다. 
  * 희귀/전설 등급만 존재.
* 자동권총: 공격력 16-65. 
  * 17회 사용하면 사라진다. 남은 탄약 수를 항상 볼 수 있다.
  * 전설 등급만 존재.

### 방어구

- 모든 방어구의 최대 방어력은 일반/희귀/전설 등급에서 각각 최소 공격력의 **2배-1/3배-2/4배-3**이다.
- 따로 서술하지 않은 방어구는 일반/희귀/전설 등급이 모두 존재한다.
- 피 묻은 가죽 재킷: 최소 방어력 1. 
  - 환각 상태라면 최소 방어력이 9로 증가한다.
  - 매 턴 정신력 체크시 정신력 -0.8
- 티셔츠: 최소 방어력 1. 
  - 휴식할 때 50% 확률로 허기를 소모하지 않는다. 
  - 일반 등급만 존재.
- 환자복: 최소 방어력 2. 
  - 통조림을 먹으면 체력을 10 추가로 회복한다.
- 해진 의사 가운: 최소 방어력 4.
- 두꺼운 패딩: 최소 방어력 6. 
  - 20회 공격받으면 망가진다. 내구도를 항상 볼 수 있다.
- 깔끔한 의사 가운: 최소 방어력 5. 
  - 매 턴 정신력 체크시 정신력 +1 
  - 희귀/전설 등급만 존재.
- 판금 갑옷: 방어력 12-45. 
  - 허기 증가 속도 5배. '배부름' 상태이상이 있을 경우 곱연산으로 계산(총 10배).
  - 전설 등급만 존재.

## 알약

* 기본적으로 미식별 상태이다.
  * 다른 종류의 알약끼리는 모두 외형이 다르다.
  * 같은 종류의 알약끼리는 모두 외형이 같다.
* 사용시 인벤토리에 물이 있다면 물을 1개 소모한다. (물과 함께 삼킨다는 설정)
* 사용시 인벤토리에 물이 없다면 알약 효과를 적용한 다음 정신력을 20 잃는다. (그냥 억지로 먹는다는 설정)
* 매 층마다 만병통치약을 제외한 알약이 최소 3종류 이상 생성되며, 3~10개 생성된다.

### 알약 리스트

- 만병통치약
  - 체력 +150. 정신력 +100.
  - 환각/화상/중독/출혈을 해제.
  - 체력이 최대일 경우 체력을 회복하는 대신 체력 최대치 +20. 
  - 각 층마다 2개만 등장한다(약품 창고에 1개, 잠긴 방 중 하나에 1개).
- 환각제
  - 환각 상태가 아니라면, 환각 상태가 되며, 정신력은 30이 된다.
  - 이미 환각 상태였다면 정신력을 10 깎는다. 
  - 던지기 효과: 대상 하나에 3턴의 '어지러움' 효과를 부여한다.
- 매운 알약
  - 자신과 방 안의 모든 적에게 10턴의 '화상' 효과를 부여한다.
  - 던지기 효과: 대상 하나에 15턴의 '화상' 효과를 부여한다.
- 카페인 알약
  - 정신력 +25. 
  - 30턴의 '카페인' 효과를 얻는다.
- 발포 비타민
  - 정신력 +15, 체력 +15. 
  - 10턴의 '진정' 효과를 얻는다.
  - 던지기 효과: 대상 하나에 30턴의 '진정' 효과를 부여한다.
- 수프
  - 체력 +30, 정신력 +20, 허기 -45.
- 진통제
  - 체력 +5, 정신력 +5. 
  - 체력이 50 미만일 경우 추가로 체력 +20. 
  - 환각 상태일 경우 즉시 정상 상태가 되며 정신력 수치는 60이 된다.
- 독약
  - 15턴의 '중독' 효과를 얻는다.
  - 던지기 효과: 대상 하나에 15턴의 '중독' 효과를 부여한다.
- 소금
  - 정신력 -20. 
  - 환각 상태라면 추가로 정신력 -20. 
  - 던지기 효과: 대상 하나에 5턴의 '무방비' 효과를 부여한다.

## 기타 아이템

### 주사기

* 식별되어 있다.
* 매 층마다 0-2개 생성되며, 일반 적 '사람'을 처치하여 얻을 수도 있으며 이 수에는 제한이 없다.
* 각 주사기의 등장 확률은 모두 동일하다.

- 모르핀
  * 정신력 +25.
  * 30턴의 '모르핀' 효과를 얻는다.
- 아드레날린
  - 정신력 -10.
  - 10턴의 '아드레날린' 효과를 얻는다.
- 링겔액
  - 정신력 +5.
  - 환각 상태가 아닐 경우 추가로 정신력 +10. 
  - 10턴의 '재생' 효과를 얻는다.

### 일반 소모품

- 통조림
  - 체력 +10, 허기 -70. 
  - 매 층마다 1~2개 나온다.
- 물
  - 정신력 +5. 
  - 환각 상태일 경우 추가로 정신력 +5. 
  - 매 층마다 8개 나온다. 
  - 마시는 대신 화상을 해제할 수 있다.
- 약품
  - 자신의 중독 상태를 해제한다.
  - 매 층마다 0~3개 나온다.
- 붕대
  - 자신의 출혈 상태를 해제한다. 
  - 매 층마다 0~3개 나온다.

### 키 카드

- 하얀 키 카드
  - 잠긴 방을 연다. 
  - 해당 층의 잠긴 방 수와 동일한 양만큼 생성된다.
- 검은 키 카드
  - 다음 층으로 가는 문을 연다. 
  - 보스를 잡으면 반드시 1개 나온다.
- 노란 키 카드
  - 약품 창고의 문을 연다. 
  - 매 층마다 1개 생성된다.
- 사용하지 않은 키 카드는 층을 넘어가는 순간 모두 사라진다.

## 맵 생성

* 미리 정해진 몇 종류의 구조 중 하나 형태의 맵이 생성된다.
* 아이템 등장시 60% 확률로 일반 소모품, 20% 확률로 알약, 10% 확률로 주사기, 10% 확률로 장비가 등장한다. 단, 생성 상한을 넘긴 아이템은 나오지 않는다(re-roll).

### 방의 종류

- 일반 방
  - 생성 수: 층당 7-10개.
  - 고정 생성
    - '하얀 키 카드' 1개 + 아이템 1개: 해당 층의 잠긴 방 수와 동일
    - '통조림' 1개 + '물' 3개: 1개
    - 적 2기 + '노란 키 카드' 1개: 1개
  - 랜덤 생성
    - 30%: 적 1기
    - 각 15%: 적 2기 / 적 3기 / 아이템 1개 / 아이템 2개
    - 10%: NPC 1명
- 복도
  - 모든 방은 복도와 연결되도록 생성.
  - 랜덤 생성
    - 50%: 아무것도 없음
    - 각 20%: 적 1기, 적 2기
    - 10%: 아이템 1개
- 보스 방
  - 생성 수: 층당 1개.
  - 고정 생성
    - 보스 전투: 1개
  - 검은 키 카드를 요구하는, 다음 층으로 넘어가는 문이 있다.
- 약품 창고
  - 입장하려면 노란 키 카드가 필요하다.
  - 생성 수: 층당 1개.
  - 고정 생성
    * **'만병통치약'** 1개 + 만병통치약을 제외한 임의 알약 4개: 1개
- 휴게실
  - 생성 수: 층당 1개.
  - 고정 생성: 5층 한정
    - **'알약 자판기'** NPC + '주사기 수집가' NPC : 1개
  - 랜덤 생성
    - 70%: **'알약 자판기'** NPC + 임의 NPC 1종류
    - 30%: **'알약 자판기'** NPC + 임의 NPC 2종류
- 잠긴 방
  - 입장하려면 하얀 키 카드가 필요하다.
  - 생성 수: 층당 1-3개.
  - 고정 생성
    - **'만병통치약'** 1개 + 물 1개: 1개
  - 랜덤 생성
    - 각 40%: NPC 1명 / 아이템 2종류
    - 20%: 일반 적 '사람' 1명 + '링겔액' 1개
- 비품실
  - 입장하려면 노란 키 카드가 필요하다.
    - 1층 한정으로 노란 키 카드 없이 입장할 수 있다.
  - 고정 생성
    - **장비 아이템** 1개: 1개
    - 1층 한정으로 무조건 무기가 등장한다.
    - 3층 한정으로 무조건 희귀 등급 이상의 장비가 등장한다.