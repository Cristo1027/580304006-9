using GestionITM.AppMovil.ViewModels;

namespace GestionITM.AppMovil.Views
{
    public partial class CursosPage : ContentPage
    {
        public CursosPage(CursosViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Cargar cursos al entrar a la pantalla
            var vm = (CursosViewModel)BindingContext;
            await vm.CargarCursosAsync();
        }
    }
}