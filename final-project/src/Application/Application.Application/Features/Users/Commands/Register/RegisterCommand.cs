namespace Application.Application.Features.Users.Commands.Register;
public sealed record RegisterCommand(RegisterRequest RegisterRequest) : IRequest<AuthenticationResponse> {
    private sealed class Handler : IRequestHandler<RegisterCommand, AuthenticationResponse> {
        private readonly IAuthenticationService authenticationService;

        public Handler(IAuthenticationService authenticationService) {
            this.authenticationService = authenticationService;
        }

        public Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken) {
            return this.authenticationService.RegisterUserAsync(request.RegisterRequest);
        }
    }
}