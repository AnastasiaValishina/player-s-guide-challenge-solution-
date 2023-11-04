
public abstract class Character
{
    public abstract string Name { get;  }
    public abstract IAttack StandardAttack { get; }

    private int _hp;
    public int HP
    {
        get { return _hp; }
        set { _hp = Math.Clamp(value, 0, MaxHP); }
    }

    public int MaxHP { get; }

    public IGear? Gear { get; private set; }

    public Character(int hp)
    {
        MaxHP = hp;
        HP = hp;
    }

    public void EquipGear(IGear? gear)
    {
        Gear = gear;
    }
    public bool IsAlive()
    {
        return _hp > 0;
    }
}