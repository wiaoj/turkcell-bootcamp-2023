using Movies.Application;
using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;
using Movies.Data.Data;
using Movies.Data.Repositories;

namespace Movies.WinForms;
public partial class FormPlayers : Form {
    public FormPlayers() {
        this.InitializeComponent();
        MoviesDbContext moviesDbContext = new();
        EFPlayerRepository eFPlayerRepository = new(moviesDbContext);
        this.playerService = new(eFPlayerRepository);
    }

    private readonly PlayerService playerService = null;
    private void FormPlayers_Load(Object sender, EventArgs e) {
        this.fillPlayers();
    }

    private void fillPlayers() {
        //IEnumerable<PlayerListResponse> list = await this.playerService.GetPlayers();
        //this.dataGridView1.DataSource = list.ToList();
        this.dataGridView1.DataSource = this.playerService.GetPlayers()
                                                          .GetAwaiter()
                                                          .GetResult()
                                                          .ToList();
    }

    private async void buttonAddPlayer_Click(Object sender, EventArgs e) {
        CreateNewPlayerRequest createNewPlayerRequest = new() {
            Name = this.textBoxPlayerName.Text,
            LastName = this.textBoxPlayerLastName.Text
        };
        await this.playerService.CreateNewPlayer(createNewPlayerRequest);
        this.fillPlayers();
        this.textBoxPlayerName.Clear();
        this.textBoxPlayerLastName.Clear();
    }
}
