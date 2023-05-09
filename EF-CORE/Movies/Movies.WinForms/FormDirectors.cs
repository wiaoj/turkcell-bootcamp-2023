using Movies.Application;
using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;
using Movies.Data.Data;
using Movies.Data.Repositories;

namespace Movies.WinForms;
public partial class FormDirectors : Form {
    public FormDirectors() {
        this.InitializeComponent();
    }

    private DirectorService directorService = null;
    private async void FormDirectors_Load(Object sender, EventArgs e) {
        MoviesDbContext moviesDbContext = new();
        EFDirectorRepository eFDirectorRepository = new(moviesDbContext);
        this.directorService = new(eFDirectorRepository);
        await this.fillGrid();
    }

    private async Task fillGrid() {
        IEnumerable<Application.DTOs.Responses.DirectorListResponse> list = await this.directorService.GetDirectorsAsync();
        this.dataGridView1.DataSource = list.ToList();
    }

    private async void buttonAddDirector_Click(Object sender, EventArgs e) {
        CreateNewDirectorRequest request = new() {
            Name = this.textBoxDirectorName.Text,
            LastName = this.textBoxDirectorLastName.Text,
            Info = this.textBoxDirectorInfo.Text
        };

        Int32 directorId = await this.directorService.CreateNewDirectorAsync(request);
        Boolean isDirectorAdded = directorId == 0;

        if(isDirectorAdded)
            await this.fillGrid();
    }

    int selectedDirectorId = 0;
    private async void dataGridView1_CellContentDoubleClick(Object sender, DataGridViewCellEventArgs e) {
        selectedDirectorId = (Int32)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
        SingleDirectorResponse director = await this.directorService.GetDirectorAsync(selectedDirectorId);

        this.textBoxDirectorName.Text = director.Name;
        this.textBoxDirectorLastName.Text = director.LastName;
        this.textBoxDirectorInfo.Text = director.Info;

        buttonUpdateDirector.Enabled = selectedDirectorId != 0;
    }

    private async void buttonUpdateDirector_Click(Object sender, EventArgs e) {
        UpdateDirectorRequest request = new() {
            Id = selectedDirectorId,
            Name = this.textBoxDirectorName.Text,
            LastName = this.textBoxDirectorLastName.Text,
            Info = this.textBoxDirectorInfo.Text
        };

        await this.directorService.UpdateDirectorAsync(request);
        await this.fillGrid();
    }
}
