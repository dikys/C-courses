using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public class StorageId
    {
        private Dictionary<Guid, Object> objects;
        private Dictionary<Type, List<Guid>> groupObjects;

        public StorageId()
        {
            objects = new Dictionary<Guid, object>();
            groupObjects = new Dictionary<Type, List<Guid>>();
        }
        
        public TObject CreateObject<TObject>()
            where TObject : new()
        {
            TObject newObject = new TObject();
            Guid newGuid = Guid.NewGuid();
            Type newObjectType = newObject.GetType();

            this.objects.Add(newGuid, newObject);

            if (this.groupObjects.ContainsKey(newObjectType))
            {
                this.groupObjects[newObjectType].Add(newGuid);
            }
            else
            {
                this.groupObjects.Add(newObjectType, new List<Guid>() { newGuid });
            }

            return newObject;
        }


        public Dictionary<Guid, TObject> GetGroupObjects<TObject>()
            where TObject: new()
        {
            var result = new Dictionary<Guid, TObject>();

            var objectsType = new TObject().GetType();

            if (!this.groupObjects.ContainsKey(objectsType))
                throw new TypeAccessException("Type is not exists!");

            foreach (var guid in this.groupObjects[objectsType])
            {
                result.Add(guid, (TObject)this.objects[guid]);
            }

            return result;
        }

        public Object GetObjectForGuid(Guid guid)
        {
            if (!this.objects.ContainsKey(guid))
                return null;

            return this.objects[guid];
        }
    }
}
