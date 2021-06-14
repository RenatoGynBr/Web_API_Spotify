namespace API_Spotify.Pagination
{
    public class PaginacaoParametros
    {
        const int tamanhoPaginaMaximo = 50;
        public int NumeroPagina { get; set; } = 1;
        private int _tamanhoPagina = 5;
        public int TamanhoPagina
        {
            get
            {
                return _tamanhoPagina;
            }
            set
            {
                _tamanhoPagina = (value > tamanhoPaginaMaximo)
                                ? tamanhoPaginaMaximo : value;
            }
        }
    }
}
