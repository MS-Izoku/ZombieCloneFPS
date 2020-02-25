using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;

[AlwaysSynchronizeSystem]
public class PlayerMoveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref PlayerMoveData moveData, ref Translation translation, in PlayerInputData inputData) =>
        {
            //#region Speed Variables
            moveData.speedForward = (inputData.moveVert > 0 ? inputData.moveVert : 0);
            moveData.speedBackPedal = (inputData.moveVert < 0 ? -inputData.moveVert : 0);
            moveData.speedStrafe = inputData.moveHor;
            //#endregion
        }).Run();
        return default;
    }
}
