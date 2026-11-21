using Godot;
using System;

[GlobalClass]
public partial class MonsterData : Resource
{
    [Export] public string MonsterName { get; set; }
    [Export(PropertyHint.File, "*.png")] public string BattleTexture { get; set; }
    [Export(PropertyHint.File, "*.png")] public string IconTexture { get; set; }
    [Export] public MonsterStats Stats { get; set; }
    [Export] public Godot.Collections.Dictionary<int, AttackData> Attacks {  get; set; }
    [Export] public ElementData Element { get; set; }
}
