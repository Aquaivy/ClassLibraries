using Aquaivy.Core.Serialize;
using DogSE.Library.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    class Component
    {
        internal void Run()
        {
            Common common = new Common();
            Common common2 = new Common();
            Common common3 = new Common();

            CsvFileReader csv = new CsvFileReader("D:/HttpUtils.cs");
            CsvFileReader csv2 = new CsvFileReader("D:/HttpUtils.cs");

            ComponentManager componentManager = new ComponentManager();
            componentManager.RegisterComponent<Common>("Common", common);
            componentManager.RegisterComponent<Common>("Common2", common2);
            componentManager.RegisterComponent<Common>("Common3", common3);

            componentManager.RegisterComponent<CsvFileReader>("csv", csv);
            componentManager.RegisterComponent<CsvFileReader>("csv2", csv2);

            componentManager.ReleaseComponent("Common3");
            componentManager.Clear();
        }
    }
}
