using System;
using System.IO;
using System.Linq;

namespace GTools.GCN
{
    [Serializable]
    public class InvalidGCNDataException : Exception
    {
        public InvalidGCNDataException() { }

        public InvalidGCNDataException(string message)
            : base(message) { }
    }

    [Serializable]
    public class InvalidChunkSizeException : Exception
    {
        public InvalidChunkSizeException() { }

        public InvalidChunkSizeException(string message)
            : base(message) { }
    }

    /// <summary>
    /// The class to read the GCN Format. To learn more about the format see <see cref=""/>
    /// </summary>
    public static class GCNSerializer
    {
        /// <summary>
        /// Reads GCN data and returns a list of strings
        /// </summary>
        /// <param name="filename">File to read from</param>
        /// <returns></returns>
        public static List<string> ReadFromFile(string filename)
        {
            string data = File.ReadAllText(filename);
            int chunkSize = Convert.ToInt32(Char.GetNumericValue(data[0]));

            data = data.Remove(0, 1);
            List<string> dataList = data.Split(';').ToList<string>();

            return dataList;
        }

        /// <summary>
        /// Writes GCN Data to a file
        /// </summary>
        /// <param name="data">GCNData object</param>
        /// <param name="filename">The File to write to</param>
        public static void WriteToFile(GCNData data, string filename)
        {
            List<string> dataUnpacked = data.GetData();

            File.WriteAllText(filename, data.chunkSize.ToString());

            foreach (string item in dataUnpacked)
            {
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.Write(item + ";");
                }
            }
        }
    }

    /// <summary>
    /// A class that store data in the GCN format. Used in GCNSerializer.WriteToFile
    /// </summary>
    public class GCNData
    {
        public int chunkSize { get; private set; }
        private List<string> dataList;
        public GCNData(int chunkSize)
        {
            if (chunkSize > 9)
            {
                throw new InvalidChunkSizeException("Cannot accept chunk sizes over 9");
            }
            this.chunkSize = chunkSize;
            dataList = new List<string>();
        }

        /// <summary>
        /// Adds the given integer into the object
        /// </summary>
        /// <param name="data">Data to pass to the object</param>
        /// <exception cref="InvalidGCNDataException"></exception>
        public void AddData(int data)
        {
            string finalData = "";
            if (data.ToString().Length > chunkSize)
            {
                throw new InvalidGCNDataException("Data passed is greater than the chunk size. Try using ChangeChunkSize");
            }
            if (data < 0)
            {
                throw new InvalidGCNDataException("Data passed cannot be negative");
            }

            if (data < 10)
            {
                finalData = "00" + data.ToString();
            }
            else if (data > 9 && data < 100)
            {
                finalData = "0" + data.ToString();
            }
            else if (data < 999 && data > 99)
            {
                finalData = data.ToString();
            }

            dataList.Add(finalData);
        }

        /// <summary>
        /// Returns the list of strings currently stored
        /// </summary>
        /// <returns></returns>
        public List<string> GetData()
        {
            return dataList;
        }
    }
}
