using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44315/api/WhoWeAreDetail");
            var serviceResponseMessage = await client.GetAsync("https://localhost:44315/api/Service");
            if (responseMessage.IsSuccessStatusCode && serviceResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var serviceJsonData = await serviceResponseMessage.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var serviceData = JsonConvert.DeserializeObject<List<ResultServiceDto>>(serviceJsonData);

                var value = data.FirstOrDefault();

                ViewBag.title = value.Title;
                ViewBag.subTitle = value.SubTitle;
                ViewBag.description1 = value.Description1;
                ViewBag.description2 = value.Description2;
                ViewBag.services = serviceData;
     
                return View();
            }

            return View();
        }
    }
}
