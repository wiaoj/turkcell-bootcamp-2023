namespace TaskMechanism;

public partial class Form1 : Form {
    public Form1() {
        CheckForIllegalCrossThreadCalls = false;
        InitializeComponent();
    }

    private async void ButtonCounter_Click(Object sender, EventArgs e) {
        await Task.Run(counter);
        MessageBox.Show("Bitti");
    }

    private Task counter() {
        for(Int32 index = 0; index <= 10_000; index++) {
            labelCounter.Text = index.ToString();
            progressBar1.Value = index / 100;
        }
        return Task.CompletedTask;
    }

    private void buttonTest_Click(Object sender, EventArgs e) {
        MessageBox.Show("Show");
    }
}
