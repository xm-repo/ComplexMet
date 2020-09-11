using System;
using System.IO;

namespace cm
{
    [Serializable]
    public class Settings
    {
        public static string lastCFG = "last.cfg";

        public string COM { get; set; }
        public int Baudrate { get; set; }
        public int Timeout { get; set; }
        public double Uab_mult { get; set; }
        public double Ia_mult { get; set; }
        public double Ib_mult { get; set; }
        public double Uc_mult { get; set; }
        public double Ic_mult { get; set; }
        public double Ia_step { get; set; }
        public double Uab_step { get; set; }
        public double Uab_filter { get; set; }
        public double Ia_filter { get; set; }

        public void Save(string file)
        {
            using (Stream stream = File.Open(file, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
            }
        }

        public Settings()
        {
            COM = "";
            Baudrate = 9600;

            Uab_mult = 1.0 / 12.5;
            Ia_mult = 1.0 / 500;
            Ia_mult = 1.0 / 500;
            Uc_mult = 1.0 / 80;
            Ic_mult = 1.0 / 40;

            Ia_step = 0.01;
            Uab_step = 0.5;

            Uab_filter = 5;
            Ia_filter = 5;

            Timeout = 100;
        }

        public static Settings FromFile(string file)
        {
            using (Stream stream = File.Open(file, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (Settings) binaryFormatter.Deserialize(stream);
            }
        }
    }
}
