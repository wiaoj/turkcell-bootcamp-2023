namespace BasicThread;

public partial class Form1 : Form {
    public Form1() {
        CheckForIllegalCrossThreadCalls = false;
        InitializeComponent();
    }

    Thread? thread = null;
    private void ButtonCounter_Click(Object sender, EventArgs e) {
        thread = new Thread(new ThreadStart(counter));

        thread.Start();

        thread.Join();

        MessageBox.Show("Bitti");
    }

    private void counter() {
        for(Int32 index = default; index <= 10_000; index++) {
            labelCounter.Text = index.ToString();
            progressBar1.Value = index / 100;
        }
    }

    private void buttonTest_Click(Object sender, EventArgs e) {
        MessageBox.Show("Show");
    }
}
