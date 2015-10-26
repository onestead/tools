namespace ConsoleApplication
{
    public class Program
    {
        public abstract class XmlNodeTemplate
        {
            [System.Xml.Serialization.XmlAttribute("id")]
            public string Id { set; get; }
            [System.Xml.Serialization.XmlText]
            public string InnerText { set; get; }
        }
        public abstract class XmlTemplate<V> : System.Collections.Generic.Dictionary<string, V>, System.Xml.Serialization.IXmlSerializable
            where V : XmlNodeTemplate, new()
        {
            protected abstract string FileName { get; }
            public new V this[string k]
            {
                set { base[k] = value; }
                get
                {
                    if (!ContainsKey(k))
                    {
                        V value = new V();
                        value.Id = k;
                        value.InnerText = k;
                        this[k] = value;
                    }
                    return base[k];
                }
            }
            public void ReadXml()
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(GetType());
                XmlTemplate<V> value = null;
                using (System.IO.Stream stream = new System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read))
                {
                    value = serializer.Deserialize(stream) as XmlTemplate<V>;
                    stream.Close();
                }
                foreach (string k in value.Keys)
                    this[k] = value[k];
            }
            public void WriteXml()
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(GetType());
                using (System.IO.Stream stream = new System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
                {
                    serializer.Serialize(stream, this);
                    stream.Close();
                }
            }

            #region IXmlSerializable メンバー
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return null;
            }
            public void ReadXml(System.Xml.XmlReader reader)
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(V));
                reader.Read();
                while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
                {
                    V value = serializer.Deserialize(reader) as V;
                    if (value != null)
                        this[value.Id] = value;
                }
                reader.ReadEndElement();
            }
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(V));
                System.Xml.Serialization.XmlSerializerNamespaces namespaces = new System.Xml.Serialization.XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                foreach (V value in Values)
                    serializer.Serialize(writer, value, namespaces);
            }
            #endregion
        }
        public class XmlNode : XmlNodeTemplate
        {
            [System.Xml.Serialization.XmlAttribute("test")]
            public string Test { set; get; }
        }
        public class XmlSetting : XmlTemplate<XmlNode>
        {
            protected override string FileName
            {
                get { return "ConsoleApplication.xml"; }
            }
        }
        static void Main(string[] args)
        {
            XmlNode n = new XmlNode();
            n.Id = "ID属性";
            n.InnerText = "テキスト";
            n.Test = "テスト属性";

            XmlSetting s1 = new XmlSetting();
            s1.Add(n.Id, n);
            s1.WriteXml();

            XmlSetting s2 = new XmlSetting();
            s2.ReadXml();

            System.Console.WriteLine("ID='{0}'", s2[n.Id].Id);
            System.Console.WriteLine("InnerText='{0}'", s2[n.Id].InnerText);
            System.Console.WriteLine("Test='{0}'", s2[n.Id].Test);
            System.Console.ReadLine();
        }
    }
}
