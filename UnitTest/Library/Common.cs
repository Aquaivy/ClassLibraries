using Aquaivy.Core.Common;
using Aquaivy.Core.Log;

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
