using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SassiController : ControllerBase
    {
        ShamilContext shamilContext =  new ShamilContext();

        [HttpGet]
        public List<Sassi> GetAllEmployees()
        {
            var datas =  shamilContext.Sassis.ToList();
            return datas;
        }

        [HttpPut]
        public IActionResult UpdateEmployee(int id, [FromQuery] Sassi sassi)
        {
            var data = shamilContext.Sassis.FirstOrDefault(s => s.Siraysay == id);
            if (data != null)
            {
                data.Ad = sassi.Ad;
                data.Soyad= sassi.Soyad;
                data.Yash=sassi.Yash;
                data.Mobilnomre= sassi.Mobilnomre;
                data.Maas=sassi.Maas;
                data.Bolme = sassi.Bolme;
                data.Sifarish = sassi.Sifarish;
                data.Isheqebul = sassi.Isheqebul;
                data.Unvan = sassi.Unvan;
                data.Haqqindainfo = sassi.Haqqindainfo;
                shamilContext.SaveChanges();
                return Ok();
            }
            
                return BadRequest();

        }


        [HttpPost]
        public IActionResult PostEmployee([FromQuery] Sassi sassi)
        {
            shamilContext.Sassis.Add(sassi);
            bool isSaved = shamilContext.SaveChanges() > 0;
            if (isSaved)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete]
        public IActionResult DeledeEmployee(int id)
        {
            var data = shamilContext.Sassis.FirstOrDefault(s => s.Siraysay == id);
            try
            {
                shamilContext.Sassis.Remove(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            bool isSaved = shamilContext.SaveChanges() > 0;
            if (isSaved)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
