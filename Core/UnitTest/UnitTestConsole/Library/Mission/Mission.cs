using System;
using System.Collections;
using System.Collections.Generic;

namespace Yosim.Academy.Programs
{
    public class Mission
    {
        public List<MissionItem> Missions;
    }

    public class MissionItem
    {
        public int Index { get; set; }
        public int OperateIndex { get; set; }
        public MissionType Type { get; set; }
        public string NPC { get; set; }
        public string Content { get; set; }
    }

    public enum MissionType
    {
        Dialogue = 0,
        Mission = 1,
    }
}
