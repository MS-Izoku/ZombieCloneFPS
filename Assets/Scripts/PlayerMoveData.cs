using Unity.Entities;

public struct PlayerMoveData : IComponentData
{
    public float speedForward;
    public float speedStrafe;
    public float speedBackPedal;
}
