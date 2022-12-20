﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class SpriteManagerSystem : SystemBase
{
  protected override void OnUpdate() {
    Entities.WithAll<LifeTime>().ForEach((Entity entity, ref LifeTime lifetime) => {
      if(lifetime.Value < 0) {
        SpriteSheetManager.DestroyEntity(entity, "emoji");
      }
      else {
        lifetime.Value -= SystemAPI.Time.DeltaTime;
      }
    }).Schedule();
  }
}
