using Aquaivy.Core.Common;
using Aquaivy.Core.Serialize;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Yosim.Academy.Programs;

namespace UnitTest.Library
{
    class Serialize : Singleton<Serialize>
    {
        private Serialize() { }

        public void CSVSerialize()
        {
            string path = @"D:\Yosim\Projects\YosimAcademy\Assets\Core\Resources\GameLevelConfig\guide_1.csv";
            var content = File.ReadAllText(path, Encoding.UTF8);
            var missions = CSVSerializeUtil.CSVDeserialize<MissionItem>(content);
            var mission = new Mission { Missions = missions.ToList() };
        }

        public void ReadValues()
        {
            List<string> columns = new List<string>();
            using (var reader = new CsvFileReader("D://1.csv"))
            {
                while (reader.ReadRow(columns))
                {
                    // TODO: Do something with columns' values
                }
            }
        }


        public void WriteValues()
        {
            using (var writer = new CsvFileWriter("D://2.csv"))
            {
                writer.WriteRow(new List<string> { "Id", "Age", "啦啦啦" });

                // Write each row of data
                for (int row = 0; row < 100; row++)
                {
                    // TODO: Populate column values for this row
                    List<string> columns = new List<string>()
                    {
                        row.ToString(),
                        (20+row).ToString(),
                        "啦啦啦"+row
                    };

                    writer.WriteRow(columns);
                }
            }
        }
    }
}
