using _2704.Dto;
using _2704.Interfaces;
using _2704.Models;
using _2704.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2704.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Role>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<RoleDto>>(_roleRepository.GetRoles());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRole([FromBody] RoleDto roleCreate)
        {
            if (roleCreate == null)
                return BadRequest(ModelState);

            var role = _roleRepository.GetRoles()
                .Where(c => c.RoleName.Trim().ToUpper() == roleCreate.RoleName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (role != null)
            {
                ModelState.AddModelError("", "Role already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var roleMap = _mapper.Map<Role>(roleCreate);

            if (!_roleRepository.CreateRole(roleMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{RoleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRole(int RoleId, [FromBody] RoleDto updatedRole)
        {
            if (updatedRole == null)
                return BadRequest(ModelState);

            if (RoleId != updatedRole.RoleId)
                return BadRequest(ModelState);

            if (!_roleRepository.RoleExists(RoleId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var roleMap = _mapper.Map<Role>(updatedRole);

            if (!_roleRepository.UpdateRole(roleMap))
            {
                ModelState.AddModelError("", "Something went wrong updating role");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{RoleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(int RoleId)
        {
            if (!_roleRepository.RoleExists(RoleId))
            {
                return NotFound();
            }

            var roleToDelete = _roleRepository.GetRoleById(RoleId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_roleRepository.DeleteRole(roleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting role");
            }

            return NoContent();
        }
    }
}
