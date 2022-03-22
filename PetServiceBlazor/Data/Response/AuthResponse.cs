public class AuthResponse 
{
    public string JWTToken { get; set; } = default!; 
    public string? Nombres { get; set; }
    public string? ApellidoP { get; set; }
    public string? Correo { get; set; }

}