using Aquaivy.Core.Common;
using DogSE.Library.Serialize;
using System.Collections.Generic;

namespace UnitTest.Library
{
    class Serialize : Singleton<Serialize>
    {
        private Serialize() { }

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
