using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;
using TeamCoordinator.Properties;

namespace TeamCoordinator
{
    class Storage
    {
        private string m_Path;

        public Storage(string path)
        {
            if (File.Exists(path))
            {
                m_Path = path;
            }
        }

        public XDocument LoadFile()
        {
            if (!File.Exists(m_Path))
            {
                MessageBox.Show(string.Format(Resources.eNoFile, m_Path));
                return null;
            }
            var doc = XDocument.Load(m_Path);

            //foreach (var xe in doc.Root.Elements())
            //{
            //    if (xe.Name == key)
            //    {
            //        list.Add(new Attributes(xe));
            //    }
            //}

            return doc;
        }

        public void SaveFile()
        {
            if (!File.Exists(m_Path))
            {
                File.Create(m_Path);
            }


        }
    }
}
