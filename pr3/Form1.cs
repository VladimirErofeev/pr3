namespace pr3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (PartersPr2Context db = new PartersPr2Context())
            {
                var partners = db.Partners.ToList();
                foreach (Partner u in partners)
                {
                    lable_Partners.Text += ($"{u.Id} {u.IdTypePartner} {u.Address} {u.Inn} {u.DirectorName} {u.MobilePhone} {u.Email} {u.Rating}\n");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
