namespace Benchmark
{
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using ExaminationRoomsSelector.Test;
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using ExaminationRoomsSelector.Web.Application.Queries;

    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [RPlotExporter]
    [HtmlExporter]
    public class ExaminationRoomSelectorBenchmark
    {
        private ExaminationRoomsSelectorQueryHandler handler;
        private List<DoctorDto> _doctorDtos;
        private List<ExaminationRoomDto> _examinationRoomDtos;

        
        [Params(5000)] public int N;
        [JsonFileData("Resources/data.json")]
        public void Setup(List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList)
        {
            handler = new ExaminationRoomsSelectorQueryHandler();
            _doctorDtos = doctorList;
            _examinationRoomDtos = roomList;
        }

        [Benchmark]
        public void Run() => handler.MatchDoctorsWithRooms(_doctorDtos, _examinationRoomDtos);
    }
}