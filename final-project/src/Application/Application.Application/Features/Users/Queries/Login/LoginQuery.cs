namespace Application.Application.Features.Users.Queries.Login;
public sealed record LoginQuery(LoginRequest LoginRequest) : IRequest<AuthenticationResponse> {
    private sealed class Handler : IRequestHandler<LoginQuery, AuthenticationResponse> {
        private readonly IAuthenticationService authenticationService;

        public Handler(IAuthenticationService authenticationService) {
            this.authenticationService = authenticationService;
        }

        public Task<AuthenticationResponse> Handle(LoginQuery request, CancellationToken cancellationToken) {
            return this.authenticationService.LoginUserAsync(request.LoginRequest);
        }
    }
}