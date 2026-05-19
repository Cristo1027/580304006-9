using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionITM.AppMovil.Services;

namespace GestionITM.AppMovil.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty] private string email = string.Empty;
        [ObservableProperty] private string password = string.Empty;
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private string errorMessage = string.Empty;
        [ObservableProperty] private bool hasError;

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            HasError = false;
            IsBusy = true;

            try
            {
                // Llamar al servicio de autenticación
                var token = await _authService.LoginAsync(Email, Password);

                // Guardar el token de forma segura
                // SecureStorage usa Keychain (iOS) o Keystore (Android)
                await SecureStorage.SetAsync("jwt_token", token);

                // Navegar al catálogo de cursos
                await Shell.Current.GoToAsync("//CursosPage");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                HasError = true;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}