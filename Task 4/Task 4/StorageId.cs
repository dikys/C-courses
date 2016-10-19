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
        private interface IGroupObjects
        {
            List<Guid> Guids { get; }
        }

        private class GroupObjects<TObjects> : IGroupObjects
        {
            private List<Guid> guids;
            public List<Guid> Guids
            {
                get { return this.guids; }
            }

            public GroupObjects()
            {
                this.guids = new List<Guid>();
            }
        }

        private Dictionary<Guid, int> indexes;
        private ArrayList objects;
        private List<IGroupObjects> groupsObjectes;

        public StorageId()
        {
            indexes = new Dictionary<Guid, int>();
            objects = new ArrayList();
            groupsObjectes = new List<IGroupObjects>();
        }
        
        public TObject CreateObject<TObject>()
            where TObject : new()
        {
            TObject newObject = new TObject();
            Guid newGuid = Guid.NewGuid();

            this.objects.Add(newObject);
            this.indexes.Add(newGuid, this.objects.Count - 1);

            bool isNewType = true;
            for (var i = 0; i < this.groupsObjectes.Count; i++)
            {
                if (this.groupsObjectes[i] is GroupObjects<TObject>)
                {
                    isNewType = false;

                    this.groupsObjectes[i].Guids.Add(newGuid);

                    break;
                }
            }

            if (isNewType)
            {
                var groupObjects = new GroupObjects<TObject>();
                groupObjects.Guids.Add(newGuid);

                this.groupsObjectes.Add(groupObjects);
            }

            return newObject;
        }


        public Dictionary<Guid, TObject> GetGroupObjects<TObject>()
        {
            foreach (var groupObjects in this.groupsObjectes)
            {
                if (!(groupObjects is GroupObjects<TObject>))
                    continue;

                var result = new Dictionary<Guid, TObject>();

                foreach (var guid in groupObjects.Guids)
                {
                    result.Add(guid, (TObject)this.objects[this.indexes[guid]]);
                }

                return result;
            }

            throw new TypeAccessException("Group objects with type TObject not find!");
        }

        public Object GetObjectForGuid(Guid guid)
        {
            if (!this.indexes.ContainsKey(guid))
                return null;

            return this.objects[this.indexes[guid]];
        }
    }
}
