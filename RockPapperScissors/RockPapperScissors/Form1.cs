namespace RockPapperScissors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblVersion.Text = "v1.0";
            Clear();       

        }

        int playerCount=2;
        

        List<Player> players = new List<Player>();
        List<Choice> choices = new List<Choice>();
        List<Result> results = new List<Result>();


        private void GetChoice()
        {
            Choice rock = new Choice()
            {
                Name = "taş",
                Id = 1
            };
            Choice papper = new Choice()
            {
                Name = "kağıt",
                Id = 2
            };
            Choice scissors = new Choice()
            {
                Name = "makas",
                Id = 3
            };
            choices.Add(rock);
            choices.Add(papper);
            choices.Add(scissors);
            

            Player player1 = new Player() 
            { 
                Name=tbxPlayer1Name.Text,
                Score=0,
                ChoiceId=0
            };
            Player player2 = new Player()
            {
                Name = tbxPlayer2Name.Text,
                Score = 0,
                ChoiceId = 0
            };
            players.Add(player1);
            players.Add(player2);
            GetResult();
        }       
        private void GetResult()
        {
            lblPlayer1Score.Text = players[0].Score.ToString();
            lblPlayer2Score.Text = players[1].Score.ToString();

            Random rnd = new Random();
            players[0].ChoiceId = rnd.Next(1, 4);
            players[1].ChoiceId = rnd.Next(1, 4);

            Choice choice1 = choices.Where(c => c.Id == players[0].ChoiceId).First();
            Choice choice2 = choices.Where(c => c.Id == players[1].ChoiceId).First();

            lblChoice1.Text = choice1.Name;
            lblChoice2.Text = choice2.Name;

            Result result = new Result() 
            {
                Choice1= choice1.Name,
                Choice2= choice2.Name
            };

            results.Add(result);



            if (players[0].ChoiceId - players[1].ChoiceId==1 || players[0].ChoiceId - players[1].ChoiceId == -2)
            {
                players[1].Score += 0;
                players[0].Score += 1;
                lblPlayer1Score.Text = players[0].Score.ToString();
                lblPlayer2Score.Text = players[1].Score.ToString();
                CheckScore(players[0]);
            }
            else if(players[0].ChoiceId - players[1].ChoiceId == 0)
            {
                players[0].Score += 0;
                players[1].Score += 0;
                CheckScore(players[0]);

            }
            else
            {
                players[0].Score += 0;
                players[1].Score += 1;
                lblPlayer1Score.Text = players[0].Score.ToString();
                lblPlayer2Score.Text = players[1].Score.ToString();
                CheckScore(players[1]);
            }

        }
        private void CheckScore(Player player)
        {
            string maxScore = numMaxScore.Value.ToString();

            if(player.Score==Convert.ToUInt32(maxScore))
            {
                MessageBox.Show($"{player.Name} kazandı ");
                dataGridView1.DataSource = results;
            }
            else
            {
                GetChoice();
            }
        }
        private void Clear()
        {
            foreach(Player player in players)
            {
                player.Score = 0;
                player.ChoiceId = 0;
            }
            tbxPlayer1Name.Text = string.Empty;
            tbxPlayer2Name.Text = string.Empty;
            lblPlayer1Score.Text = "0";
            lblPlayer2Score.Text = "0";
            numMaxScore.Value = 0;
            dataGridView1.DataSource = null;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            GetChoice();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int ChoiceId { get; set; }
    }
    public class Choice
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Result
    {
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }

    }
}