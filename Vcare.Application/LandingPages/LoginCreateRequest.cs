using MediatR;
using Medicare.Infrastructure;
using Vcare.Domain.LandingPages;

namespace Medicare.Application.LandingPages;

public class LoginCreateRequest: IRequest<Login>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginCreateRequestHandler : IRequestHandler<LoginCreateRequest, Login>
{
    private readonly VcareDbContext _context;

    public LoginCreateRequestHandler(VcareDbContext context)
    {
        _context = context;
    }
    public async Task<Login> Handle(LoginCreateRequest request, CancellationToken cancellationToken)
    {
        var login = new Login(request.Email, request.Password);

        _context.Logins.Add(login);
        await _context.SaveChangesAsync(cancellationToken);

        return login;
    }
}