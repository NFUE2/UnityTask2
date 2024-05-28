//HP의 감소,증가를 굳이 나눠야하나? 싶어서 하나로 통일해서 사용했습니다
//데미지를 받는경우 -값의 매개변수를 입력하고
//힐을 하는경우 +값의 매개변수를 입력하는식입니다.
public interface IChangeHP
{
    void Change(float damage);
}
