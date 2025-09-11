using Data_Access_Layer.Abstract;
using Data_Access_Layer.Concrete_dal.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

public class GenericApiController<T> : ApiController where T : class
{
    private readonly IRepository<T> _repository;
    private readonly string _idPropertyName;

    public GenericApiController(string idPropertyName = "Id")
    {
        _repository = new GenericRepository<T>();
        _idPropertyName = idPropertyName; // entity’deki primary key property’si (örn: "ProductId")
    }

    // GET: api/[controller]
    [HttpGet]
    public IHttpActionResult GetAll()
    {
        var items = _repository.List();
        return Ok(items);
    }

    // GET: api/[controller]/5
    [HttpGet]
    public IHttpActionResult Get(int id)
    {
        var item = _repository.List(x =>
            (int)x.GetType().GetProperty(_idPropertyName).GetValue(x) == id
        ).FirstOrDefault();

        if (item == null)
            return NotFound();

        return Ok(item);
    }

    // POST: api/[controller]
    [HttpPost]
    public IHttpActionResult Post([FromBody] T entity)  //entity HTTP isteğinin body’sinden gelen nesne.
    {
        if (entity == null)
            return BadRequest("Entity cannot be empty");

        _repository.Insert(entity);

        return StatusCode(HttpStatusCode.Created);

    }

    // PUT: api/[controller]/5
    [HttpPut]
    public IHttpActionResult Put(int id, [FromBody] T entity)
    {
        if (entity == null)
            return BadRequest("Entity cannot be empty");

        var existing = _repository.List(x =>
            (int)x.GetType().GetProperty(_idPropertyName).GetValue(x) == id
        ).FirstOrDefault();

        if (existing == null)
            return NotFound();

        _repository.Update(entity);
        return Ok(entity);
    }

    // DELETE: api/[controller]/5
    [HttpDelete]
    public IHttpActionResult Delete(int id)
    {
        var item = _repository.List(x =>
            (int)x.GetType().GetProperty(_idPropertyName).GetValue(x) == id
        ).FirstOrDefault();

        if (item == null)
            return NotFound();

        _repository.Delete(item);
        return StatusCode(HttpStatusCode.NoContent);
    }
}



