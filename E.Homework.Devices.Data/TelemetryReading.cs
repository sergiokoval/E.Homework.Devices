﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Homework.Devices.Data
{
    /// <summary>
    /// Device measurement data presentation
    /// </summary>
    public sealed class TelemetryReading
    {
        public double Value { get; set; }
        public string Units { get; set; }

        public override string ToString()
        {
            return Value.ToString() + Units;
        }
    }
}
