using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        // Assign the object in the constructor for dependency injection
        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Source source = new Source(){
                FirstName = "FirstName",
                LastName = "LastName",
                sourceAddress = new SourceAddress
                {
                    State = "State",
                    Street = "Street",
                    Zip = "Zip"
                }
            };

            Destination destination = _mapper.Map<Source, Destination>(source);

            Source newSource = _mapper.Map<Destination, Source>(destination);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
