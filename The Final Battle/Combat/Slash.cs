﻿
public class Slash : IAttack
{
    public string Name => "SLASH";

    public AttackData Create()
    {
        return new AttackData(2);
    }
}