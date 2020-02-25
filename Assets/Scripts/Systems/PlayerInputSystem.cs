using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
    Entities.ForEach((ref PlayerInputData inputData) =>{
        inputData.moveHor = Input.GetAxis("Horizontal");
        inputData.moveVert = Input.GetAxis("Vertical");
        }).Run();
        return default;
    }
}
