using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
namespace SK_Heater
{
	public class Alert_HeaterNeedsHopper : Alert_High
	{
		public override AlertReport Report
		{
			get
			{
                foreach (Building_Heater current in Find.ListerBuildings.AllBuildingsColonistOfClass<Building_Heater>())
				{
					bool flag = false;
					ThingDef thingDef = ThingDef.Named("HeaterHopper");
					using (IEnumerator<IntVec3> enumerator2 = GenAdj.CellsAdjacentCardinal(current).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							Thing edifice = GridsUtility.GetEdifice(enumerator2.Current);
							if (edifice != null && edifice.def == thingDef)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						return AlertReport.CulpritIs(current);
					}
				}
                return AlertReport.Inactive;
			}
		}
        public Alert_HeaterNeedsHopper()
		{
            this.baseLabel = Translator.Translate("NeedHeaterHopper");
            this.baseExplanation = Translator.Translate("NeedHeaterHopperDesc");
		}
	}
}
