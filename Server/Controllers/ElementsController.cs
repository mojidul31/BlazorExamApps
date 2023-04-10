using BlazorExamApps.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExamApps.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly IElementRepository _dataAccessProvider;

        public ElementsController(IElementRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("api/Elements/Get")]
        public IEnumerable<Elements> Get()
        {
            return _dataAccessProvider.GetElementList();
        }

        [HttpPost]
        [Route("api/Elements/Create")]
        public void Create([FromBody] Elements element)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.CreateElements(element);
            }
        }

        [HttpGet]
        [Route("api/Elements/Details/{id}")]
        public Elements Details(int id)
        {
            return _dataAccessProvider.GetElements(id);
        }

        [HttpPut]
        [Route("api/Elements/Edit")]
        public void Edit([FromBody] Elements element)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateElements(element);
            }
        }

        [HttpDelete]
        [Route("api/Elements/Delete/{id}")]
        public void DeleteConfirmed(int id)
        {
            _dataAccessProvider.DeleteElements(id);
        }
    }
}
