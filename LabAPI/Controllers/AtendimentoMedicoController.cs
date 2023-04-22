using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendimentoMedicoController : ControllerBase
    {
        private readonly LabApiContext _context;
        public AtendimentoMedicoController(LabApiContext context)
        {
            _context = context;
        }



    }
}