using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricks.Data;
using Matricks.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matricks.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IMapper _userMap;

        public IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/users/users")]
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var all = await _repository.GetUsers();
            var info = _userMap.Map<IEnumerable<UserDTO>>(all);
            return info;
        }

        [HttpGet]
        [Route("/api/users/{id}")]
        public async Task<UserDTO> GetById(int id)
        {
            var single = await _repository.GetUser(id);
            var info = _userMap.Map<UserDTO>(single);
            return info;

        }


    }
}
