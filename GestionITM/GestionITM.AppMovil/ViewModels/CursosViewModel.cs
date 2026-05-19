using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionITM.AppMovil.Models;
using GestionITM.AppMovil.Services;
using System.Collections.ObjectModel;

namespace GestionITM.AppMovil.ViewModels
{
    public partial class CursosViewModel : ObservableObject
    {
        private readonly CursoService _cursoService;
        private readonly MatriculaService _matriculaService;
        private int _currentPage = 1;
        private bool _hayMasPaginas = true;

        [ObservableProperty] private bool isBusy;

        // ObservableCollection notifica cambios a la View automáticamente
        public ObservableCollection<CursoModel> Cursos { get; } = new();

        public CursosViewModel(CursoService cursoService, MatriculaService matriculaService)
        {
            _cursoService = cursoService;
            _matriculaService = matriculaService;
        }

        // Se llama al cargar la página
        [RelayCommand]
        public async Task CargarCursosAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            Cursos.Clear();
            _currentPage = 1;
            _hayMasPaginas = true;

            try
            {
                var resultado = await _cursoService.GetPagedAsync(
                    pageNumber: 1, pageSize: 10);

                foreach (var curso in resultado.Items)
                    Cursos.Add(curso);

                _hayMasPaginas = _currentPage < resultado.TotalPaginas;
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Se dispara cuando quedan 3 items por ver (scroll infinito)
        [RelayCommand]
        public async Task CargarMasAsync()
        {
            if (IsBusy || !_hayMasPaginas) return;

            IsBusy = true;

            try
            {
                _currentPage++;
                var resultado = await _cursoService.GetPagedAsync(
                    pageNumber: _currentPage, pageSize: 10);

                // Agrega al final SIN limpiar la lista
                foreach (var curso in resultado.Items)
                    Cursos.Add(curso);

                _hayMasPaginas = _currentPage < resultado.TotalPaginas;
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Se llama al pulsar "Matricularme"
        [RelayCommand]
        public async Task MatricularAsync(CursoModel curso)
        {
            await _matriculaService.MatricularseAsync(curso.Id);
        }
    }
}