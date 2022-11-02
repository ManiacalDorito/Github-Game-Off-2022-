using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;


namespace Game_Jam_Game
{
    internal class SceneManager
    {
        Scene currentScene;
        

        public SceneManager()
        {
            currentScene = new Scene("Scene!");
        }

        public void loadScene(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var xSerializer = new XmlSerializer(typeof(Scene));
                currentScene = (Scene)xSerializer.Deserialize(fs);
                fs.Dispose();
            }
        }

        public void saveScene(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var xSerializer = new XmlSerializer(typeof(Scene));
                xSerializer.Serialize(fs, currentScene);
                fs.Close();
            }
        }
    }
}
