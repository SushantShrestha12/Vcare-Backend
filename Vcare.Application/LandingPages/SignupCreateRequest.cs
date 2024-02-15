using MediatR;
using Medicare.Infrastructure;
using Vcare.Domain.LandingPages;

namespace Medicare.Application.LandingPages;

public class SignupCreateRequest: IRequest<Signup>
{
    public string FullName { get;  set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; } 
    public string Password { get; set; } 
    public string ConfirmPassword { get; set; }
}

public class SignupCreateRequestHandler : IRequestHandler<SignupCreateRequest, Signup>
{
    private readonly VcareDbContext _context;

    public SignupCreateRequestHandler(VcareDbContext context)
    {
        _context = context;
    }
    
    public async Task<Signup> Handle(SignupCreateRequest request, CancellationToken cancellationToken)
    {
      
        var signupId = new Guid();
        var signup = new Signup(signupId, request.FullName, request.PhoneNumber, request.Email, request.Password,
            request.ConfirmPassword);

        _context.Signups.Add(signup);
        await _context.SaveChangesAsync(cancellationToken);

        return signup;
    }
}