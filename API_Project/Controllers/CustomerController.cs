using API_Project.Data.Context;
using API_Project.Data.Entities;
using API_Project.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

           private readonly Context? _db;

            public CustomerController(Context? context)
            {
                _db = context;
            }


            [HttpGet]
            public IActionResult Get()
            {
                List<CustomerDto> customers = _db.Customers.Select(x => new CustomerDto
                {
                    MusteriAdi = x.Name,
                    MusteriSoyadi = x.LastName,
                    MusteriYas = x.Age,
                    Telefon = x.Phone,
                    
                }).ToList();

                if (customers.Count > 0)
                {
                    return Ok(customers);
                }
                return NoContent();

            }

        [HttpPost]
        public IActionResult Post ([FromBody]CustomerDto customerDto) 
        {
            Customer customer = new Customer();
            customer.Name = customerDto.MusteriAdi;
            customer.LastName = customerDto.MusteriSoyadi;
            customer.Age = customerDto.MusteriYas;
            customer.Phone = customerDto.Telefon;

            _db.Customers.Add(customer);
            _db.SaveChanges();
            return Ok(customerDto);

        }

        [HttpPut]
        public IActionResult Put([FromBody]CustomerDto customerDto, string Id)
        {
            Customer? existingCustomer = _db.Customers.Find(Id);
            existingCustomer.Name = customerDto.MusteriAdi;
            existingCustomer.LastName = customerDto.MusteriSoyadi;
          
            if (existingCustomer != null)
            {
                _db.Update(existingCustomer);
                _db.SaveChanges();
                return Ok("Kayıt Güncellendi");
            }
            return NotFound();

        }

        //DTO üzerinden sildirme işlemi NŞA silmelerde buna gerek yok.

        [HttpDelete]
        public IActionResult Delete ([FromBody]CustomerDeleteDto customerDeleteDto)
        {
           Customer existingCustomer =  _db.Customers.Find(customerDeleteDto.Id);

           if(existingCustomer != null)
            {
                _db.Customers.Remove(existingCustomer);
                _db.SaveChanges();
                return Ok("Silindi");
            }
           return NotFound();
        }



            //[HttpPost]                  //API Olduğu için
            //public IActionResult Post ([FromBody] Customer customer)
            //{
            //   _db.Customers.Add(customer);
            //   _db.SaveChanges();

            //    return Ok();
            //}

            //[HttpGet]
            //public IActionResult Get([FromBody] Customer customer)
            //{
            //    List<Customer> customerList = _db.Customers.ToList();

            //    if(customerList.Count >=0)
            //    {
            //        return Ok(customerList);
            //    }

            //    return NoContent();
            //}
        
    }

}

