﻿using Appdoon.Application.Services.RoadMaps.Query.GetRoadMapService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appdoon.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RoadMapsController : ControllerBase
	{
		private readonly IGetAllRoadMapService _getAllRoadMapService;
        private readonly IGetIndivdualRoadMapService _getRoadMapService;

        public RoadMapsController(IGetAllRoadMapService getAllRoadMapService, IGetIndivdualRoadMapService getRoadMapService)
		{
			_getAllRoadMapService = getAllRoadMapService;
			_getRoadMapService = getRoadMapService;
		}

		[HttpGet]
		public JsonResult Index()
		{
			// ResultDto<List<RoadmapDto>>
			var result = _getAllRoadMapService.Execute();

			return new JsonResult(result);
		}

		[HttpPost]
		public JsonResult IndividualRoadMap(JsonClass jclass)
		{
			var result = _getRoadMapService.Execute(jclass.RoadMapId);
			return new JsonResult(result);
		}


		public class JsonClass
        {
			public int RoadMapId { get; set; }

		}



	}
}
