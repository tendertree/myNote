// Observer 인터페이스
public interface ICombatObserver
{
    void OnAttack(Unit attacker, Unit defender, int damage);
}

// 공격 계산기 인터페이스 (DI 패턴)
public interface IAttackCalculator
{
    int CalculateDamage(Unit attacker, Unit defender);
}

// 유닛 클래스
public class Unit
{
    public string Name { get; set; }
    public int Health { get; set; }

    public void Attack(Unit defender, IAttackCalculator calculator, ICombatMediator mediator)
    {
        int damage = calculator.CalculateDamage(this, defender);
        mediator.NotifyObservers(this, defender, damage);
    }
}

// 전투 중재자 클래스 (Observer 패턴)
public class CombatMediator : ICombatObserver
{
    private List<ICombatObserver> observers = new List<ICombatObserver>();

    public void AddObserver(ICombatObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(ICombatObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(Unit attacker, Unit defender, int damage)
    {
        foreach (var observer in observers)
        {
            observer.OnAttack(attacker, defender, damage);
        }
    }

    public void OnAttack(Unit attacker, Unit defender, int damage)
    {
        defender.Health -= damage;
        Console.WriteLine($"{attacker.Name} attacked {defender.Name} for {damage} damage.");
    }
}

// 공격 계산기 구현
public class SimpleAttackCalculator : IAttackCalculator
{
    public int CalculateDamage(Unit attacker, Unit defender)
    {
        return 10;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Unit unitA = new Unit { Name = "Unit A", Health = 100 };
        Unit unitB = new Unit { Name = "Unit B", Health = 100 };

        IAttackCalculator calculator = new SimpleAttackCalculator();
        CombatMediator mediator = new CombatMediator();

        mediator.AddObserver(mediator); // Observer 추가

        unitA.Attack(unitB, calculator, mediator); // Unit A가 Unit B를 공격
        unitB.Attack(unitA, calculator, mediator); // Unit B가 Unit A를 공격

    }
}
