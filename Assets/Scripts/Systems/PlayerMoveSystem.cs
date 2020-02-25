using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class PlayerMoveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref PlayerMoveData moveData , in PlayerInputData inputData) => {
            // put movement logic here
            moveData.speedForward = (inputData.moveVert > 0 ? inputData.moveVert : 0);
            moveData.speedBackPedal = (inputData.moveVert < 0 ? -inputData.moveVert : 0);
            moveData.speedStrafe = inputData.moveHor;
        }).Run();
        return inputDeps;
    }
}
