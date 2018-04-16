using DogSE.Library.Common;
using DogSE.Library.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    class Common : TInstance<Common>
    {
        internal void ObjectPoolTest()
        {
            ObjectPool<EntityClass> pool = new ObjectPool<EntityClass>("EntityClass", 64);
            pool.ReleaseContent(new EntityClass { Name = "first" });
            var entity = pool.AcquireContent();
            Logs.Info(pool.GetPoolInfo().ToString());
            
        }
    }
}
