﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace GeneticRim
{

    public class DamageWorker_GoForTheEyes : DamageWorker_Cut
    {
        float chance = 0.25f;

        protected override void ApplySpecialEffectsToPart(Pawn pawn, float totalDamage, DamageInfo dinfo, DamageWorker.DamageResult result)
        {
            base.ApplySpecialEffectsToPart(pawn, totalDamage, dinfo, result);


            if (Rand.Chance(chance))
            {

                BodyPartRecord eye = pawn.health.hediffSet.GetNotMissingParts(BodyPartHeight.Undefined, BodyPartDepth.Undefined, null, null).
                                   FirstOrDefault((BodyPartRecord x) => x.def == BodyPartDefOf.Eye);
                if (eye != null)
                {
                    DamageInfo damageInfo = new DamageInfo(DamageDefOf.Cut, 10, 999f, -1f, dinfo.Instigator, eye, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, true);
                    damageInfo.SetAllowDamagePropagation(false);
                    pawn.TakeDamage(damageInfo);
                }
            }


        }
    }
}