using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using DTO.App.V1.Mappers;
using Extensions.Base;
using Google.DataTable.Net.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.ViewModels.Statistics;

namespace WebApp.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppBLL _bll;
        //private readonly BloodMapper _bloodMapper;
        
        public StatisticsController(ILogger<HomeController> logger, IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _logger = logger;
            //_bloodMapper = new BloodMapper(mapper);
        }
        
        [HttpGet]
        public async Task<IActionResult> General()
        {
            DataTable data = await _bll.BloodDonate.GetStatisticByTime();
            var vm = new StatisticsViewModel() {Data = data.GetJson()};
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> BloodDonates()
        {
            DataTable data = await _bll.BloodDonate.GetStatistic();
            var vm = new StatisticsViewModel() {Data = data.GetJson()};
            return View(vm);
        }
        [HttpGet]
        
        public async Task<IActionResult> BloodTransfusions()
        {
            DataTable data = await _bll.BloodTransfusion.GetStatistic();
            var vm = new StatisticsViewModel() {Data = data.GetJson()};
            return View(vm);
        }
    }
    
}
