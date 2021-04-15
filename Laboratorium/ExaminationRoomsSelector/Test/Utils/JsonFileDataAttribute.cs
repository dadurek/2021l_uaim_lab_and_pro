namespace ExaminationRoomsSelector.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using Newtonsoft.Json;
    using Xunit.Sdk;

    public class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;


        public JsonFileDataAttribute(string filePath)
        {
            _filePath = filePath;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(_filePath);

            return GetData(fileData);
        }

        private IEnumerable<object[]> GetData(string jsonData)
        {
            var datalist = JsonConvert.DeserializeObject<DoctorsRooms>(jsonData);

            yield return new object[]
            {
                datalist.DoctorDtos,
                datalist.ExaminationRoomDtos
            };
        }
    }
}