﻿
public class Sword : IGear
{
    public string Name => "SWORD";

    public IAttack Attack => new Slash();
}