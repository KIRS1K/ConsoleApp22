namespace ConsoleApp22
{
    internal class Program
    {
        internal class Student
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime DateOfBirth { get; set; }
            public decimal AverageScore { get; set; }
        }

        static void Main(string[] args)
        {
            string filespace = "D:/1.txt";
            List<Student> result = ReadStudentsFromBinFile(filespace);
            Console.WriteLine(result);
        }

        static List<Student> ReadStudentsFromBinFile(string fileName)
        {
            List<Student> result = new();
            using FileStream fs = new FileStream(fileName, FileMode.Open);
            using StreamReader sr = new StreamReader(fs);

            Console.WriteLine(sr.ReadToEnd());

            fs.Position = 0;

            BinaryReader br = new BinaryReader(fs);

            while (fs.Position < fs.Length)
            {
                Student student = new Student();
                student.Name = br.ReadString();
                student.Group = br.ReadString();
                long dt = br.ReadInt64();
                student.DateOfBirth = DateTime.FromBinary(dt);
                student.AverageScore = br.ReadDecimal();

                result.Add(student);
            }

            fs.Close();
            return result;
        }
    }
}
