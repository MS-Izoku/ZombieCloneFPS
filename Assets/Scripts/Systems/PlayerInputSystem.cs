using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
    Entities.ForEach((ref PlayerInputData inputData) =>{
//        inputData.moveHor++;
//        inputData.moveVert++;
        }).Run();
        return default;
    }
}
