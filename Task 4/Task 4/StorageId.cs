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

        private class GroupObjects<TObject> : IGroupObjects
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

            bool IsNewType = true;
            for (var i = 0; i < this.groupsObjectes.Count; i++)
            {
                if (this.groupsObjectes[i] is GroupObjects<TObject>)
                {
                    IsNewType = false;

                    this.groupsObjectes[i].Guids.Add(newGuid);

                    break;
                }
            }

            if (IsNewType)
            {
                var groupObjects = new GroupObjects<TObject>();
                groupObjects.Guids.Add(newGuid);

                this.groupsObjectes.Add(groupObjects);
            }

            return newObject;
        }


        public void PrintAllGroupsObjects()
        {
            foreach (var groupObjects in this.groupsObjectes)
            {
                Console.WriteLine("Объекты типа " + groupObjects.GetType() + ":");

                foreach (var guid in groupObjects.Guids)
                {
                    Console.WriteLine("\t ( {0}, {1} )", guid, this.objects[this.indexes[guid]].ToString());
                }
            }
        }

        public Object GetObjectForGuid(Guid guid)
        {
            if (!this.indexes.ContainsKey(guid))
                return null;

            return this.objects[this.indexes[guid]];
        }
    }
}
