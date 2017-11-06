using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnProtobuf_net
{
    /// <summary>
    /// 定义一个可以ProtoBuf序列化的Person类
    /// </summary>
    [ProtoContract]
    class Person
    {
        [ProtoMember(1)]
        public string name;
        [ProtoMember(2)]
        public int age;
        [ProtoMember(3)]
        public List<string> qq;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.name = "小明";
            person1.age = 16;
            person1.qq = new List<string>();
            person1.qq.Add("2222222");
            person1.qq.Add("6666666");

            //序列化Person类实例
            using (FileStream stream = File.OpenWrite("Person1.dat"))
            {
                ProtoBuf.Serializer.Serialize<Person>(stream, person1);
            }

            //反序列化Person类实例
            Person person2 = null;
            using (FileStream stream = File.OpenRead("Person1.dat"))
            {
                person2 = ProtoBuf.Serializer.Deserialize<Person>(stream);
                Console.WriteLine("name:{0}",person2.name);
                Console.WriteLine("age:{0}", person2.age);
                foreach (string tempqq in person2.qq)
                {
                    Console.WriteLine("qq:{0}",tempqq);
                }
            
            }
        }
    }
}
