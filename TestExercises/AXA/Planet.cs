using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestowyProjekt.AXA
{
    public class Planet
    {
        public string Name { get; set; }
        public long RotationPeriod { get; set; }
        public long OrbitalPeriod { get; set; }
        public long Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public long SurfaceWater { get; set; }
        public long Population { get; set; }
        public Uri[] Residents { get; set; }
        public Uri[] Films { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Edited { get; set; }
        public Uri Url { get; set; }
    }
}
