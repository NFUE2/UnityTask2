# Unity 게임개발 숙련 개인과제 
## 필수구현과제
### 1.기본 이동 및 점프
![1 Move](https://github.com/NFUE2/UnityTask2/assets/96811655/8b16a8d7-e2d6-4299-aec9-e342868ed579)

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/7f7128a7-04ca-4429-bc52-fe1cf39ccf33)
![image](https://github.com/NFUE2/UnityTask2/assets/96811655/90433a13-49b1-4466-9074-c55ace63fbc1)

이동에는 InputSystem을 이용하였습니다.  
PlayerMovement 클래스에서 키보드 입력을 받아 캐릭터가 이동합니다.

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/f3d0c19d-6301-4f20-a28a-5590d05545be)

캐릭터의 시야는 PlayerSight 클래스에서 입력을 받고 수행합니다.

### 2.체력바 UI

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/ba954cd9-a3d7-4b61-bd16-f9b23d77debf)

PlayerData로 플레이어의 데이터를 가지고 UI에 적용됩니다.

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/9d3fa6c0-ac5f-414a-a0bf-17151c6c10cf)

Condition 클래스에서 해당 값에 대한 관리를 진행합니다.

### 3.동적 환경 조사

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/acb5a115-b3cb-400c-a6c1-8da22e196a60)

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/5b61d113-2d2f-4cc9-95d6-d1e910e86934)

Ray를 사용하여 캐릭터가 보고 있는 아이템의 이름을 가져오고 출력해줍니다.

### 4.점프대

![2 Jump](https://github.com/NFUE2/UnityTask2/assets/96811655/094ca7b8-5269-4235-928a-aca158d0078c)

점프대를 구현하여 캐릭터가 점프대 위에 진입했을때 높이 띄워줍니다.

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/849c33fa-67a1-49c8-a64c-688dbd7fa367)


### 5.아이템 데이터 

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/a1729317-85fc-435c-8644-8b885e60fd85)
![image](https://github.com/NFUE2/UnityTask2/assets/96811655/b4a20148-d423-42e9-a970-2317f079af08)

ScriptableObject을 이용하여 아이템 데이터를 저장,관리하였습니다.

### 6.아이템 사용
![3 SpeedUp](https://github.com/NFUE2/UnityTask2/assets/96811655/4a635c6e-07c0-4331-af65-b3aeb13b95cc)

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/53734471-9f6c-4586-9620-80b6f96dc448)
![image](https://github.com/NFUE2/UnityTask2/assets/96811655/e3c93be4-b020-4ebf-a1fe-f8d94dc121ad)

아이템을 먹었을때 플레이어가 일정시간동안 스피드가 빨라집니다.

## 선택구현과제
### 1.추가 UI

![4 UI](https://github.com/NFUE2/UnityTask2/assets/96811655/8e50a7d1-d50a-4523-aa63-ed2da4d4c600)

이동속도 아이템을 사용했을때 해당 유지시간동안 ui가 표시되고 효과가 끝나면 사라집니다.
이번에 AnimationCurve를 처음 알게되서 써먹어보고 싶었고 그걸 이용해서 깜빡이는 것 같은 효과를 줬습니다.

### 2.3인칭 시점

![5 Camear](https://github.com/NFUE2/UnityTask2/assets/96811655/adeb6235-323a-4bc9-b3e6-c3e02eff4fda)

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/673d74eb-5862-435e-aba4-4426ea4d2b9f)


V키를 누르면 시점이 변경됩니다.

### 3.움직이는 플랫폼 구현

![6 Paddle](https://github.com/NFUE2/UnityTask2/assets/96811655/de7e74af-c060-4620-9990-0de90d06775e)
![image](https://github.com/NFUE2/UnityTask2/assets/96811655/7866f8b3-7df7-4513-b1f6-fe524813fd1e)

패들이 랠리포인트를 왕복하고 플레이어가 탑승해도 따라가며 이동에 문제가 없습니다.

### 5.다양안 아이템 구현

필수6에서 구현했습니다

### 6.장비 장착

![7 Item](https://github.com/NFUE2/UnityTask2/assets/96811655/0c0a2c64-ff48-4683-bdf4-1512aa424029)

아이템을 먹으면 장착이됩니다.

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/4ee66a4c-59bd-4a0e-802a-65c890cfb30c)

이동속도와 점프 높이가 올라가는 아이템입니다 

### 7.레이저 트랩

![9 Ray](https://github.com/NFUE2/UnityTask2/assets/96811655/030d9792-7e8a-4e74-9f44-81a8edb23ab6)
![image](https://github.com/NFUE2/UnityTask2/assets/96811655/9aca5dab-4c05-4e38-a3ae-c194a325a51f)

문을 지나갔을때 트랩에 감지되면 경고메세지가 출력됩니다

### 8.상호작용 가능한 오브젝트 표시

![8 Door](https://github.com/NFUE2/UnityTask2/assets/96811655/ffa1611e-b9e7-45c5-8533-1dd57f050be4)

오브젝트가 상호작용이 가능하면 텍스트가 출력되고 해당 키를 누르면 상호작용이 됩니다.

### 9.플랫폼 발사기

![10 Rocket](https://github.com/NFUE2/UnityTask2/assets/96811655/0fbb406a-a01e-42bb-8fee-06bd0b5edead)

![image](https://github.com/NFUE2/UnityTask2/assets/96811655/50fba531-7d41-412d-8161-e06dedc3812e)

패들을 밟으면 3초뒤 패들의 전방으로 날아갑니다. ForceMode.VelocityChange를 이용하여 무게를 무시하고 날려버렸습니다.

## 구현하지못한 과제

4.벽 타기 및 매달리기
10. 발전된 AI 

##잡담
과제양이 너무많아요...시간은 너무없고...
구현 못한부분은 튜터님들에게 물어보겠습니다...
너무힘들었습니다....쉬고싶어요...
