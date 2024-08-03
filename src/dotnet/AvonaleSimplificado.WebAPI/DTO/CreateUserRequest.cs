namespace AvonaleSimplificado.WebAPI.DTO;

public record CreateUserRequest(
	string FirstName,
	string LastName,
	string Email,
	string Password,
	string CPF
);

