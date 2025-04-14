using SiniestroCentralizadoGtoApi.Modelos;

namespace Siniestro.Servidor.Interfaces
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SiniestrosContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(SiniestrosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
