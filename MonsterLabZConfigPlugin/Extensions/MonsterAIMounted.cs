#nullable enable
using System;
using System.Collections.Generic;
using BepInEx.Configuration;
using UnityEngine;
using static MonsterLabZConfig.PluginConfig;

namespace MonsterLabZConfig.Extensions
{
    public class MonsterAIMounted : MonsterAI
    {
        public new void MoveToWater(float dt, float maxRange)
        {
            return;
        }
        public new void MoveAwayAndDespawn(float dt, bool run)
        {
            return;
        }
        public new void MoveTowardsSwoop(Vector3 dir, bool run, float distance)
        {
            return;
        }
        public new void MoveTowards(Vector3 dir, bool run)
        {
            return;
        }
        public new bool Flee(float dt, Vector3 from)
        {
            return true;
        }
        public new void RandomMovement(float dt, Vector3 centerPoint, bool snapToGround = false)
        {
            return;
        }

        public new void IdleMovement(float dt)
        {
            return;
        }

        public new void RandomMovementArroundPoint(float dt, Vector3 point, float distance, bool run)
        {
            return;
        }
        public new bool AvoidFire(float dt, Character moveToTarget, bool superAfraid)
        {
            return true;
        }
    }
}