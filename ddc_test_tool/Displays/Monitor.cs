using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleKVM.Displays
{
    public abstract class Monitor
    {
        public string MonitorUniqueId = "";

        public string Model = "";

        public abstract int GetCurrentSource();

        public List<int> ValidSources = new List<int>();

        public abstract bool SetSource(int newSourceId);
    }
}
